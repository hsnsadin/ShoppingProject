using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Concrete.EntityFramework.Mapping;

namespace Shopping.DAL.Concrete.EntityFramework.Context
{
    public class ShoppingContext:DbContext//context datbase işlemleri takip eden mekanizma.
    {                                     //ORM(şuan entityframework) değişirse o kullandığımız orm contexti ekleriz inherit ederiz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                //connection stringi regeedite yazılması istenebilir.(kayıt defteri düzenleyicisi)13.05 1.video
                //sunucu üzerine çalışırken firmanın tüm projeleri bu sunucu üzerinde olur regate yazılabilir değişken tanımlayıp.
                optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;initial catalog=ShoppingDB;" +
                    "integrated security=True;TrustServerCertificate=true");
                //enviroment ve get enviroment ile web uı da launch settingte devolopment ı açarsak buraya enviromenta bağlanır.
                //launc sttingste pproduction yazarsak canlıya geçer ve get enviroment 2 çalışır. test datayı test database de yaparsın.?

                //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")=="Development")
                //{
                //    optionsBuilder.UseSqlServer("data source=.\\ZRVSQL2008;initial catalog=ShoppingDB;integrated security=True; TrustServerCertificate=true");
                //}

                //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                //{
                //    optionsBuilder.UseSqlServer("data source=.\\ZRVSQL2008;initial catalog=ShoppingDB;integrated security=True; TrustServerCertificate=true");
                //}

                //başka bir database bağlayacaksan providerını indirip kurmamız lazım.
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//burayı sor?
        {
            //modelBuilder.Entity<Product>()
            //    .Property(q=>q.Name).HasMaxLength(50); burayada yazabiliriz mapping ancak tren gibi sıralanır.

            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            //inherit ettiğimiz base sınıf miras alan sınıflar yüklenirken oluşur.
            //migration yapacağım yer DAL olduğu için set as startup yaparız.
            //packet manager console dan DAL seçilir ve nugetten
            //ef core desing dala yüklendikten sonra add migration m1 denir.
            base.OnModelCreating(modelBuilder);
        }
    }
}
