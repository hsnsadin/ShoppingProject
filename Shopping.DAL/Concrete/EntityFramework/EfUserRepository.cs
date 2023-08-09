using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;
using Shopping.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework
{
    public class EfUserRepository : EFRepository<User>, IUserRepository
    {
        public EfUserRepository(DbContext context) : base(context)
        {
        }
    }
}
