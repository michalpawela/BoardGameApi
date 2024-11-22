using Common.Dtos;

namespace BoardGame_REST_API.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameDto> UpdateAsync(int id, GameDto gameDto);
        Task<GameDto> DeleteAsync(int id);
        Task<GameDto> GetByIDAsync(int id);
        Task<IEnumerable<GameDto>> GetAllAsync();
        Task<GameDto> CreateAsync(GameDto gameDto);
    }
}