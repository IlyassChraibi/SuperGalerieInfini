using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                // Primary key au format GUID
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "ilyass",
                Email = "i.i@i.ca",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "I.I@I.CA",
                NormalizedUserName = "ILYASS"
            };
            // On encrypte le mot de passe
            u1.PasswordHash = hasher.HashPassword(u1, "123456");

            User u2 = new User
            {
                // Primary key au format GUID
                Id = "21111111-1111-1111-1111-111111111112",
                UserName = "ilyas",
                Email = "i.i@i.ca",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "I.I@I.CA",
                NormalizedUserName = "ILYAS"
            };
            // On encrypte le mot de passe
            u2.PasswordHash = hasher.HashPassword(u2, "123456");

            builder.Entity<User>().HasData(u2);
            builder.Entity<User>().HasData(u1);

            builder.Entity<Galerie>().HasData(new Galerie()
            {
                Id = 1,
                Name = "tableau",
                IsPublic = true,
            }, new Galerie{
                Id = 2,
                Name = "tableau2",
                IsPublic = false,
            }, 
            new Galerie
            {
                Id = 3,
                Name = "sym1",
                IsPublic = false,
            }, new Galerie
            {
                Id = 4,
                Name = "sym2",
                IsPublic = false,
            });

            builder.Entity<Galerie>().HasMany(c => c.User).
                WithMany(t => t.Galeries).
                UsingEntity(r => {
                    r.HasData(new { UserId = u1.Id, GaleriesId = 1 });
                    r.HasData(new { UserId = u1.Id, GaleriesId = 2 });
                    r.HasData(new { UserId = u2.Id, GaleriesId = 3 });
                    r.HasData(new { UserId = u2.Id, GaleriesId = 4 });
                });

        }

        public DbSet<VsGalerie.Models.Galerie> Galerie { get; set; } = default!;
    }
}
