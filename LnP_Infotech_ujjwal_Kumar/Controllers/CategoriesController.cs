namespace LnP_Infotech_ujjwal_Kumar.Controllers
{
    using global::LnP_Infotech_ujjwal_Kumar.Models;
    using global::LnP_Infotech_ujjwal_Kumar.Services;
    using Microsoft.AspNetCore.Mvc;
        public class CategoriesController : Controller
        {
            private readonly ICategoryServices _categoryService;

            public CategoriesController(ICategoryServices categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<ActionResult> Index()
            {
                var data = await _categoryService.GetAllCategories();

                return View(data);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<ActionResult> Create(Category category)
            {
                await _categoryService.AddCategory(category);

                return RedirectToAction(nameof(Index));
            }

           
            public async Task<IActionResult> Delete(int id)
            {
                var data = await _categoryService.GetCategoryById(id);

                return View(data);
            }

            [HttpPost, ActionName("Delete")]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
            if (id == 0)
                return BadRequest();

            await _categoryService.DeleteCategory(id);

            return RedirectToAction(nameof(Index));
        }
        }
    }