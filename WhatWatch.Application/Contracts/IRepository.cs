using System.Linq.Expressions;

namespace WhatWatch.Application.Contracts;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    //Task<T> GetAllAsync();
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);

    Task<T> AddAsync(T obj);

    Task<T> UpdateAsync(T obj);

    Task DeleteAsync(Expression<Func<T, bool>> predicate);

}
