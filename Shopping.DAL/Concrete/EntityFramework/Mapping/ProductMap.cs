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
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(q => q.Name).HasMaxLength(1000).IsRequired();
            builder.HasOne(q => q.Category).WithMany(q => q.Products).HasForeignKey(q => q.CategoryID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
