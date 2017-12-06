using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.CodeFirst
{
    public class Plans
    {
        public int Id { get; set; }
        public string Tags { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int DaystoComplete { get; set; }
        public string Author { get; set; }
        public bool Started { get; set; }

        public virtual ICollection<PlanReview> planreviews { get; set; }
    }
}