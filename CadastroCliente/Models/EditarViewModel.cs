using CadastroCliente.Dominio;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class EditarViewModel : EdicaoViewModelBase
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "O nome deve apenas conter letras")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo 500 caracteres")]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        public static EditarViewModel ParaResultado(Cliente cliente)
        {
            if (cliente is null) return default;

            return new EditarViewModel
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento,
                Telefone = cliente.Telefone,
                TipoPessoa = cliente.TipoPessoa
            };
        }
    }
}