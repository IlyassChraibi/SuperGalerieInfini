using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VsGalerie.Models;

namespace VsGalerie.Data
{
    public class VsGalerieContext : IdentityDbContext<User>
    {
        public VsGalerieContext (DbContextOptions<VsGalerieContext> options)
            : base(options)
        {

        }

        public DbSet<VsGalerie.Models.Galerie> Galerie { get; set; } = default!;
    }
}
