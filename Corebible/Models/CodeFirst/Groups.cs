using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.CodeFirst
{
    public class Groups
    {
        public Groups()
        {
          Comments = new HashSet<Groupcomments>();
        }
        public int Id { get; set; }
        public int MemberCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string OwnerId { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Groupcomments> Comments { get; set; }
    }
}