using Newsletter.Service.TopicService;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Newsletter.Web.Helpers
{
    public static class DropdownHelper
    {
        public static List<SelectListItem> TopicsForDropdown(ITopicService topicService, bool showEmpty = false)
        {
            var list = topicService.GetTopics()
                    .OrderBy(p => p.Title)
                    .Select(p => new SelectListItem { Text = p.Title, Value = p.Id.ToString() })
                    .ToList();

            if (showEmpty)
                list.Insert(0, new SelectListItem { Value = null, Text = "All Topics" });

            return list;
        }
    }
}