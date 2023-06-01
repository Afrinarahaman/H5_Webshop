using H5_Webshop.DTOs;
using H5_Webshop.DTOs.Entities;
using H5_Webshop.Repositories;

namespace H5_Webshop.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllProducts();
        Task<ProductResponse> GetProductById(int productId);
        Task<List<ProductResponse>> GetProductsByCategoryId(int categoryId);
      

    }
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository=categoryRepository;
        }
        public async Task<List<ProductResponse>> GetAllProducts()
        {
            List<Product> products = await _productRepository.SelectAllProducts();

            return products.Select(product => MapProductToProductResponse(product)).ToList();

        }
        public async Task<ProductResponse> GetProductById(int productId)
        {
            Product product = await _productRepository.SelectProductById(productId);

            if (product != null)
            {

                return MapProductToProductResponse(product);
            }
            return null;
        }

        public async Task<List<ProductResponse>> GetProductsByCategoryId(int categoryId)
        {
            List<Product> products = await _productRepository.GetProductsByCategoryId(categoryId);


            return products.Select(product => MapProductToProductResponse(product)).ToList();
        }

            private ProductResponse MapProductToProductResponse(Product product)
            {

                return new ProductResponse
                {
                    Id = product.Id,
                    Title=product.Title,
                    Price=product.Price,
                    Description=product.Description,
                    Image=product.Image,
                    Stock=product.Stock,
                    CategoryId=product.CategoryId,

                    Category = new ProductCategoryResponse
                    {
                        Id = product.Category.Id,
                        CategoryName = product.Category.CategoryName

                    }
                };
            }
        }
}
