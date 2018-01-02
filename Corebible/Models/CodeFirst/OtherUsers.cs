using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.CodeFirst
{
    public class OtherUsers
    {
        public int Id { get; set; }
        public string Personsprofileid { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}