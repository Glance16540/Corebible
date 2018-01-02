using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.CodeFirst
{
    public class Groupcomments
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public int GroupId { get; set; }
        public string AuthorId { get; set; }

        public virtual Groups Group { get; set; }
        public ApplicationUser Author { get; set; }
    }
}