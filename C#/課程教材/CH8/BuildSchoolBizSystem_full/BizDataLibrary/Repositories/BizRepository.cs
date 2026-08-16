using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BizDataLibrary.Repositories;

public class BizRepository
{
    private readonly DbContext _context;
    public BizRepository(DbContext context)
    {
        _context = context;
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Create<T>(T entity) where T : class
    {
        _context.Entry<T>(entity).State = EntityState.Added;
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Entry(entity).State = EntityState.Modified;
    }
    public void Delete<T>(T entity) where T : class
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }
}
