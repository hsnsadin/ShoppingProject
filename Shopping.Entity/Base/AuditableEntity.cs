using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Entity.Base
{
    public class AuditableEntity:BaseEntity// buralar manipüle edilecek, entity framework tarafından güncellenecek.
    {
        public DateTime AddedTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int? AddedUser { get; set; }
        public int UpdatedUser { get; set; }
        //atribute mapping
        [MaxLength(20)]
        //[Required(false,"IP adress")]
        public string CreatedIPAdress { get; set; }
        [MaxLength(20)]
        public string UpdatedIPAdress { get; set; }
        
    }
}
