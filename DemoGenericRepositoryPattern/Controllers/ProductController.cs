using DemoGenericRepositoryPattern.Interfaces;
using DemoGenericRepositoryPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DemoGenericRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Get all
        // need to be added with paging (skip, take)
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListAsync(cancellationToken);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, CancellationToken cancellationToken)
        {
            product.Id = Guid.NewGuid().ToString();
            await _productRepository.AddAsync(product, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Product product, CancellationToken cancellationToken)
        {
            if (id != product.Id)
                return BadRequest();

            await _productRepository.UpdateAsync(product, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
    }

}
