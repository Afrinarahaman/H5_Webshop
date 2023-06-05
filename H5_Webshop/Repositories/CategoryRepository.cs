using H5_Webshop.Database;
using H5_Webshop.DTOs.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Repositories
{
   
    
        public interface ICategoryRepository
        {
            Task<List<Category>> SelectAllCategories();
            Task<Category> SelectCategoryById(int categoryId);
            Task<List<Category>> SelectAllCategoriesWithoutProducts();
            // Task<List<Category>> SelectCategoriesByProductId(int productId);
            Task<Category> InsertNewCategory(Category category);
            Task<Category> UpdateExistingCategory(int categoryId, Category category);
            Task<Category> DeleteCategoryById(int categoryId);

        }
        public class CategoryRepository: ICategoryRepository
        {
            private readonly WebshopApiContext _context;

            public CategoryRepository(WebshopApiContext context)
            {
                _context = context;
            }
            public async Task<List<Category>> SelectAllCategories()
            {
                return await _context.Category
                    .Include(b => b.Products)

                    .ToListAsync();
            }
            public async Task<Category> SelectCategoryById(int categoryId)
            {
                return await _context.Category
                    .Include(a => a.Products)
                    .FirstOrDefaultAsync(category => category.Id == categoryId);
            }

            public async Task<List<Category>> SelectAllCategoriesWithoutProducts()
            {
                return await _context.Category
                            .ToListAsync();
            }

            public async Task<Category> InsertNewCategory(Category category)
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }
            public async Task<Category> UpdateExistingCategory(int categoryId, Category category)
            {
                Category updateCategory = await _context.Category.FirstOrDefaultAsync(category => category.Id == categoryId);
                if (updateCategory != null)
                {
                    updateCategory.CategoryName = category.CategoryName;

                    await _context.SaveChangesAsync();
                }
                return updateCategory;
            }
            public async Task<Category> DeleteCategoryById(int categoryId)
            {
                Category deleteCategory = await _context.Category.FirstOrDefaultAsync(category => category.Id == categoryId);
                if (deleteCategory != null)
                {

                    _context.Remove(deleteCategory);
                    await _context.SaveChangesAsync();
                }
                return deleteCategory;
            }


        }
    
}
