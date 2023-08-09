using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.POCO
{
    public class OrderDetail:AuditableEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double? Discount { get; set; }
        public virtual Order Order { get; set; }// foreign key ilişkisi constraint(Kısıtlama) ilişkisi olan tablolar.
        public virtual Product Product { get; set; }
    }
}
