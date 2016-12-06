using Newsletter.DAL;
using Newsletter.DAL.Repository;
using Newsletter.Model.Topics;
using Newsletter.Model.Users;
using StructureMap;
using System.Data.Entity;

namespace Newsletter.Service
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            // Repository
            For<DbContext>().Use(() => new NewsletterDbContext());

            For<IUserRepository>().Use<UserRepository>();
            For<ITopicRepository>().Use<TopicRepository>();
        }
    }
}
