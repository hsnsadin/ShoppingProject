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
    public class UserManager:IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<User> GetAsync(Expression<Func<User, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetAsync(Filter, IncludeProperties);

        }

        public async Task<IEnumerable<User>> GetALLAsync(Expression<Func<User, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.UserRepository.GetALLAsync(Filter, IncludeProperties);
        }

        public async Task<User> AddAsync(User Entity)
        {
            await _uow.UserRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task UpdateAsync(User Entity)
        {
            await _uow.UserRepository.UpdateAsync(Entity);//return dönmek zorunda kaldık.
        }

        public async Task RemoveAsync(User Entity)
        {
           await _uow.UserRepository.RemoveAsync(Entity);
        }

        
    }
}
