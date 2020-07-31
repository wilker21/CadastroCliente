using CadastroCliente.Infraestrutura;
using LightInject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CadastroCliente
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();
            container.Register<CadastroClienteDbContext>();
            container.Register<ClienteRepository>();

            container.EnableMvc();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
