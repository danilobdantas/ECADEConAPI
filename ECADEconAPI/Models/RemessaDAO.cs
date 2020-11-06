using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECADEconAPI.Models
{
    public class RemessaDAO
    {
        public RemessaDAO()
        {

        }
        public bool VerificarRemessa(RemessaDTO _RemessaDTO)
        {
            try
            {
                // Validar se a remessa já foi ou não baixada no Banco de Dados
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }
    }
}
