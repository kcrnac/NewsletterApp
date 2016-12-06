using Newsletter.Model.Topics;
using Newsletter.Web.Models;
using System.Collections.Generic;

namespace Newsletter.Web.Helpers
{
    public static class TopicMapper
    {
        public static List<TopicViewModel> MapToTopicViewModels(this IEnumerable<Topic> topics)
        {
            var result = new List<TopicViewModel>();

            foreach (var t in topics)
            {
                result.Add(new TopicViewModel()
                {
                    Title = t.Title,
                    Description = t.Description
                });
            }

            return result;
        }
    }
}