using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.POCO
{
    public class User:AuditableEntity// Veritabanında ki tabloları temsil eder.
    {
        public User()
        {
            Orders = new HashSet<Order>();//user.order diyerek siparişlere ulaşacağız.
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public virtual IEnumerable<Order>Orders { get; set; }
    }
}
