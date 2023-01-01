using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly LibraryContext _libraryContext;
        public CategoryRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public void CreateCategory(string categoryName)
        {
            Category newCategory = new Category() { Name = categoryName, Products = new List<Product>() };
            _libraryContext.Categories.Add(newCategory);
            _libraryContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _libraryContext.Categories;
        }

        public Category? GetCategoryByName(string categoryName)
        {
            return _libraryContext.Categories.FirstOrDefault(cat => cat.Name == categoryName);
        }
    }
}
