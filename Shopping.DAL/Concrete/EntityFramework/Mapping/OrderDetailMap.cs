using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using Shopping.Entity.POCO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasOne(q => q.Product).WithMany(q => q.OrderDetails).HasForeignKey(q => q.ProductId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
