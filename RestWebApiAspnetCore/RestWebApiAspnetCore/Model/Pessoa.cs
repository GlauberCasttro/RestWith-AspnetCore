using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model.Base;

namespace RestWebApiAspnetCore.Model
{
    public class Pessoa : BaseEntity
    {

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Genero { get; set; }

        public DateTime? Atualizacao { get; set; }

    }
}
