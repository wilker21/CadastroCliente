using CadastroCliente.Dominio;
using CadastroCliente.Infraestrutura.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CadastroCliente.Infraestrutura
{
    public sealed class CadastroClienteDbContext : DbContext
    {
        public CadastroClienteDbContext() : base("name=CadastroCliente")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CadastroClienteDbContext, MigrationsConfigurations>());
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(typeof(CadastroClienteDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
