using BoardGame_REST_API.Dtos;

namespace BoardGame_REST_API.Services.Interfaces
{
    public interface IGameService
    {
        Task<bool> UpdateAsync(int id, GameDto gameDto);
        Task<bool> DeleteAsync(int id);
        Task<GameDto> GetByIDAsync(int id);
        Task<IEnumerable<GameDto>> GetAllAsync();
        Task<bool> CreateAsync(GameDto gameDto);
    }
}