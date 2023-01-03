using E_CommerceBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceBackend.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(MyDbContext context)
            :base(context)
        {

        }

        /// <summary>
        /// Get Category with a specific name
        /// </summary>
        /// <param name="categoryName">Category Name</param>
        public CategoryModel? GetCategoryByName(string categoryName)
        {
            return context.Set<CategoryModel>().AsNoTracking().FirstOrDefault(cat => cat.Name == categoryName);
        }
    }
}
