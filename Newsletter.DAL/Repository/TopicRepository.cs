using Newsletter.Model.Topics;

namespace Newsletter.DAL.Repository
{
    public class TopicRepository : RepositoryBase<Topic>, ITopicRepository
    {
        public TopicRepository(NewsletterDbContext context) : base(context)
        {
        }
    }
}
