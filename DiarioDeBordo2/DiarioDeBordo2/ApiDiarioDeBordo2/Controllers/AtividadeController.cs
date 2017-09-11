
using ApiDiarioDeBordo2.SwaggerExtensions;
using Aplicacao.Interfaces;
using Biblioteca.Classes;
using DataTransfer.Requests;
using DataTransfer.Responses;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiDiarioDeBordo2.Controllers
{
    [GroupSwagger("Atividade")]
    public class AtividadeController : ApiController
    {
        private readonly IAtividadeAppService atividadeAppService;

        public AtividadeController(IAtividadeAppService atividadeAppService)
        {
            this.atividadeAppService = atividadeAppService;
        }


        /// <summary>
        /// Listar atividade por código
        /// </summary>
        [HttpGet]
        [Authorize]
        [Route("atividade/{codigo:int}")]
        [ResponseType(typeof(IEnumerable<AtividadeResponse>))]
        public IHttpActionResult Listar([FromUri] int codigo)
        {
            var response = this.atividadeAppService.Listar(codigo);

            return Ok(response);
        }

        /// <summary>
        /// Listar todos os perfis
        /// </summary>
        [HttpGet]
        //[Authorize]
        [Route("atividade")]
        [ResponseType(typeof(IEnumerable<AtividadeResponse>))]
        public IHttpActionResult Listar()
        {
            var response = this.atividadeAppService.Listar();

            return Ok(response);
        }

        /// <summary>
        /// Inserir novos perfis
        /// </summary>
        [HttpPost]
        //[Authorize(Roles = Constantes.Atividade.Administrador)]
        [Route("atividade")]
        [ResponseType(typeof(AtividadeResponse))]
        public IHttpActionResult Inserir([FromBody] AtividadeRequest request)
        {
            var response = this.atividadeAppService.Inserir(request);

            return Ok(response);
        }

        /// <summary>
        /// Alterar perfis existentes
        /// </summary>
        [HttpPut]
        [Authorize(Roles = Constantes.Atividade.Administrador)]
        [Route("atividade")]
        [ResponseType(typeof(AtividadeResponse))]
        public IHttpActionResult Alterar([FromBody] AtividadeRequest request)
        {
            var response = this.atividadeAppService.Alterar(request);

            return Ok(response);
        }

        /// <summary>
        /// Excluir perfis
        /// </summary>
        [HttpDelete]
        [Authorize(Roles = Constantes.Atividade.Administrador)]
        [Route("atividade/{codigo:int}")]
        [ResponseType(typeof(int))]
        public IHttpActionResult Excluir([FromUri] int codigo)
        {
            var response = this.atividadeAppService.Excluir(codigo);

            return Ok(response);
        }
    }
}