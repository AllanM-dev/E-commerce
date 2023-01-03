using E_CommerceBackend.Entities;
using E_CommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Category : ControllerBase
    {
        private readonly ICategoryService _catService;

        public Category(ICategoryService catService)
        {
            _catService = catService;
        }

        /// <summary>
        /// Get the list of Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CategoryModel> GetCategories()
        {
            return _catService.GetAllCategories();
        }

        /// <summary>
        ///  Retrieve a Category by using its name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name")]
        public CategoryModel? GetCategoryByName(
            [FromQuery] string name
            )
        {
            return _catService.GetCategoryByName(name);
        }

        /// <summary>
        /// Create a new Category
        /// </summary>
        /// <param name="name"></param>
        [HttpPost]
        public void PostCategory(
            [FromQuery] string name
            )
        {
            _catService.CreateCategory(name);
        }
    }
}
