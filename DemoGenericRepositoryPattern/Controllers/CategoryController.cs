using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DemoGenericRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Get all
        // need to be added with paging (skip, take)
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetListAsync(cancellationToken);
            return Ok(categories);
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        // create
        [HttpPost]
        public async Task<IActionResult> Create(Category category, CancellationToken cancellationToken)
        {
            category.Id = Guid.NewGuid().ToString();
            await _categoryRepository.AddAsync(category, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        // update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Category category, CancellationToken cancellationToken)
        {
            if (id != category.Id)
                return BadRequest();

            await _categoryRepository.UpdateAsync(category, cancellationToken);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }

}
