using System.Collections.Generic;

namespace CadastroCliente.Models
{
    public class ListarViewModel
    {
        public IEnumerable<ClienteDto> Clientes { get; set; }

        public FiltroViewModel Filtro { get; set; }
    }
}