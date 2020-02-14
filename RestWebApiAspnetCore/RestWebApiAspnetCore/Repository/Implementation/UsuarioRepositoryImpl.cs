using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Model.Context;

namespace RestWebApiAspnetCore.Repository.Implementation
{
    public class UsuarioRepositorioImpl : IUsuarioRepository
    {
        private MySqlContext _context;

        public UsuarioRepositorioImpl(MySqlContext context)
        {
            _context = context;
        }
        
        public Usuario FindByLogin(string login)
        {

            return _context.Usuario.SingleOrDefault(usu=> usu.Login.Equals(login));
        }

        
    }
}
