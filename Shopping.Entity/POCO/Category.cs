using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.POCO
{
    public class Category:AuditableEntity
    {
        public Category()//IEnuberable girdiğimize göre constract yazmamız lazım istersek dönmemiz için.
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }//IEnumerable ıcollection list döner.Icollection ıenumerable(base tip) dan türer.
    }                                                             //HashSet sınıfı, benzersiz elemanların koleksiyonunu  temsil eder
                                                                  //hashset sınıfı, elemanları aramak ve silmek için de kullanışlı yöntemler içerir ve hızlıdır.
}
