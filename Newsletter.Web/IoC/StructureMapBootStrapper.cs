using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Newsletter.Model.Users;
using Newsletter.Service;
using Newsletter.Service.TopicService;
using Newsletter.Service.UserService;
using StructureMap;
using System.Web;

namespace Newsletter.Web.IoC
{
    public class StructureMapBootStrapper
    {
        public static IContainer Initialize()
        {
            IContainer container = new Container(new NewsletterRegistry());
            
            return container;
        }

        public static void ConfigureDependencies() { }

        public class NewsletterRegistry : Registry
        {
            public NewsletterRegistry()
            {
                this.IncludeRegistry(new ServiceRegistry());

                For<IUserService>().Use<UserService>();
                For<ITopicService>().Use<TopicService>();

                For<IUserStore<User>>().Use<UserStore<User>>();
                For<IAuthenticationManager>().Use(() => HttpContext.Current.GetOwinContext().Authentication);

            }
        }
    }
}