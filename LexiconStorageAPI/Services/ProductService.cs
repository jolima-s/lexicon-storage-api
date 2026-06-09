using LexiconStorageAPI.DTOs;
using LexiconStorageAPI.Entities;

namespace LexiconStorageAPI.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Count = p.Count,
                Description = p.Description
            });
        }

        public async Task<ProductDto?> GetProductById(int? id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Count = product.Count,
                Description = product.Description
            };
        }

        public async Task<ProductDto?> CreateProduct(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Category = createProductDto.Category,
                Shelf = createProductDto.Shelf,
                Count = createProductDto.Count,
                Description = createProductDto.Description
            };

            var createdProduct = await _productRepository.PostProduct(product);

            if (createdProduct == null)
                return null;

            return new ProductDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Price = createdProduct.Price,
                Count = createdProduct.Count,
                Description = createdProduct.Description
            };
        }

        public async Task<bool> UpdateProduct(int? id, UpdateProductDto updateProductDto)
        {
            var product = new Product
            {
                Id = updateProductDto.Id,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                Category = updateProductDto.Category,
                Shelf = updateProductDto.Shelf,
                Count = updateProductDto.Count,
                Description = updateProductDto.Description
            };

            return await _productRepository.PutProduct(id, product);
        }

        public async Task<bool> DeleteProduct(int? id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null)
                return false;

            return await _productRepository.DeleteProduct(id);
        }
    }
}
