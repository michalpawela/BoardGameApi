using BoardGame_REST_API.DbManagement;
using BoardGame_REST_API.DbManagement.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BoardGame_REST_API.Dtos;
using System.Threading.Tasks;
using BoardGame_REST_API.Services.Interfaces;

namespace BoardGame_REST_API.Controllers
{

    [Route("game")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] GameDto gameDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var isUpdated = await _gameService.UpdateAsync(id, gameDto);

                if (isUpdated == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var isDeleted = await _gameService.DeleteAsync(id);

                if (isDeleted == null)
                {
                    return NoContent();
                }

                return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GameDto>> CreateAsync([FromBody] GameDto gameDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var isCreated = await _gameService.CreateAsync(gameDto);


                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAllAsync()
        {
            var games = await _gameService.GetAllAsync();

            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetAsync([FromRoute] int id)
        {
            var game = await _gameService.GetByIDAsync(id);

            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }
    }
}