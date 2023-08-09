using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework.DataManagement
{//gerçek update delete işlemlerini yapıp ırepositoryde deklare ettiğimiz methodların
 //bodylerini yazacağız.
    public class EFRepository<T> : IRepository<T> where T : AuditableEntity
    {
        // bu işlemler context üzerinden takip ettiği için üzerinden gerçekleştiği için context veriririz.
        private readonly DbContext _context;//dışarıdan gelir.
        private readonly DbSet<T> _dbSet;//contextten gelir.


        public EFRepository(DbContext context)//constructır encapsulation için mi yaptık?
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<EntityEntry<T>> AddAsync(T Entity)
        {
            return await _dbSet.AddAsync(Entity);
        }

        public async Task<IEnumerable<T>> GetALLAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties)//Include ile left joinleme yaparız.
                                                                                                                                 //eager loading defaulttur ve inculude parametre ile ek tabloları çağırabiliriz.
        {
            IQueryable<T> query = _dbSet;

            if (Filter != null)
            {
                query = query.Include(Filter);
            }
            if (IncludeProperties.Length > 0)
            {
                foreach (string includeItem in IncludeProperties)
                {
                    query = query.Include(includeItem);
                }
            }
            return await Task.Run(() => query);//query.tolistasync te aynı görevi görür.ancak list kısıtı getirdik. vs.
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;//mecbur dolu olacağı için dönmeyiz null olamaz.
            //query = query.Where(Filter);//buraada ki filterı singleODA içine prdeicate yazabiliriz.sonuç döner.

            if (IncludeProperties.Length > 0)
            {
                foreach (string includeItem in IncludeProperties)
                {
                    query = query.Include(includeItem);
                }
            }
            return await query.SingleOrDefaultAsync(Filter);//birden fazla cevap dönerse hata atması için.
        }

        public async Task RemoveAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Remove(Entity));//remove işlem yapar döner.
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Update(Entity));//nesne zaten elimizde, döndürmeye gerek yok.
        }
    }
}
