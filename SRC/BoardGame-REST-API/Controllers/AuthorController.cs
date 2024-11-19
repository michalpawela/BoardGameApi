using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardAuthor_REST_API.Controllers
{
    [Route("author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] AuthorDto authorDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = await _authorService.UpdateAsync(id, authorDto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            var isDeleted = await _authorService.DeleteAsync(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAsync([FromBody] AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isCreated = await _authorService.CreateAsync(authorDto);

            if (isCreated)
            {
                return StatusCode(201);
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAsync()
        {
            var authors = await _authorService.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAsync([FromRoute] int id)
        {
            var author = await _authorService.GetByIDAsync(id);

            if (author is null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
