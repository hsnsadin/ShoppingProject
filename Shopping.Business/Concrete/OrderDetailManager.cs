﻿using Shopping.Business.Abstract;
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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IUnitOfWork _uow;
        public OrderDetailManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OrderDetail> AddAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<OrderDetail>> GetALLAsync(Expression<Func<OrderDetail, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.OrderDetailRepository.GetALLAsync(Filter, IncludeProperties);
        }

        public async Task<OrderDetail> GetAsync(Expression<Func<OrderDetail, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.OrderDetailRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(OrderDetail Entity)
        {
            await _uow.OrderDetailRepository.RemoveAsync(Entity);
        }

        public async Task UpdateAsync(OrderDetail Entity)
        {
             await _uow.OrderDetailRepository.UpdateAsync(Entity);
        }
    }
}