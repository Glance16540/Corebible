﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Corebible.Models.CodeFirst
{
    public class Friends
    {
        public int Id { get; set; }
        public string PersonUserId { get; set; }

        public virtual ApplicationUser Friend { get; set; }
        
    }
}