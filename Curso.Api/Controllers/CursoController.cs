using curso.Api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace curso.Api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {

        /// <summary>
        /// Este serviço permite cadsatrar um curso
        /// </summary>
        /// <param name="cursoViewModelInput">View model do curso</param>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um curso", Type = typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }


        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário
        /// </summary>
        /// <param name="cursoViewModelInput">View model do curso</param>
        /// <returns>Retorna status ok e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {

            //var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = new List<CursosViewModelOutput>();

            cursos.Add(new CursosViewModelOutput
            {
                Login = "",
                Descricao = "Teste",
                Nome = "teste"
            }); ;

            return Ok(cursos);
        }

    }
}
