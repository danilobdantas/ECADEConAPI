using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ECADEconAPI.Class;
using ECADEconAPI.Services;
using System;
using ECADEconAPI.Models;
using System.Collections.Generic;

namespace ECADEconAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentoController : Controller
    {
        protected IEmailSender _emailSender;
        protected Utils _Utils;
        public MovimentoController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _Utils = new Utils(_emailSender);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Lexicon Informática e Serviços EIRELI - API Movimento");
        }

        [HttpPut]
        public IActionResult Put([FromBody]List<MovimentoDTO> listaMovimentos)
        {
            try
            {
                BaixaPagamentos BaixaPgto = new BaixaPagamentos(_emailSender);
                BaixaPgto.AtualizarPagamentos(listaMovimentos);
            }
            catch (Exception ex)
            {
                _Utils.GravarLog("ERRO na leitura do arquivo Movimentos JSON -> " + ex.Message);
                _Utils.EnviarEmail("ERRO no processamento", "ERRO na leitura do arquivo Movimentos JSON -> " + ex.Message).Wait();
            }
            return Ok();
        }
    }
}