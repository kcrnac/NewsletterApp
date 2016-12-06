using Newsletter.Model.Users;
using System;
using System.Collections.Generic;

namespace Newsletter.Service.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> SearchsUsers(string topicTitle);
        User GetUser(string id);
        User UpdateUserDetails(string id, User user);
        bool Subscribe(string id, string topicId);
        bool Unsubscribe(string id, string topicId);
    }
}
