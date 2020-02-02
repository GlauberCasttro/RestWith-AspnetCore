using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Data.Converter;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Data.Converters
{
    public class LivroConverter : IParser<LivroVO, Livro>, IParser<Livro, LivroVO>
    {
        public Livro Parse(LivroVO origin)
        {
            if (origin == null)
                return null;
            return new Livro()
            {
                Id = origin.Id,
                Autor = origin.Autor,
                DataLancamento = origin.DataLancamento,
                Titulo = origin.Titulo,
                preco = origin.preco


            };
        }

        public List<LivroVO> ParseList(List<Livro> origin)
        {

            if (origin == null) return new List<LivroVO>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public LivroVO Parse(Livro origin)
        {
            if (origin == null)
                return null;
            return new LivroVO()
            {
                Id = origin.Id,
                Autor = origin.Autor,
                DataLancamento = origin.DataLancamento,
                Titulo = origin.Titulo,
                preco = origin.preco
                
            };
        }

        public List<Livro> ParseList(List<LivroVO> origin)
        {
            if (origin == null) return new List<Livro>();
            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
