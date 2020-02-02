using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Data.Converters;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository;
using RestWebApiAspnetCore.Repository.Generic;

namespace RestWebApiAspnetCore.Business.Implementation
{
    public class LivroBusinessImpl : ILivroBusiness

    {
        //private ILivroRepository _repository;

        private  IRepository<Livro> _repository;
        private readonly LivroConverter _convert;

        public LivroBusinessImpl(IRepository<Livro> repository)
        {
            _repository = repository;
            _convert = new LivroConverter();
        }
        public LivroVO Create(LivroVO livro)
        {
            var livroEntity = _convert.Parse(livro);
            livroEntity=  _repository.Create(livroEntity);
            return _convert.Parse(livroEntity);
        }

     

        public LivroVO FindById(long id)
        {
            return _convert.Parse(_repository.FindById(id));
        }

        public List<LivroVO> FindAll()
        {
            return _convert.ParseList(_repository.FindAll());
        }

        public LivroVO Update(LivroVO livro)
        {
            var livroEntity = _convert.Parse(livro);
            livroEntity = _repository.Update(livroEntity);
            return _convert.Parse(livroEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
