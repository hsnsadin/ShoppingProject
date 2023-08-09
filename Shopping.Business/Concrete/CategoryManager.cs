using Shopping.Business.Abstract;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _uow;
        public CategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Category> AddAsync(Category Entity)
        {
            await _uow.CategoryRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Category>> GetALLAsync(Expression<Func<Category, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetALLAsync(Filter, IncludeProperties);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CategoryRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Category Entity)
        {
            await _uow.CategoryRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Category Entity)
        {
            await _uow.CategoryRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
