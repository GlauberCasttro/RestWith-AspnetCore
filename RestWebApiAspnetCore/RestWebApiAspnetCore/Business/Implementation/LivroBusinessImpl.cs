using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository;

namespace RestWebApiAspnetCore.Business.Implementation
{
    public class LivroBusinessImpl : ILivroBusiness

    {
        private ILivroRepository _repository;

        public LivroBusinessImpl(ILivroRepository repository)
        {
            _repository = repository;
        }
        public Livro Create(Livro livro)
        {
           return _repository.Create(livro);
        }

     

        public Livro FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Livro> FindAll()
        {
            return _repository.FindAll();
        }

        public Livro Update(Livro livro)
        {
            return _repository.Update(livro);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
