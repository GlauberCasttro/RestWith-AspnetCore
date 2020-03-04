using RestWebApiAspnetCore.Data.Converters;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using Tapioca.HATEOAS.Utils;

namespace RestWebApiAspnetCore.Business.Implementation
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {

        private IPessoaRepository _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImpl(IPessoaRepository repository)
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

        
       public List<PessoaVO> FindByName(string firstName, string lastName)
       {
           return _converter.ParseList(_repository.FindByName(firstName, lastName));
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

        public PagedSearchDTO<PessoaVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            string query = @"select * from pessoa p where 1=1 ";
            if (!string.IsNullOrEmpty(name))
            {
                query += $"and p.nome like '%{name}%'";
                query += $"order by p.nome {sortDirection} limit {pageSize} offset {page}";

            }

            string countQuery = @"select count(*) from pessoa p where 1 = 1 ";
            if (!string.IsNullOrEmpty(name))
            {
                countQuery += $"and p.nome like '%{name}%'";
                //countQuery += $"order by p.nome{sortDirection} limit {pageSize} offset{page}";

            }

            var pessoas = _repository.FindWithPagedSearch(query);
            int totalResult = _repository.GetCount(countQuery);
            return new PagedSearchDTO<PessoaVO>
            {
                CurrentPage = page,
                List = _converter.ParseList(pessoas),
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResult
            };
        }

    }
}