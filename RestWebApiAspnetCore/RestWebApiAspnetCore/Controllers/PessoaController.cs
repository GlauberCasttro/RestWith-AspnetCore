using System;
using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Business;

namespace RestWebApiAspnetCore.Controllers
{
    [ApiVersion("1")]
    [Route("api/Pessoa/v{version:apiVersion}")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaBusiness _pessoaBusiness;

        public PessoaController(IPessoaBusiness pessoaBusiness)
        {
            _pessoaBusiness = pessoaBusiness;
        }


        // GET: api/Pessoa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var person = _pessoaBusiness.FindById(id);
            if (person == null) return NotFound("Não foi encontrado o recurso " + id + "!!!");
            return Ok(person);

            
        }

        // POST: api/Pessoa
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {

            if (pessoa == null)
            {
                return BadRequest();
            }

            pessoa.Atualizacao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
        }

        // PUT: api/Pessoa/5
        [HttpPut()]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {


            if (!ModelState.IsValid && pessoa == null)
            {
                return BadRequest();
            }

            pessoa.Atualizacao = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            var upPessoa = _pessoaBusiness.Update(pessoa);
            if (upPessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(upPessoa);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();
        }
    }
}
