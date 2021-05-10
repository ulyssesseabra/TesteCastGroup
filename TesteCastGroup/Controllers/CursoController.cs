using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteCastGroup.API.DTO;
using TesteCastGroup.Library.Business;
using TesteCastGroup.Library.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteCastGroup.API.Controllers
{
    [Route("api/Curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private TesteCastGroupContext objTesteCastGroupContext = new TesteCastGroupContext();

        // GET: api/<CursoController>
        [HttpGet]
        public IEnumerable<Curso> Get()
        {
            return new CursoBusiness(objTesteCastGroupContext).GetAll();
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Resposta<Curso> objCursoResposta = new CursoBusiness(objTesteCastGroupContext).Get(id);
            if (!objCursoResposta.Sucesso)
                return StatusCode(500, objCursoResposta.Mensagem);
            else
                return Ok(objCursoResposta.Objeto);

        }

        // POST api/<CursoController>
        [HttpPost]
        public IActionResult Post([FromBody] CursoDTO value)
        {
            Resposta<Categoria> objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).GetByCodigo(value.CategoriaCodigo);
            if (!objCategoriaResposta.Sucesso)
                return StatusCode(500, objCategoriaResposta.Mensagem);
            Curso objCurso = new Curso()
            {
                DescricaoAssunto = value.DescricaoAssunto,
                DataInicio = value.DataInicio,
                DataTerminio = value.DataTerminio,
                QuantidadeAluno = value.QuantidadeAluno,
                Categoria = objCategoriaResposta.Objeto
            };
            Resposta<Curso> objCursoResposta = new CursoBusiness(objTesteCastGroupContext).Save(objCurso);
            if (!objCursoResposta.Sucesso)
                return StatusCode(500, objCursoResposta.Mensagem);
            else
                return Ok(objCursoResposta.Objeto);

        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CursoDTO value)
        {
            Resposta<Categoria> objCategoriaResposta = new CategoriaBusiness(objTesteCastGroupContext).GetByCodigo(value.CategoriaCodigo);
            if (!objCategoriaResposta.Sucesso)
                return StatusCode(500, objCategoriaResposta.Mensagem);

            Resposta<Curso> objCursoResposta = new CursoBusiness(objTesteCastGroupContext).Get(id);
            if (!objCursoResposta.Sucesso)
                return StatusCode(500, objCursoResposta.Mensagem);
            else
            {
                objCursoResposta.Objeto.DescricaoAssunto = value.DescricaoAssunto;
                objCursoResposta.Objeto.DataInicio = value.DataInicio;
                objCursoResposta.Objeto.DataTerminio = value.DataTerminio;
                objCursoResposta.Objeto.QuantidadeAluno = value.QuantidadeAluno;
                objCursoResposta.Objeto.Categoria = objCategoriaResposta.Objeto;
                objCursoResposta = new CursoBusiness(objTesteCastGroupContext).Update(objCursoResposta.Objeto);
                if (!objCursoResposta.Sucesso)
                    return StatusCode(500, objCursoResposta.Mensagem);
                else
                    return Ok(objCursoResposta.Objeto);
            }
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Resposta<Curso> objCursoResposta = new CursoBusiness(objTesteCastGroupContext).Delete(id);
            if (!objCursoResposta.Sucesso)
                return StatusCode(500, objCursoResposta.Mensagem);
            else
                return Ok(objCursoResposta);
        }
    }
}
