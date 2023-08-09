using Shopping.Business.Abstract;
using Shopping.Business.Concrete;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.DAL.Concrete.EntityFramework.Context;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;

var builder = WebApplication.CreateBuilder(args);//olu�turdu�umuz servisler haz�rda bekler web application ile.

//21 haziran 1.dersi dk.33 �ok �enmli
//blank page bulup html dosyas�n�n i�indekileri kopyalar�z ve shared i�ine bir view olu�tururuz use layoutun tikini kald�r�r�z ve kodlar�n hepsini buraya yerle�tiririz. sonra css html ve jsleri wwwroot a ekleriz.

//web application builder hangi servisi aya�a kald�rmak istiyorsak onu buraya yazarak kald�r�r�z.
//aya�a kald�rd���m�z servisleri use larla kullan�r�z.

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAntiforgery();//request in sadece bulundu�u sayfadan gelmesini istedi�imiz i�in farkl� bir adresten request gelmemesi ve haclenmemek i�in yapar�z.
builder.Services.AddDbContext<ShoppingContext>();
builder.Services.AddScoped<IUnitOfWork,EfUnitOfWork>();
builder.Services.AddScoped<ICategoryService, CategoryManager>(); //Constructer dan � category service istemi�iz.-dependency injection lifetime se�enekleri.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())//test k�sm�   
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsProduction())//canl� k�sm�
{
    
}

app.UseHttpsRedirection();//?
app.UseStaticFiles();//wwwroot olay�

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{area:AdminPanel}/{controller=Home}/{action=Index}");//ilk hangi sayfa y�klenecek�i belirler.

//app.UseEndpoints(endpoints =>// adres, var�� noktas� anlam�na gelir endpoint. fluent mapping
//{

//    endpoints.MapAreaControllerRoute(
//        name: "default",
//        areaName: "AdminPanel",
//        pattern: "Admin/Anasayfa",//browser iste�i
//        defaults: new { action = "Index", controller = "Home" }
//        );


//    endpoints.MapAreaControllerRoute(
//    name: "GetProducts",
//    areaName: "AdminPanel",
//    pattern: "Admin/Urunler",//browser iste�i
//    defaults: new { action = "GetProducts", controller = "Product" }
//    );


//});


app.Run();
