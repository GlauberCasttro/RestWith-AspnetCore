using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApiAspnetCore.Model
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string  Endereco { get; set; }
        public string Genero { get; set; }

    }
}
