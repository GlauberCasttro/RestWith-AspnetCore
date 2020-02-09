using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model.Base;
using Tapioca.HATEOAS;

namespace RestWebApiAspnetCore.Data.VO
{   
    public class PessoaVO : ISupportsHyperMedia
    { 


        public long? Id { get; set; }
        public string Nome { get; set; }
       
        public string Sobrenome { get; set; }
       
        public string Endereco { get; set; }
       
        public string Genero { get; set; }
   
        public DateTime? Atualizacao { get; set; }

       // public DateTime? DataCriacao { get; set; }


       //Implementando HATEOAS
       public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
