using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECADEconAPI.Models
{
    public class MovimentoDAO
    {
        public MovimentoDAO()
        {

        }
        public bool AtualizaMovimentacaoBancaria(MovimentoDTO Movimento)
        {
            try
            {
                // Atualização das informações no Banco de Dados
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
