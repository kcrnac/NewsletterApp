using System.Collections.Generic;
using Newsletter.Model.Topics;
using System.Linq;

namespace Newsletter.Service.TopicService
{
    public class TopicService : ITopicService
    {
        private ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public IEnumerable<Topic> GetTopics()
        {
            return _topicRepository.All.ToList();
        }

        public Topic GetTopic(string id)
        {
            return _topicRepository.Find(id);
        }

        public bool RemoveUser(string id, string userId)
        {
            var dbTopic = this.GetTopic(id);

            if (dbTopic != null)
            {
                var dbUser = dbTopic.Users.SingleOrDefault(p => p.Id == userId);

                if (dbUser != null)
                {
                    dbTopic.Users.Remove(dbUser);

                    _topicRepository.Update(dbTopic);

                    return true;
                }
            }

            return false;
        }
    }
}
