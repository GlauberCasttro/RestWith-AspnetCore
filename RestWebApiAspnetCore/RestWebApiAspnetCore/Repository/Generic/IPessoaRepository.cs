using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Repository.Generic
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        List<Pessoa> FindByName(string firstName, string lastName);

    }
}
