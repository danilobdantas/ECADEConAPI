using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECADEconAPI.Class;
using ECADEconAPI.Models;
using ECADEconAPI.Services;
using Newtonsoft.Json;

namespace ECADEconAPI
{
    public class Utils
    {
        private readonly IEmailSender _emailSender;
        public Utils(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public bool GravarLog(string msg)
        {
            // Gravação do Registro de LOG de Atividades
            return true;
        }

        public async Task EnviarEmail(string assunto, string mensagem)
        {
            await _emailSender.SendEmailAsync(assunto, mensagem);
        }
    }
}