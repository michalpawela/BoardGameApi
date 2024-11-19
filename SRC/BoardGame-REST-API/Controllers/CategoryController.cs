using BoardGame_REST_API.Dtos;
using BoardGame_REST_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGame_REST_API.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync([FromBody] CategoryDto categoryDto, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = await _categoryService.UpdateAsync(id, categoryDto);

        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        var isDeleted = await _categoryService.DeleteAsync(id);

        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateAsync([FromBody] CategoryDto categoryDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        bool isCreated = await _categoryService.CreateAsync(categoryDto);

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
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetAsync([FromRoute] int id)
    {
        var category = await _categoryService.GetByIDAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }
}
}
