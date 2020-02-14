using RestWebApiAspnetCore.Data.Converters;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository.Generic;
using System;
using System.Collections.Generic;

namespace RestWebApiAspnetCore.Business.Implementation
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {

        private IRepository<Pessoa> _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImpl(IRepository<Pessoa> repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }
        public PessoaVO Create(PessoaVO pessoa)
        {
            // pessoa.Atualizacao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
           // pessoa.DataCriacao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Create(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public PessoaVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PessoaVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PessoaVO Update(PessoaVO pessoa)

        {
            pessoa.Atualizacao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Update(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}