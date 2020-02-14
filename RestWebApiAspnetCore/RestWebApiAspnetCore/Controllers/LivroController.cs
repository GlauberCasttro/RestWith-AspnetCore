using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Data.VO;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Tapioca.HATEOAS;

namespace RestWebApiAspnetCore.Controllers
{

    [ApiVersion("1")]
    [Route("api/livro/v{version:apiVersion}")]
    [ApiController]
    public class LivroController : Controller
    {

        private ILivroBusiness _livroBusiness;

        public LivroController( ILivroBusiness livroBusiness)
        {
            _livroBusiness = livroBusiness;
        }
        // GET: Livro
        [HttpGet]
        [SwaggerResponse((200), typeof(List<LivroVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
       // [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_livroBusiness.FindAll());
        }

        // GET: Livro/Details/5
        [HttpGet("{id}", Name = "GetById")]
        [SwaggerResponse((200), typeof(List<PessoaVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
       // [Authorize("Bearer")]
        public IActionResult Get(int id)
        {
            var livro = _livroBusiness.FindById(id);
            if (livro == null) return NotFound("Recurso {livro} não encontrado "+ id);
            return Ok(livro);

        }

        // GET: Livro/Create[HttpPost]
        [HttpPost]
        [SwaggerResponse((201), typeof(PessoaVO))]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
       // [Authorize("Bearer")]
        public IActionResult Create([FromBody] LivroVO livro)
        {
            if (livro == null && !ModelState.IsValid) return BadRequest();
            return new ObjectResult(_livroBusiness.Create(livro));
        }


        [HttpPut()]
        [SwaggerResponse((202), typeof(LivroVO))]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
      //  [Authorize("Bearer")]
        public IActionResult Put([FromBody] LivroVO livro)
        {
            if (livro == null) return BadRequest();
            var upLivro = _livroBusiness.Update(livro);
            if (upLivro == null) return BadRequest();

            return new ObjectResult(upLivro);
        }


        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        //[Authorize("Bearer")]
        public IActionResult Delete(int id)
        {
            _livroBusiness.Delete(id);
            return NoContent();
        }

       
    }
}