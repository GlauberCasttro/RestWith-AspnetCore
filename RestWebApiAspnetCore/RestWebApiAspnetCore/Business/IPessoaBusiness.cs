using RestWebApiAspnetCore.Data.VO;
using System.Collections.Generic;

namespace RestWebApiAspnetCore.Business
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO pessoa);
        PessoaVO FindById(long id);
        List<PessoaVO> FindAll();
        PessoaVO Update(PessoaVO pessoa);
        void Delete(long id);
    }
}
