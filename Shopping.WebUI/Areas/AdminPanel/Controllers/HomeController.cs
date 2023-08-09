using Microsoft.AspNetCore.Mvc;

namespace Shopping.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")] //attribute mapping:maprouting yapmazsak bunu yazarız Area-httpget birlikte kullanılır.
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Anasayfa")] //attribute mapping
        public IActionResult Index()//buraya istek/Request göndeririz. Requestin metotları; POST-GET-PUT-DELLETE en çok kullanılanlar.Default olarak bir action tepesinde attribute belirtilmemişse default olarak GET tir.
        {
            return View();
            //return view("hasan"); dersek hasan isimli csj view dosyası arar.
        }
    }
}
