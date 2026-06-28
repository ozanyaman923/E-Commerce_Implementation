using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Herhangi bir entity'nin operasyonları
    public interface IEntityRepository<T> where T : class , IEntity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>>filter = null);
        Task<T> GetAsync(Expression<Func<T,bool>> filter);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
       
    }   
}
