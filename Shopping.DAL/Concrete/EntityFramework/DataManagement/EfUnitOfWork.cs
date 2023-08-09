using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopping.DAL.Abstract;
using Shopping.DAL.Abstract.DataManagement;
using Shopping.DAL.Concrete.EntityFramework.Context;
using Shopping.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext _shoppingContext;//save cahnage context üzerine çalışır.
        private readonly IHttpContextAccessor _httpContextAccessor;//bu proje içerisinde client hangi adrese gönderdi
                                                                   //body ne var ıp adresi nedir banlama işlemi contexttir. sunucu
                                                                   //üzerinde çalışır, hangi adrese gitmek requesti atmış görebiliriz.
        public EfUnitOfWork(ShoppingContext shoppingContext, IHttpContextAccessor httpContextAccessor)
        {
            _shoppingContext = shoppingContext;
            _httpContextAccessor = httpContextAccessor;

            UserRepository = new EfUserRepository(_shoppingContext);
            ProductRepository = new EfProductRepository(_shoppingContext);
            OrderRepository = new EfOrderRepository(_shoppingContext);
            OrderDetailRepository = new EfOrderDetailRepository(_shoppingContext);
            CategoryRepository = new EfCategoryRepository(_shoppingContext);
        }

        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailRepository OrderDetailRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public async ValueTask DisposeAsync()
        {
            await _shoppingContext.DisposeAsync();
        }

        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<AuditableEntity> item in _shoppingContext.ChangeTracker.Entries<AuditableEntity>())
            {//insert anında update veya added time ını if le öğrenip dönüp yazacağız.
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdateTime = DateTime.Now;
                    item.Entity.AddedUser = 1;//kayıtlı userıd parametresi yok oluşturmadığımız için bir deriz sonra gireceğiz.
                    item.Entity.UpdatedUser = 1;
                    item.Entity.CreatedIPAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPAdress=_httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    //newletme yapmayız dışarıdan gelecek bu.
                    //product ekledik ancak göstermeyeceğiz o zaman base entittyden boolean yapar
                    //is active ni null dersek.
                    if (item.Entity.IsActive is null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;

                }
                else if (item.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdateTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }

            }
            return await _shoppingContext.SaveChangesAsync();
        }
    }
}
