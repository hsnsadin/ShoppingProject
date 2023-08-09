using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;
using Shopping.Entity.POCO;

namespace Shopping.DAL.Concrete.EntityFramework
{
    public class EfOrderRepository : EFRepository<Order>, IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }
    }
}
