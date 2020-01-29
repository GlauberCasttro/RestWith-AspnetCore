using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository;
using RestWebApiAspnetCore.Repository.Generic;

namespace RestWebApiAspnetCore.Business.Implementation
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {

        private IRepository<Pessoa> _repository;

        public PessoaBusinessImpl(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            return _repository.Create(pessoa);
        }

        public Pessoa FindById(long id)
        {

            return _repository.FindById(id);

        }

        public List<Pessoa> FindAll()
        {

            return _repository.FindAll();

        }
        
        public Pessoa Update(Pessoa pessoa)
        {

            return _repository.Update(pessoa);
        }
        public void Delete(long id)
        {

            _repository.Delete(id);
        }

    }

}
