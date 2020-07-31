using CadastroCliente.Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class AdicionarViewModel : EdicaoViewModelBase
    {
        [Required]
        [RegularExpression("[^0-9]+", ErrorMessage = "O nome deve apenas conter letras")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo 500 caracteres")]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        public static Cliente ParaEntidade(AdicionarViewModel cliente)
        {
            if (cliente is null) return default;

            return new Cliente(cliente.Nome, cliente.Documento, cliente.Telefone, cliente.TipoPessoa);
        }
    }

}