using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.POCO
{
    public class Product:AuditableEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string Name { get; set; }
        public int CategoryID { get; set; }//category siz ürün eklemek istersek int? deriz nullable olur.
        public virtual Category Category { get; set; }//neden?
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
