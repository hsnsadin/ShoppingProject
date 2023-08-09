using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using Shopping.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderMap : BaseMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            //user ıd maxlenght vermiyoruz çünkü başka bir tablonun userından çekiyoruz verirsek
            //bütün userların hepsini max lenght vermek lazım ilişki ve ıd kolonlarını maxta bırakmalıyız.
            //örneğin number tc string tc arasında performans farkı vardır. number int daha hızlı çalışır ve indexlemede long kullanmayı önerilir.
            builder.HasOne(q => q.User).WithMany(q => q.Orders).HasForeignKey(q => q.UserID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(q => q.OrderDetail).WithOne(q => q.Order).HasForeignKey(q => q.OrderId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
