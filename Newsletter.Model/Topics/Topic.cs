using Newsletter.Model.Base;
using Newsletter.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Newsletter.Model.Topics
{
    public class Topic : EntityBase
    {
        #region Properties

        public string Title { get; set; }

        public string Description { get; set; }

        #endregion

        #region Foreign keys

        [ForeignKey("Type")]
        public string TypeId { get; set; }

        #endregion

        #region Navigation properties

        public virtual TopicSubType Type { get; set; }


        public virtual ICollection<User> Users { get; set; }

        #endregion

    }
}
