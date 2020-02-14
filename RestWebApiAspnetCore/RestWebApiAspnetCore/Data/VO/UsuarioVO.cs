using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApiAspnetCore.Data.VO
{
    public class UsuarioVO
    {
        public int Id { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
    }
}
