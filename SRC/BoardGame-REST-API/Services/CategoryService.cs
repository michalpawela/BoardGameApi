using AutoMapper;
using BoardGame_REST_API.DbManagement.Entities;
using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoardGame_REST_API.Services
{
        public class CategoryService : ICategoryService
        {
            private readonly BoardGameDbContext _dbContext;
            private readonly IMapper _mapper;

            public CategoryService(BoardGameDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<bool> UpdateAsync(int id, CategoryDto CategoryDto)
            {
                var Category = await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(g => g.CategoryId == id);
                if (Category is null)
                {
                    return false;
                }
                else
                {
                    var gm = _mapper.Map<Category>(CategoryDto);

                    Category = gm;

                    _dbContext.Categories.Update(Category);

                    await _dbContext.SaveChangesAsync();
                    return true;
                }

            }

            public async Task<bool> DeleteAsync(int id)
            {
                var Category = await _dbContext.Categories.FirstOrDefaultAsync(g => g.CategoryId == id);
                if (Category is null) return false;

                _dbContext.Categories.Remove(Category);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            public async Task<CategoryDto> GetByIDAsync(int id)
            {
                var CategoryDto = await _dbContext.Categories
                    .AsNoTracking()
                    .Select(a => new CategoryDto
                    {
                        CategoryId = a.CategoryId,
                        Name = a.Name,
                        Description = a.Description,
                        Games = _dbContext.CategoryGames
                            .Where(gm => gm.CategoryId == a.CategoryId)
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

                return CategoryDto;
            }

            public async Task<IEnumerable<CategoryDto>> GetAllAsync()
            {
                var CategoryDtos = await _dbContext.Categories
                    .AsNoTracking()
                    .Select(a => new CategoryDto
                    {
                        CategoryId = a.CategoryId,
                        Description = a.Description,
                        Name = a.Name,
                        Games = _dbContext.CategoryGames
                            .Where(gm => gm.CategoryId == a.CategoryId)
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

                return CategoryDtos;
            }

            public async Task<bool> CreateAsync(CategoryDto CategoryDto)
            {
                var Category = _mapper.Map<Category>(CategoryDto);
                await _dbContext.Categories.AddAsync(Category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
}
