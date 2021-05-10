using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCastGroup.Library.Business;
using TesteCastGroup.Library.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteCastGroup.API.Controllers
{
    [Route("api/Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private TesteCastGroupContext objTesteCastGroupContext = new TesteCastGroupContext();
        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return new CategoriaBusiness(objTesteCastGroupContext).GetAll();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Resposta < Categoria > objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).Get(id);
            if (!objCategoriaResposta.Sucesso)
                return StatusCode(500, objCategoriaResposta.Mensagem);
            else
                return Ok(objCategoriaResposta.Objeto);



        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] Categoria value)
        {
            Resposta<Categoria> objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).Save(value);
            if (!objCategoriaResposta.Sucesso)
                return StatusCode(500, objCategoriaResposta.Mensagem);
            else
                return Ok(objCategoriaResposta.Objeto);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria value)
        {
            Resposta<Categoria> objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).Get(id);
            if (!objCategoriaResposta.Sucesso)
                return StatusCode(500, objCategoriaResposta.Mensagem);
            else
            {
                objCategoriaResposta.Objeto.Descricao = value.Descricao;
                objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).Update(objCategoriaResposta.Objeto);
                if (!objCategoriaResposta.Sucesso)
                    return StatusCode(500, objCategoriaResposta.Mensagem);
                else
                    return Ok(objCategoriaResposta.Objeto);
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Resposta<Categoria> objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).Delete(id);
            if (!objCategoriaResposta.Sucesso)
                return StatusCode(500, objCategoriaResposta.Mensagem);
            else
                return Ok(objCategoriaResposta);
        }
    }
}
