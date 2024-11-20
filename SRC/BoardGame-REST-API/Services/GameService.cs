using AutoMapper;
using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.DbManagement.Entities;
using BoardGame_REST_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BoardGame_REST_API.Services
{
    public class GameService : IGameService
    {
        private readonly BoardGameDbContext _dbContext;
        private readonly IMapper _mapper;

        public GameService(BoardGameDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<GameDto> UpdateAsync(int id, GameDto gameDto)
        {
            var game = await _dbContext.Games.AsNoTracking().FirstOrDefaultAsync(g => g.GameId == id);
            var gm = _mapper.Map<Game>(gameDto);

            game = gm;

            _dbContext.Games.Update(game);

            await _dbContext.SaveChangesAsync();
            return gameDto;
        }

        public async Task<GameDto> DeleteAsync(int id)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(g => g.GameId == id);

            _dbContext.Games.Remove(game);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameDto>(game);
        }

        public async Task<GameDto> GetByIDAsync(int id)
        {
            var gameDto = await _dbContext.Games
                .AsNoTracking()
                .Select(gm => new GameDto
                {
                    GameId = gm.GameId,
                    Name = gm.Name,
                    Description = gm.Description,
                    TimeOfPlayingInMinutes = gm.TimeOfPlayingInMinutes,
                    Weight = gm.Weight,
                    Score = gm.Score,
                    // For each game, select related authors using the junction table AuthorGames
                    Authors = _dbContext.AuthorGames
                        .Where(ag => ag.GameId == gm.GameId)         // Filter AuthorGames by the current GameId
                        .Select(ag => new AuthorDto                  // Map each related Author to AuthorDto
                        {
                            AuthorId = ag.Author.AuthorId,
                            FirstName = ag.Author.FirstName,
                            LastName = ag.Author.LastName,
                            AuthorDescription = ag.Author.AuthorDescription
                        })
                        .ToList(),
                    Categories = _dbContext.CategoryGames
                        .Where(cg => cg.GameId == gm.GameId)
                        .Select(cg => new CategoryDto
                        {
                            CategoryId = cg.Category.CategoryId,
                            Name = cg.Category.Name,
                            Description = cg.Category.Description
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            return gameDto;
        }

        public async Task<IEnumerable<GameDto>> GetAllAsync()
        {
            var gameDtos = await _dbContext.Games
                .AsNoTracking()
                .Select(gm => new GameDto
                {
                    GameId = gm.GameId,
                    Name = gm.Name,
                    Description = gm.Description,
                    TimeOfPlayingInMinutes = gm.TimeOfPlayingInMinutes,
                    Weight = gm.Weight,
                    Score = gm.Score,
                    // For each game, select related authors using the junction table AuthorGames
                    Authors = _dbContext.AuthorGames
                        .Where(ag => ag.GameId == gm.GameId)         // Filter AuthorGames by the current GameId
                        .Select(ag => new AuthorDto                  // Map each related Author to AuthorDto
                        {
                            AuthorId = ag.Author.AuthorId,
                            FirstName = ag.Author.FirstName,
                            LastName = ag.Author.LastName,
                            AuthorDescription = ag.Author.AuthorDescription
                        })
                        .ToList(),
                    Categories = _dbContext.CategoryGames
                        .Where(cg => cg.GameId == gm.GameId)
                        .Select(cg => new CategoryDto
                        {
                            CategoryId = cg.Category.CategoryId,
                            Name = cg.Category.Name,
                            Description = cg.Category.Description
                        })
                        .ToList()
                })
                .ToListAsync();

            return gameDtos;
        }

        public async Task<GameDto> CreateAsync(GameDto gameDto)
        {
            var game = _mapper.Map<Game>(gameDto);
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
            return gameDto;
        }
    }
}