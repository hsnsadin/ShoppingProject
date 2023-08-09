using Microsoft.EntityFrameworkCore;
using Shopping.DAL.Abstract;
using Shopping.DAL.Concrete.EntityFramework.DataManagement;
using Shopping.Entity.POCO;

namespace Shopping.DAL.Concrete.EntityFramework
{
    public class EfCategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
        }
    }
}
