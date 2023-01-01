using E_CommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Category : ControllerBase
    {
        readonly ICategoryService _catService;

        public Category(ICategoryService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public IEnumerable<Entities.Category> GetCategories()
        {
            return _catService.GetAllCategories();
        }

        [HttpGet("name")]
        public Entities.Category? GetCategoryByName(
            [FromQuery] string name
            )
        {
            return _catService.GetCategoryByName(name);
        }

        [HttpPost]
        public void PostCategory(
            [FromQuery] string name
            )
        {
            _catService.CreateCategory(name);
        }
    }
}
