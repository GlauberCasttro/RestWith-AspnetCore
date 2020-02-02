using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Data.Converter;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Data.Converters
{
    public class PessoaConverter : IParser<PessoaVO,Pessoa>, IParser<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origin)
        {
            if(origin == null)
                return  null;
            return new Pessoa()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Endereco = origin.Endereco,
                Genero = origin.Genero,
                Sobrenome = origin.Sobrenome,
                Atualizacao = origin.Atualizacao
             

            };
        }

        public PessoaVO Parse(Pessoa origin)
        {
            if (origin == null)
                return null;
            return new PessoaVO()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Endereco = origin.Endereco,
                Genero = origin.Genero,
                Sobrenome = origin.Sobrenome,
                Atualizacao = origin.Atualizacao

            };
        }

        public List<PessoaVO> ParseList(List<Pessoa> origin)
        {
            if(origin == null) return new List<PessoaVO>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Pessoa> ParseList(List<PessoaVO> origin)
        {
           if(origin == null) return new List<Pessoa>();
           return origin.Select(item => Parse(item)).ToList();
        }

    }
}
