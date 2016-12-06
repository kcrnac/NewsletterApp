using System;
using System.ComponentModel.DataAnnotations;

namespace Newsletter.Model.Base
{
    public class EntityBase
    {
        [Key]
        public string Id { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
