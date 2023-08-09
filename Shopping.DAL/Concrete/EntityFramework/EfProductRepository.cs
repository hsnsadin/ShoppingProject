using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;
using Shopping.Entity.POCO;

namespace Shopping.DAL.Concrete.EntityFramework
{
    public class EfProductRepository:EFRepository<Product>,IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {
        }
    }
}
