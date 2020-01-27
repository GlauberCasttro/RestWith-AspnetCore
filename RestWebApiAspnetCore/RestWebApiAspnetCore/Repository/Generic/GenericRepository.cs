using RestWebApiAspnetCore.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWebApiAspnetCore.Model.Context;

namespace RestWebApiAspnetCore.Repository.Generic
{
    public class GenericRepository<T>  : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return item;
        }
         
        public T FindById(long id)
        {
            return dataset.SingleOrDefault(b => b.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T Update(T item)
        {
            if (!Exist(item.Id)) return null;
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {

                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return result;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? TId)
        {
            return dataset.Any(b => b.Id.Equals(TId));
        }
    }
}
