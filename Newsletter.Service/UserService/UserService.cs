using Newsletter.Model.Topics;
using Newsletter.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Newsletter.Service.UserService
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ITopicRepository _topicRepository;

        public UserService(IUserRepository userRepository, ITopicRepository topicRepository)
        {
            _userRepository = userRepository;
            _topicRepository = topicRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.All.ToList();
        }

        public IEnumerable<User> SearchsUsers(string topicTitle)
        {
            return _userRepository.All.Where(p => p.Topics.Any(t => t.Title.Contains(topicTitle))).ToList();
        }

        public User GetUser(string id)
        {
            return _userRepository.Find(id);
        }

        public User UpdateUserDetails(string id, User user)
        {
            var dbUser = this.GetUser(id);

            if(dbUser != null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.PhoneNumber = user.PhoneNumber;

                _userRepository.Update(dbUser);
            }

            return dbUser;
        }

        public bool Subscribe(string id, string topicId)
        {
            var dbUser = this.GetUser(id);

            if (dbUser != null)
            {
                var dbTopic = _topicRepository.Find(topicId);

                if (dbTopic != null)
                {
                    dbUser.Topics.Add(dbTopic);

                    _userRepository.Update(dbUser);

                    return true;
                }
            }

            return false;
        }

        public bool Unsubscribe(string id, string topicId)
        {
            var dbUser = this.GetUser(id);

            if(dbUser != null)
            {
                var dbTopic = dbUser.Topics.SingleOrDefault(p => p.Id == topicId);

                if(dbTopic != null)
                {
                    dbUser.Topics.Remove(dbTopic);

                    _userRepository.Update(dbUser);

                    return true;
                }
            }

            return false;
        }

    }
}
