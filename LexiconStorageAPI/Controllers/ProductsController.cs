using LexiconStorageAPI.DTOs;
using LexiconStorageAPI.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;
    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
    {
        var product = await _productService.GetProductById(id);

        if (product == null)
            return NotFound();

        return product;
    }

    // PUT: api/products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int? id, UpdateProductDto updateProductDto)
    {
        if (id != updateProductDto.Id)
            return BadRequest();

        var result = await _productService.UpdateProduct(id, updateProductDto);

        if (!result)
            return NotFound();

        return NoContent();
    }

    // POST: api/products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ProductDto>> PostProduct(CreateProductDto createProductDto)
    {
        var result = await _productService.CreateProduct(createProductDto);

        if (result == null)
            return BadRequest();

        return CreatedAtAction("GetProduct", new { id = result.Id }, result);
    }

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int? id)
    {
        var response = await _productService.DeleteProduct(id);

        if (!response)
            return NotFound();

        return NoContent();
    }

    
}
