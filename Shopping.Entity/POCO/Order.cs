using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.POCO
{
    public class Order:AuditableEntity
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }
        public virtual IEnumerable<OrderDetail>OrderDetail { get; set; } //Ienumarable olduğu için many
        public int UserID { get; set; }
        public virtual User User { get; set; }//bu ise has one 

    }
}
