using CadastroCliente.Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public abstract class EdicaoViewModelBase : IValidatableObject
    {
        [Required]
        //[RegularExpression("[0-9]+", ErrorMessage = "Documento deve apenas conter numeros")]
        public string Documento { get; set; }

        [Required]
        public TipoPessoa TipoPessoa { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TipoPessoa == TipoPessoa.PessoaFisica && !Validacoes.IsCpf(Documento))
                yield return new ValidationResult("CPF Invalido", new[] { nameof(Documento) });
            else if (TipoPessoa == TipoPessoa.PessoaJuridica && !Validacoes.IsCnpj(Documento))
                yield return new ValidationResult("CNPJ Invalido", new[] { nameof(Documento) });
        }

    }
}