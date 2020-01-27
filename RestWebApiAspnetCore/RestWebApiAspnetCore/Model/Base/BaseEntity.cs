using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWebApiAspnetCore.Model.Base
{
    //Conntrato entre os atributos e a estrutura da tabela
    //[DataContract]
    public class BaseEntity
    {
        public long Id { get; set; }
    }
}
