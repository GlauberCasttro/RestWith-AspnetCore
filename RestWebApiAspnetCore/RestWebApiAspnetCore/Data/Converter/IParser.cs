using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApiAspnetCore.Data.Converter
{
    //Interface para converter onde 'O' entrada(origem) pode ser um VO e o destino 'D' pode ser uma entidade ou vice e versao 
   public interface IParser<O,D>
   {
       D Parse(O origin);
       List<O> ParseList(List<D> origin);
   }
}
