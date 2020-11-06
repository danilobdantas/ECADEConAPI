using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ECADEconAPI.Class;
using ECADEconAPI.Models;
using Newtonsoft.Json;

namespace ECADEconAPI
{
    public class BaixaPagamentos
    {
        protected Utils _Utils;
        protected RemessaDAO _RemessaDAO;
        protected MovimentoDAO _MovimentoDAO;

        protected IEmailSender _emailSender;
        protected string _DataGeracaoArquivo;
        protected string _NSA;
        public BaixaPagamentos(IEmailSender emailSender)
        {
            _emailSender = emailSender;
            _RemessaDAO = new RemessaDAO();
            _MovimentoDAO = new MovimentoDAO();
            _Utils = new Utils(_emailSender);
        }

        public Task ValidarRemessa(List<RemessaDTO> listaRemessa)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (listaRemessa != null && listaRemessa.Count > 0)
                    {
                        foreach (var item in listaRemessa)
                        {
                            _DataGeracaoArquivo = item.DataGeracaoArquivo;
                            _NSA = item.NSA;

                            bool retorno = _RemessaDAO.VerificarRemessa(item);

                            if (!retorno)
                                _Utils.GravarLog("Remessa " + item.DataGeracaoArquivo + "-" + item.NSA + " autorizada para processamento");
                            else
                                _Utils.GravarLog("A Remessa " + item.DataGeracaoArquivo + "-" + item.NSA + " já encontra-se processada");
                        }
                    }
                
                }
                catch (Exception ex)
                {
                    _Utils.GravarLog("ERRO na verificação da remessa " + _DataGeracaoArquivo + "-" + _NSA + " -> " + ex.Message);

                    _Utils.EnviarEmail("ERRO no processamento", "ERRO na verificação da remessa " + _DataGeracaoArquivo + "-" + _NSA + " -> " + ex.Message).Wait();
                }
            });
        }

        public Task AtualizarPagamentos(List<MovimentoDTO> listaMovimentos)
        {
            return Task.Run(() => {
                try
                {
                    if (listaMovimentos != null && listaMovimentos.Count > 0)
                    {
                        foreach (var item in listaMovimentos)
                        {
                            bool retorno = _MovimentoDAO.AtualizaMovimentacaoBancaria(item);

                            if (retorno)
                                _Utils.GravarLog("SUCESSO na baixa do título " + item.CodigoBarras + " pago em " + item.DataPagamento);
                            else
                                _Utils.GravarLog("ERRO na baixa do título " + item.CodigoBarras + " pago em " + item.DataPagamento);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _Utils.GravarLog("ERRO na baixa dos títulos");
                    _Utils.EnviarEmail("ERRO no processamento", "ERRO na baixa dos títulos - " + ex.Message).Wait();
                }
            });
        }
    }
}