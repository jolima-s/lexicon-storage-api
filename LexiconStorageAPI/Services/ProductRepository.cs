using LexiconStorageAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LexiconStorageAPI.Services
{
    public class ProductRepository
    {
        private readonly LexiconStorageAPIContext _context;

        public ProductRepository(LexiconStorageAPIContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _context.Products
                .Where(p => p.Category.ToLower() == category.ToLower())
                .ToListAsync();
        }

        public async Task<Product?> GetProduct(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> PutProduct(int? id, Product product)
        {
            if (id != product.Id)
                return false;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                    return false;
                else
                    throw;
            }

            return true;
        }

        public async Task<Product?> PostProduct(Product product)
        {
            _context.Products.Add(product);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return product;
        }

        public async Task<bool> DeleteProduct(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return false;

            _context.Products.Remove(product);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        private bool ProductExists(int? id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
