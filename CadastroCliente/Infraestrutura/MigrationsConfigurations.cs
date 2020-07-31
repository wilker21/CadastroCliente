using System.Data.Entity.Migrations;

namespace CadastroCliente.Infraestrutura.Migrations
{
    internal sealed class MigrationsConfigurations : DbMigrationsConfiguration<CadastroClienteDbContext>
    {
        public MigrationsConfigurations()
        {
            ContextType = typeof(CadastroClienteDbContext);
            MigrationsDirectory = "Infraestrutura\\Migrations";
            MigrationsNamespace = "CadastroCliente.Infraestrutura.Migrations";
        }

    }
}