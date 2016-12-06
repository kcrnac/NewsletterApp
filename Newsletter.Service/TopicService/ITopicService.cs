using Newsletter.Model.Topics;
using System;
using System.Collections.Generic;

namespace Newsletter.Service.TopicService
{
    public interface ITopicService
    {
        IEnumerable<Topic> GetTopics();
        Topic GetTopic(string id);
        bool RemoveUser(string id, string userId);
    }
}
