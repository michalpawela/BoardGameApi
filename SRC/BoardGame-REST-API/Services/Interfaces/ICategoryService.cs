using Common.Dtos;

namespace BoardGame_REST_API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> UpdateAsync(int id, CategoryDto categoryDto);
        Task<CategoryDto> DeleteAsync(int id);
        Task<CategoryDto> GetByIDAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
    }
}
