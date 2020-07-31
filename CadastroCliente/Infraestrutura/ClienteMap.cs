using CadastroCliente.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace CadastroCliente.Infraestrutura
{
    internal sealed class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable(typeof(Cliente).Name);
            HasKey(t => t.Id);
            Property(t => t.Nome).HasMaxLength(500).IsRequired();
            Property(t => t.Telefone).HasMaxLength(12).IsRequired();
            Property(t => t.Documento).HasMaxLength(14).IsRequired();
            Property(t => t.DataCadastro).IsRequired();
            Property(t => t.TipoPessoa).IsRequired();
            Property(t => t.Status).IsRequired();
        }
    }
}
