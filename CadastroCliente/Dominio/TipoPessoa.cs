using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Dominio
{
    public enum TipoPessoa
    {
        [Description("Pessoa Física")]
        PessoaFisica,

        [Description("Pessoa Jurídica")]
        PessoaJuridica
    }
}
