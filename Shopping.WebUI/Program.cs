using Shopping.Business.Abstract;
using Shopping.Business.Concrete;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.DAL.Concrete.EntityFramework.Context;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;

var builder = WebApplication.CreateBuilder(args);//oluþturduðumuz servisler hazýrda bekler web application ile.

//21 haziran 1.dersi dk.33 çok öenmli
//blank page bulup html dosyasýnýn içindekileri kopyalarýz ve shared içine bir view oluþtururuz use layoutun tikini kaldýrýrýz ve kodlarýn hepsini buraya yerleþtiririz. sonra css html ve jsleri wwwroot a ekleriz.

//web application builder hangi servisi ayaða kaldýrmak istiyorsak onu buraya yazarak kaldýrýrýz.
//ayaða kaldýrdýðýmýz servisleri use larla kullanýrýz.

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery();//request in sadece bulunduðu sayfadan gelmesini istediðimiz için farklý bir adresten request gelmemesi ve haclenmemek için yaparýz.
builder.Services.AddDbContext<ShoppingContext>();
builder.Services.AddScoped<IUnitOfWork,EfUnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>(); //Constructer dan ý category service istemiþiz.-dependency injection lifetime seçenekleri.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//test kýsmý   
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsProduction())//canlý kýsmý
{
    
}

app.UseHttpsRedirection();//?
app.UseStaticFiles();//wwwroot olayý

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{area:AdminPanel}/{controller=Home}/{action=Index}");//ilk hangi sayfa yüklenecekði belirler.

//app.UseEndpoints(endpoints =>// adres, varýþ noktasý anlamýna gelir endpoint. fluent mapping
//{

//    endpoints.MapAreaControllerRoute(
//        name: "default",
//        areaName: "AdminPanel",
//        pattern: "Admin/Anasayfa",//browser isteði
//        defaults: new { action = "Index", controller = "Home" }
//        );


//    endpoints.MapAreaControllerRoute(
//    name: "GetProducts",
//    areaName: "AdminPanel",
//    pattern: "Admin/Urunler",//browser isteði
//    defaults: new { action = "GetProducts", controller = "Product" }
//    );


//});


app.Run();
