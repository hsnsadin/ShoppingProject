using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using Shopping.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework.Mapping
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");//tablo ismini her zaman ver.yoksa kendi verir.
            builder.Property(q => q.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(q => q.LastName).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Password).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(100);
            builder.Property(q => q.Adress).HasMaxLength(200);
            builder.Property(q => q.Phone).HasMaxLength(20).IsRequired();
            //builder.HasMany(q=>q.Orders).WithOne(q=q=>q.User).HasForeignKey(q=>q.UserId).OnDelete(DeleteBehavior.Cascade);
            //yukarıda tanımlanan foreign key ilişkisi bire çok olarak oluşturuldu.
            //ya burada tanımlarız ya da 



        }
    }
}
