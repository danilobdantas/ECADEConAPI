using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using ECADEconAPI.Class;
using System;
using ECADEconAPI.Models;
using System.Collections.Generic;

namespace ECADEconAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemessaController : Controller
    {
        protected IEmailSender _emailSender;
        protected Utils _Utils;
        public RemessaController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _Utils = new Utils(_emailSender);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Lexicon Informática e Serviços EIRELI - API Remessa");
        }

        [HttpPut]
        public IActionResult Put(List<RemessaDTO> listaRemessas)
        {
            try
            {
                BaixaPagamentos BaixaPgto = new BaixaPagamentos(_emailSender);
                BaixaPgto.ValidarRemessa(listaRemessas);
            }
            catch (Exception ex)
            {
                _Utils.GravarLog("ERRO na leitura do arquivo Remessas JSON ->" + ex.Message);
                _Utils.EnviarEmail("ERRO no processamento", "ERRO na leitura do arquivo Remessas JSON ->" + ex.Message).Wait();
            }
            return Ok();
        }
    }
}