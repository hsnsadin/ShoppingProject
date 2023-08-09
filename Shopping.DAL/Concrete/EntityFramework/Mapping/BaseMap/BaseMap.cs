using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shopping.DAL.Concrete.EntityFramework.Mapping.BaseMap
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        // fluent mapping iki farklı property tanımlama yoludur ya fluent ya attribute yapılır.
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Guid).ValueGeneratedOnAdd(); //GUİD kendine has bir key üretir ve valuegen ile her save change de bir tane basar.
            builder.Property(q => q.Id).ValueGeneratedOnAdd();
            //builder.Property(q => q.CreatedIPAdress).HasMaxLength(20).IsRequired;
            //mapler remove migration ile en son migrate i kaldırır.
            //migrosyonları packege consoledan sil. m1 silmeden m2 i silemezsin.
            //m2 oluştu update-database m1 dersek m1 döneriz sonra m2 sileriz.
            //SQL de back up 
        }
    }
}
