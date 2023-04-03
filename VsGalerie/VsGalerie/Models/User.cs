﻿using Microsoft.AspNetCore.Identity;

namespace VsGalerie.Models
{
    public class User : IdentityUser
    {
        public virtual List<Galerie> Galeries { get; set; } = null!;
    }
}
