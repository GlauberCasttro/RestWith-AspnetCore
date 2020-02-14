using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Business
{
   public interface ILoginBusiness
   {
       Object FindByLogin(UsuarioVO login);
   }
}
