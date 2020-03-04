using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model.Base;

namespace RestWebApiAspnetCore.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exist(long? TId);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
