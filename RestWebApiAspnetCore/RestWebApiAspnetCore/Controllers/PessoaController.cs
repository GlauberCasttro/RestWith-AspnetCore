using System;
using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Data.VO;

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
        public IActionResult Post([FromBody] PessoaVO pessoa)
        {

            if (pessoa == null)
            {
                return BadRequest();
            }
            
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
        }

        // PUT: api/Pessoa/5
        [HttpPut()]
        public IActionResult Put([FromBody] PessoaVO pessoa)
        {


            if (!ModelState.IsValid && pessoa == null)
            {
                return BadRequest();
            }
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
