using Newsletter.Web.App_Start;
using Newsletter.Web.IoC;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Newsletter.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region IoC

            var container = StructureMapBootStrapper.Initialize();

            // MVC resolver
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));

            // Web Api resolver
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);

            #endregion
        }
    }
}
