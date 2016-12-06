
using System.Collections.Generic;

namespace Newsletter.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set;
        }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<TopicViewModel> Topics { get; set; }
    }
}