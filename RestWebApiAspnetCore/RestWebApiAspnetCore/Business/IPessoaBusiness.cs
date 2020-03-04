using RestWebApiAspnetCore.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestWebApiAspnetCore.Business
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO pessoa);
        PessoaVO FindById(long id);
        List<PessoaVO> FindAll();
        List<PessoaVO> FindByName(string firstName, string lastName);
        PessoaVO Update(PessoaVO pessoa);
        void Delete(long id);

        PagedSearchDTO<PessoaVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    }
}
