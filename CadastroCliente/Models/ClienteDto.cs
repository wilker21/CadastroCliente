using CadastroCliente.Dominio;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Documento { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        public string Telefone { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public static ClienteDto ParaResultado(Cliente cliente)
        {
            if (cliente is null) return default;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Documento = cliente.Documento,
                DataCadastro = cliente.DataCadastro,
                Telefone = cliente.Telefone,
                TipoPessoa = cliente.TipoPessoa,
            };
        }
    }
}