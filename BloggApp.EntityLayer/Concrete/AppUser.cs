﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggApp.EntityLayer.Concrete
{
    public class AppUser:IdentityUser
    {
        public ICollection<Article> Articles { get; set; }
    }
}