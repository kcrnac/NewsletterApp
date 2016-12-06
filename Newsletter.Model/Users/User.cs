using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newsletter.Model.Topics;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newsletter.Model.Users
{
    public class User : IdentityUser
    {
        #region Private members

        private ICollection<Topic> _topics;

        #endregion

        #region Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Email is inherited from IdentityUser base class.

        // PhoneNumber is inherited from IdentityUser base class.

        public DateTime DateCreated { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        #endregion

        #region Navigation properties

        public virtual ICollection<Topic> Topics
        {
            get { return _topics ?? new List<Topic>(); }
            set
            {
                _topics = value;
            }
        }
        
        #endregion

        #region Ctor

        public User()
        {
            DateCreated = DateTime.Now;
            Topics = new List<Topic>();
        }

        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
