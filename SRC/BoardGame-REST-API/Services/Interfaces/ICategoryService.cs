using BoardGame_REST_API.Dtos;

namespace BoardGame_REST_API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> UpdateAsync(int id, CategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);
        Task<CategoryDto> GetByIDAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<bool> CreateAsync(CategoryDto categoryDto);
    }
}
