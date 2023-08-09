using Shopping.DAL.Abstract.DataManagement;
using Shopping.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
        //extra bir method varsa buraya yazarız.
    }

    //syntax ve intelisense kullanmak için resharper kullanılabilir
    //ctrl d seçtiğiniz yeri kopyalar
    //user eklemek için ıuser reposiitory kullanacağız

}
