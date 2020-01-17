using RestWebApiAspnetCore.Model;
using System.Collections.Generic;

namespace RestWebApiAspnetCore.Business
{
    public interface IPessoaBusiness
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(long id);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void Delete(long id);
    }
}
