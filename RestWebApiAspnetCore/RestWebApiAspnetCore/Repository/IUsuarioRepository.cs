using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Repository
{
    public interface IUsuarioRepository
    {
        Usuario FindByLogin(string login);
        
    }
}