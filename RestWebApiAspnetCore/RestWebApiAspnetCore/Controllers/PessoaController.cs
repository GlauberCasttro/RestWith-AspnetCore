using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Services;

namespace RestWebApiAspnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        // GET: api/Pessoa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var person = _pessoaService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST: api/Pessoa
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Create(pessoa));
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {

            if (pessoa == null) return BadRequest();
            return new ObjectResult(_pessoaService.Update(pessoa));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pessoaService.Delete(id);
            return NoContent();
        }
    }
}
