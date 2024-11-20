using AutoMapper;
using BoardGame_REST_API.DbManagement.Entities;
using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoardGame_REST_API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BoardGameDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorService(BoardGameDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AuthorDto> UpdateAsync(int id, AuthorDto AuthorDto)
        {
            var Author = await _dbContext.Authors.AsNoTracking().FirstOrDefaultAsync(g => g.AuthorId == id);
                var a = _mapper.Map<Author>(AuthorDto);

                Author = a;

                _dbContext.Authors.Update(Author);

                await _dbContext.SaveChangesAsync();
            return AuthorDto;

        }

        public async Task<AuthorDto> DeleteAsync(int id)
        {
            var Author = await _dbContext.Authors.FirstOrDefaultAsync(g => g.AuthorId == id);

            _dbContext.Authors.Remove(Author);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(Author);
        }

        public async Task<AuthorDto> GetByIDAsync(int id)
        {
            var AuthorDto = await _dbContext.Authors
                .AsNoTracking()
                .Select(a => new AuthorDto
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    AuthorDescription = a.LastName,
                    Games = _dbContext.AuthorGames
                        .Where(gm => gm.AuthorId == a.AuthorId)         
                        .Select(gm => new GameDto                  
                        {
                            GameId = gm.Game.GameId,
                            Name = gm.Game.Name,
                            Description = gm.Game.Description,
                            TimeOfPlayingInMinutes = gm.Game.TimeOfPlayingInMinutes,
                            Weight = gm.Game.Weight,
                            Score = gm.Game.Score
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync();

            return AuthorDto;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var AuthorDtos = await _dbContext.Authors
                .AsNoTracking()
                .Select(a => new AuthorDto
                {
                    AuthorId = a.AuthorId,
                    FirstName = a.FirstName,
                    AuthorDescription = a.LastName,
                    Games = _dbContext.AuthorGames
                        .Where(gm => gm.AuthorId == a.AuthorId)
                        .Select(gm => new GameDto
                        {
                            GameId = gm.Game.GameId,
                            Name = gm.Game.Name,
                            Description = gm.Game.Description,
                            TimeOfPlayingInMinutes = gm.Game.TimeOfPlayingInMinutes,
                            Weight = gm.Game.Weight,
                            Score = gm.Game.Score
                        })
                        .ToList()
                })
                .ToListAsync();

            return AuthorDtos;
        }

        public async Task<AuthorDto> CreateAsync(AuthorDto AuthorDto)
        {
            var Author = _mapper.Map<Author>(AuthorDto);
            await _dbContext.Authors.AddAsync(Author);
            await _dbContext.SaveChangesAsync();
            return AuthorDto;
        }
    }
}
