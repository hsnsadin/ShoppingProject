using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Shopping.Business.Abstract;
using Shopping.Entity.POCO;
using Shopping.WebUI.Areas.AdminPanel.Models;

namespace Shopping.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;//constractır

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/Admin/Kategori")]
        public async Task< IActionResult> Index()
        {
            var categories= await  _categoryService.GetALLAsync();
            return View(categories.ToList());
        }
        [HttpPost("/AddCategory")]
        public async Task<IActionResult>  AddCategory(Category category) //pocoda bulunan category nesnesini veririz.
        {
          await  _categoryService.AddAsync(category);
            return Json(new {success=true, message="İşlem Tamamlandı"});
        }

        [HttpPost("/UpdateCategory")]
        public async Task<IActionResult> AddCategory(CategoryViewModel categoryViewModel) //pocoda bulunan category nesnesini veririz.
        {
            var category = await _categoryService.GetAsync(q => q.Guid == categoryViewModel.CategoryGUID);//bu guidi yazmazsak hepsini günceller.

            if(category is not null)
            {
                category.Name = categoryViewModel.CategoryName;
                await _categoryService.UpdateAsync(category);
                return Json(new { success = true, message = "İşlem Tamamlandı" });
            }
            return Json(new { success = false, message = "Hata Oluştu!" });
        }

        [HttpPost("/RemoveCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCategory(Guid categoryGUID)
        {
            var category = await _categoryService.GetAsync(q => q.Guid == categoryGUID);  //adamın silmek istediği kategoriyi önce çağırmak/almak lazım
            await _categoryService.RemoveAsync(category);
            return Json(new { success = true, message = "İşlem Tamamlandı" });
        }
        [HttpGet("/GetCategory/{categoryGUID}")]//Parametrik GET Attribute
        public async Task<IActionResult> GetCategoryDetail(Guid categoryGUID)
        {
            var category=await _categoryService.GetAsync(q=>q.Guid == categoryGUID);

            CategoryViewModel categoryViewModel = new()
            {
                CategoryName = category.Name,
                CategoryGUID= categoryGUID   
            };

            return Json(new { success = true, categoryViewModel });
        }
    }
}
