using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Business.Abstract
{
    public interface IGenericService<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);//linQ c# ın olayıdır.
        Task<IEnumerable<T>> GetALLAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);
        Task<T> AddAsync(T Entity);//change tracking o an hangi işlem yapılacak.

        Task UpdateAsync(T Entity);
        Task RemoveAsync(T Entity);
    }
}
