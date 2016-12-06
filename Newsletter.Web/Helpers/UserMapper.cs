
using Newsletter.Model.Users;
using Newsletter.Web.Models;
using System.Collections.Generic;

namespace Newsletter.Web.Helpers
{
    public static class UserMapper
    {
        public static List<UserViewModel> MapToUserViewModels(this IEnumerable<User> users)
        {
            var result = new List<UserViewModel>();

            foreach(var u in users)
            {
                result.Add(u.MapToUserViewModel());
            }

            return result;
        }

        public static UserViewModel MapToUserViewModel(this User user)
        {
            if (user == null)
                return null;

            var result = new UserViewModel();

            result = new UserViewModel()
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Topics = user.Topics.MapToTopicViewModels()
            };

            return result;
        }
    }
}