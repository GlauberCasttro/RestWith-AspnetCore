using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Data.Converter;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Data.Converters
{
    public class UsuarioConverter : IParser<UsuarioVO,Usuario>, IParser<Usuario, UsuarioVO>
    {
        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null)
                return null;
            return new Usuario()
            {
              Id = origin.Id,
              Login = origin.usuario,
              Senha = origin.senha

            };
        }

        public List<UsuarioVO> ParseList(List<Usuario> origin)
        {
            if(origin == null) return new List<UsuarioVO>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null)
                return null;
            return new UsuarioVO()
            {
                Id = origin.Id,
                senha = origin.Senha,
                usuario = origin.Login
            };
        }

        public List<Usuario> ParseList(List<UsuarioVO> origin)
        {
            if (origin == null) return new List<Usuario>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
