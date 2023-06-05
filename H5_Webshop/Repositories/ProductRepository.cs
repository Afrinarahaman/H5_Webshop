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
            Task<Product> InsertNewProduct(Product product);
            Task<Product> UpdateExistingProduct(int productId, Product product);

            Task<Product> DeleteProductById(int productId);

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
        public async Task<Product> InsertNewProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateExistingProduct(int productId, Product product)
        {
            Product updateProduct = await _context.Product.FirstOrDefaultAsync(product => product.Id == productId);

            if (updateProduct != null)
            {
                updateProduct.Title = product.Title;
                updateProduct.Price = product.Price;
                updateProduct.Description = product.Description;
                updateProduct.Image = product.Image;
                updateProduct.Stock = product.Stock;

                await _context.SaveChangesAsync();

            }

            return updateProduct;
        }

        public async Task<Product> DeleteProductById(int productId)
        {
            Product deleteProduct = await _context.Product.FirstOrDefaultAsync(product => product.Id == productId);

            if (deleteProduct != null)
            {
                _context.Product.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
            return deleteProduct;
        }

    }
    
}
