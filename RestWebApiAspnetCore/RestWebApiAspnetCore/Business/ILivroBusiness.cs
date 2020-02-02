using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Business
{
     public interface ILivroBusiness 
    {
        LivroVO Create(LivroVO livro);
        LivroVO FindById(long id);
        List<LivroVO> FindAll();
        LivroVO Update(LivroVO livro);
        void Delete(long id);

       
    }
}
