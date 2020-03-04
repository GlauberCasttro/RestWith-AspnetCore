using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWebApiAspnetCore.Business;
using RestWebApiAspnetCore.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using Tapioca.HATEOAS;

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
        [SwaggerResponse((200), typeof(List<PessoaVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }


        [HttpGet("find-by-name")]
        [SwaggerResponse((200), typeof(List<PessoaVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult GetByName([FromQuery] string firstName, string lastName)
        {
            return Ok(_pessoaBusiness.FindByName(firstName, lastName));
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}", Name = "Get")]
        [SwaggerResponse((200), typeof(PessoaVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult Get(int id)
        {
            var person = _pessoaBusiness.FindById(id);
            if (person == null) return NotFound("Não foi encontrado o recurso " + id + "!!!");
            return Ok(person);


        }

        // POST: api/Pessoa
        [HttpPost]
        [SwaggerResponse((201), typeof(PessoaVO))]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
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
        [SwaggerResponse((202), typeof(PessoaVO))]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
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
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();

        }


        [HttpGet("find-with-page-search/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), typeof(List<PessoaVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(401)]
        [SwaggerResponse(400)]
        [TypeFilter(typeof(HyperMediaFilter))]
        [Authorize("Bearer")]
        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
           // return OK(_pessoaBusiness.FindWithPagedSearch(name,sortDirection,pageSize,page));
            return new OkObjectResult(_pessoaBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

    }


}
