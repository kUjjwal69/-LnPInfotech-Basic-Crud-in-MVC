using LnP_Infotech_ujjwal_Kumar.Models;
using LnP_Infotech_ujjwal_Kumar.Services;
using Microsoft.AspNetCore.Mvc;

namespace LnP_Infotech_ujjwal_Kumar.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productService;
        private readonly ICategoryServices _categoryService;
        private readonly IProductCategoryService _pcService;

        public ProductsController(
            IProductServices productService,
            ICategoryServices categoryService,
            IProductCategoryService pcService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _pcService = pcService;
        }

        
        public async Task<IActionResult> Index(
            string? search,
            int? categoryId,
            int? minQty,
            decimal? maxPrice,
            int page = 1)
        {
            int pageSize = 5;

            var result = await _productService.GetFilteredProducts(
                search,
                categoryId,
                minQty,
                maxPrice,
                page,
                pageSize);

            ViewBag.TotalCount = result.TotalCount;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            ViewBag.Categories = await _categoryService.GetAllCategories();

            return View(result.Data);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, int[] categoryIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategories();
                return View(product);
            }

            await _productService.Add(product, categoryIds);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.Get(id);

            if (product == null)
                return NotFound();

            ViewBag.Categories = await _categoryService.GetAllCategories();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, int[] categoryIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryService.GetAllCategories();
                return View(product);
            }

            await _productService.Update(product);

            await _pcService.UpdateMapping(
                product.ProductId, categoryIds);

            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.Get(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
