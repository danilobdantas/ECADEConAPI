using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ECADEconAPI.Models
{
    public class MovimentoDTO
    {
        public string CodigoRegistro { get; set; }
        //Código do registro = “G”
        //G.01 -> POSIÇÃO 001 A 001 -> FORMATO X( 01 )
        public string IdentificacaoConta { get; set; }
        //Identificação da agência/conta/dígito creditada
        //G.02 -> POSIÇÃ O002 A 021 -> FORMATO X( 20 )
        public string DataPagamento { get; set; }
        //Data do pagamento no formato Ano/Mês/Dia
        //G.03 -> POSIÇÃO 022 A 029 -> FORMATO X( 08 )
        public string DataCredito { get; set; }
        //Data do crédito no formato Ano/Mês/Dia
        //G.04 -> POSIÇÃO 030 A 037 -> FORMATO X( 08 )
        public string CodigoBarras { get; set; }
        //Informações do Código de Barras
        //G.05 -> POSIÇÃO 038 A 081 -> FORMATO X( 44 )
        public string ValorRecebido { get; set; }
        //Valor efetivamente eecebido
        //G.06 -> POSIÇÃO 082 A 093 -> FORMATO 9( 10 ) V 99
        public string ValorTarifa { get; set; }
        //Valor da tarifa referente a cada comprovante arrecadado
        //G.07 -> POSIÇÃO 094 A 100 -> FORMATO 9( 5 ) V 99
        public string NSR { get; set; }
        //NSR - Número Seqüencial de Registro (Uso do Banco - Identificação do registro dentro do arquivo gerado)
        //G.08 -> POSIÇÃO 101 A 108 -> FORMATO X ( 08 )
        public string CodigoAgenciaArrecadadora { get; set; }
        //Código da agência arrecadadora
        //G.09 -> POSIÇÃO 109 A 116 -> FORMATO X ( 08 )
        public string FormaArrecadacao { get; set; }
        //Forma de arrecadação/captura
        //G.10 -> POSIÇÃO 117 A 117 -> FORMATO X ( 01 )
        public string NumeroAutenticacao { get; set; }
        //Número de autenticação caixa ou código de transação
        //G.11 -> POSIÇÃO 118 A 140 -> FORMATO X ( 23 )
        public string FormaPagamento { get; set; }
        //Forma de Pagamento
        //G.12 -> POSIÇÃO 141 A 141 -> FORMATO 9 ( 01 )

        //G.10 – Forma de arrecadação/captura
            //1 – Guichê de Caixa com fatura/guia de arrecadação
            //2 – Arrecadação Eletrônica com fatura/guia de arrecadação(terminais de auto - atendimento, ATM, home banking)
            //3 – Internet/mobile com fatura/guia de arrecadação
            //4 – Outros meios com fatura/guia de arrecadação
            //5 – Correspondentes bancários com fatura/guia de arrecadação
            //6 – Telefone com fatura/guia de arrecadação
            //7 – Casas lotéricas com fatura/guia de arrecadação
            //8 - Cartão/Multibanco com fatura/guia de arrecadação
            //9 – PIX com fatura/guia de arrecadação
            //a – Guichê de Caixa sem fatura/guia de arrecadação
            //b – Arrecadação Eletrônica sem fatura/guia de arrecadação(terminais de auto - atendimento, ATM, home banking)
            //c – Internet/mobile sem fatura/guia de arrecadação
            //d – Correspondentes bancários sem fatura/guia de arrecadação
            //e – Telefone sem fatura/guia de arrecadação
            //f – Outros meios sem fatura/guia de arrecadação
            //g – Casas lotéricas sem fatura/guia de arrecadação
            //h – Cartão/Multibanco sem fatura/guia de arrecadação
            //i – PIX sem fatura/guia de arrecadação

        //G.12 – Forma de Pagamento
            //1 – Dinheiro
            //2 – Cheque
            //3 – Não identificado/outras formas
            //4 – Cartão de crédito
            //5 – Cartão/Multibanco
            //6 – Débito em conta
    }
}
