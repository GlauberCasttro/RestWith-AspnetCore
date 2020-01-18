using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Ocsp;

namespace RestWebApiAspnetCore.Model
{
    public class Livro
    {
        public long? Id { get; set; }
      

        public string Autor { get; set; }
      

        public DateTime DataLancamento { get; set; }
       

        public string Titulo { get; set; }
       

        public decimal preco { get; set; }
    }
}
