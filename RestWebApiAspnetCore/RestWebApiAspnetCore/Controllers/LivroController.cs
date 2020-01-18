using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Model;

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
        public IActionResult Get()
        {

            return Ok(_livroBusiness.FindAll());
        }

        // GET: Livro/Details/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            var livro = _livroBusiness.FindById(id);
            if (livro == null) return NotFound("Recurso {livro} não encontrado "+ id);
            return Ok(livro);

        }

        // GET: Livro/Create
        [HttpPost()]
        public IActionResult Create([FromBody] Livro livro)
        {
            if (livro == null && !ModelState.IsValid) return BadRequest();
            return new ObjectResult(_livroBusiness.Create(livro));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            var upLivro = _livroBusiness.Update(livro);
            if (upLivro == null) return BadRequest();

            return new ObjectResult(upLivro);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _livroBusiness.Delete(id);
            return NoContent();
        }

       
    }
}