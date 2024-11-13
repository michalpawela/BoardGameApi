using BoardGame_REST_API.Dtos;

namespace BoardGame_REST_API.Services.Interfaces
{
    public class IAuthorService
    {
        Task<bool> UpdateAsync(int id, AuthorDto AuthorDto);
        Task<bool> DeleteAsync(int id);
        Task<AuthorDto> GetByIDAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<bool> CreateAsync(AuthorDto AuthorDto);
    }
}
