
using Newsletter.Model.Users;

namespace Newsletter.DAL.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(NewsletterDbContext context) : base(context)
        {
        }
    }
}
