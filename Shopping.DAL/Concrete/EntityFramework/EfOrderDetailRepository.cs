using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;
using Shopping.Entity.POCO;
using System.Linq.Expressions;

namespace Shopping.DAL.Concrete.EntityFramework
{
    public class EfOrderDetailRepository : EFRepository<OrderDetail>, IOrderDetailRepository
    {
        public EfOrderDetailRepository(DbContext context) : base(context)//?????
        {
        }

      }

}
