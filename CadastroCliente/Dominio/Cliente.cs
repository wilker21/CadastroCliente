using System;

namespace CadastroCliente.Dominio
{
    public class Cliente
    {
        protected Cliente() { }

        public Cliente(string nome, string documento, string telefone, TipoPessoa tipoPessoa)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;

            RemoverCaracterEspeciais();
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
        public string Telefone { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public bool Status { get; private set; } = true;

        public void Alterar(string nome, string documento, string telefone, TipoPessoa tipoPessoa)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            TipoPessoa = tipoPessoa;

            RemoverCaracterEspeciais();
        }

        private void RemoverCaracterEspeciais() 
        {
            Documento = Documento.Replace("-", string.Empty).Replace(".", string.Empty);
            Telefone = Telefone.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty);
        }

        public bool Inativar() => Status = false;

    }
}