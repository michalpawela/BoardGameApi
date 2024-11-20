using BoardGame_REST_API.Dtos;

namespace BoardGame_REST_API.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<AuthorDto> UpdateAsync(int id, AuthorDto AuthorDto);
        Task<AuthorDto> DeleteAsync(int id);
        Task<AuthorDto> GetByIDAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> CreateAsync(AuthorDto AuthorDto);
    }
}
