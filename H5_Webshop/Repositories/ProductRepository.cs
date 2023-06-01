using H5_Webshop.Database;
using H5_Webshop.DTOs.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Repositories
{

  
        public interface IProductRepository
        {
            Task<List<Product>> SelectAllProducts();
            Task<Product> SelectProductById(int productId);

            Task<List<Product>> GetProductsByCategoryId(int categoryId);
            
        }
        public class ProductRepository : IProductRepository
        {
            private readonly WebshopApiContext _context;

            public ProductRepository(WebshopApiContext context)
            {
                _context = context;
            }



            public async Task<List<Product>> SelectAllProducts()
            {
                return await _context.Product
                    .Include(a => a.Category)
                    .OrderBy(a => a.CategoryId)

                    .ToListAsync();
            }

            public async Task<Product> SelectProductById(int productId)
            {
                return await _context.Product
                    .Include(a => a.Category)
                    .OrderBy(a => a.CategoryId)
                    .FirstOrDefaultAsync(product => product.Id == productId);
            }
            public async Task<List<Product>> GetProductsByCategoryId(int CategoryId)
            {

                return await _context.Product
                    .Include(a => a.Category)
                    .OrderBy(a => a.CategoryId)
                    .Where(a => a.CategoryId==CategoryId)
                    .ToListAsync();
            }
        }
    
}
