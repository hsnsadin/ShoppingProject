using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }//veri tabanı kendi verir, insert anında oluşur
        public Guid Guid { get; set; }=Guid.NewGuid();
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
