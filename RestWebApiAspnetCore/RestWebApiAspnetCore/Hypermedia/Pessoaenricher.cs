using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Data.VO;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestWebApiAspnetCore.Hypermedia
{
    public class PessoaEnricher : ObjectContentResponseEnricher<PessoaVO>
    {
        protected override Task EnrichModel(PessoaVO content, IUrlHelper urlHelper)
        {
            var path = "api/pessoa/v1";
            var url = new {controller = path, id = content.Id};
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,Href = urlHelper.Link("DefaultApi",url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });


            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type ="int",
            });
            return null;
        }
    }
}
