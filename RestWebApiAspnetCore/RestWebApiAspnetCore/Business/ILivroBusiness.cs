using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Business
{
     public interface ILivroBusiness 
    {
        Livro Create(Livro livro);
        Livro FindById(long id);
        List<Livro> FindAll();
        Livro Update(Livro livro);
        void Delete(long id);
    }
}
