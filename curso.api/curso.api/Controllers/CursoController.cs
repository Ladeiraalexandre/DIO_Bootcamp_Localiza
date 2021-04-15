using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao Cadastrar um curso", Type = typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }


        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <returns>Retorna status 201 e dados do curso do usuário</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CursoViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var cursos = new List<CursoViewModelOutput>();
            cursos.Add(new CursoViewModelOutput()
            {
                Login = codigoUsuario.ToString(),
                Descricao = "Preparatório para prova CTFL",
                Nome = "CTFL EXAM"
            });

            return Ok(cursos);

        }


    }
}
