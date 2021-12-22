using Decomposicao.Dominio;
using Decomposicao.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Http.Description;

namespace Decomposicao.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FatoracaoController :Controller
    {
        private readonly IFatoracao _fatoracao;
        public FatoracaoController(IFatoracao fatoracao)
        {
            _fatoracao = fatoracao;
        }
       
        
        [AcceptVerbs("GET")]
        [Route("decomposicao/{numeroDeEntrada}")]
        [ResponseType(typeof(Decompositor))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DecomporNumeroDeEntrada(int numeroDeEntrada)
        {
            try
            {
                var decompositor = _fatoracao.DecomporNumero(numeroDeEntrada);
                return Ok(decompositor);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
            

        }
    }
}
