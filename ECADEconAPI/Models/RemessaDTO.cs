using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ECADEconAPI.Models
{
    public class RemessaDTO
    {
        public string CodigoRegistro { get; set; }
        //Código do registro = “A”
        //A.01 -> POSIÇÃO 001 A 001 -> FORMATO X( 01 )
        public string CodigoRemessa { get; set; }
        //Código de Remessa (2 - RETORNO - Enviado pelo Banco para a Empresa/Órgão)
        //A.02 -> POSIÇÃO 002 A 002 -> FORMATO 9( 01 )
        public string CodigoConvenio { get; set; }
        //Código do Convênio
        //A.03 -> POSIÇÃO 003 A 022 -> FORMATO X( 20 )
        public string NomeEmpresaOrgao { get; set; }
        //Nome da Empresa / Órgão
        //A.04 -> POSIÇÃO 023 A 042 -> FORMATO X( 20 )
        public string CodigBanco { get; set; }
        //Código do Banco
        //A.05 -> POSIÇÃO 043 A 045 -> FORMATO 9( 03 )
        public string NomeBanco { get; set; }
        //Nome do Banco
        //A.06 -> POSIÇÃO 046 A 065 -> FORMATO X( 20 )
        public string DataGeracaoArquivo { get; set; }
        //Data da Geração do Arquivo no formato (AAAAMMDD)
        //A.07 -> POSIÇÃO 066 A 073 -> FORMATO 9( 08 )
        public string NSA { get; set; }
        //NSA - Número Seqüencial do Arquivo (Este número deverá evoluir de 1 em 1 para cada arquivo gerado)
        //A.08 -> POSIÇÃO 074 A 079 -> FORMATO 9 ( 06 )
        public string VersaoLayOut { get; set; }
        //Versão do LayOut (nova = versão 06 - disponível a partir de 01.11.2020)
        //A.09 -> POSIÇÃO 080 A 081 -> FORMATO 9 ( 02 )
        public string CodigoBarras { get; set; }
        //Código de Barras (Deverá conter “CÓDIGO DE BARRAS”)
        //A.10 -> POSIÇÃO 082 a 098 -> FORMATO X ( 17 )
    }
}