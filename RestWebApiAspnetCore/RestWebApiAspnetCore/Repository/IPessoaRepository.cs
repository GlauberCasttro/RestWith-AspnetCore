using RestWebApiAspnetCore.Model;
using System.Collections.Generic;

namespace RestWebApiAspnetCore.Repository
{
    public interface IPessoaRepository
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindById(long id);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void Delete(long id);
        bool Exist(long? pessoaId);

    }
}
