using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoGenericRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        // Get all
        // need to be added with paging (skip, take)
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetListAsync(cancellationToken);
            return Ok(brands);
        }

        // Get by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(id, cancellationToken);
            if (brand == null)
                return NotFound();
            return Ok(brand);
        }

        // post
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand, CancellationToken cancellationToken)
        {
            brand.Id = Guid.NewGuid().ToString();
            await _brandRepository.AddAsync(brand, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = brand.Id }, brand);
        }

        // update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Brand brand, CancellationToken cancellationToken)
        {
            if (id != brand.Id)
                return BadRequest();

            await _brandRepository.UpdateAsync(brand, cancellationToken);
            return NoContent();
        }

        // delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _brandRepository.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }

}
