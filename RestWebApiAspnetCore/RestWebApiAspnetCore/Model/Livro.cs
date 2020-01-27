using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Ocsp;
using RestWebApiAspnetCore.Model.Base;

namespace RestWebApiAspnetCore.Model
{
    public class Livro : BaseEntity
    {
        public string Autor { get; set; }

        public DateTime DataLancamento { get; set; }

        public string Titulo { get; set; }
        
        public decimal preco { get; set; }
    }
}
