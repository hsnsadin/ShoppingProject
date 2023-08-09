using Microsoft.AspNetCore.Mvc;

namespace Shopping.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        [HttpGet("/Admin/Urunler")]
        public IActionResult GetProducts() 
        {
            //return Json(new {Data="get products sayfası json result döndü"}); //eğer json tipinde dönmesini istersek sayfanın bu kodu kullanırız.
            return View();
        }
       
    }
}
