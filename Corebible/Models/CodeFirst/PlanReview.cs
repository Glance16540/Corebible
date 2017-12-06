using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.CodeFirst
{
    public class PlanReview
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }

        public virtual Groups Group { get; set; }
    }
}