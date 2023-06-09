﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VsGalerie.Data;
using VsGalerie.Models;

namespace VsGalerie.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GaleriesController : ControllerBase
    {
        private readonly GaleriesService GaleriesService;
        protected readonly VsGalerieContext _context;

        public GaleriesController(GaleriesService galeriesService, VsGalerieContext context)
        {
            GaleriesService = galeriesService;
            _context = context;
        }

        // GET: api/Galeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetGalerie()
        {
            /*if (_context.Galerie == null)
            {
                return NotFound();
            }

              //trouver l'utilisateur via son token
              string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
              User? user = await _context.Users.FindAsync(userId);

              if (user != null)
              {
                  return user.Galeries;
              }
              return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });*/

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
            }
            return Ok(await GaleriesService.GetAll(userId));
        }

        // GET: api/GaleriesPublic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetGaleriePublic()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
            }

            // Récupérer toutes les galeries publiques
            List<Galerie> publicGaleries = await _context.Galerie
                .Where(g => g.IsPublic)
                .ToListAsync();

            // Récupérer toutes les galeries de l'utilisateur connecté
            List<Galerie> userGaleries = await _context.Galerie
                .Where(g => g.User.Contains(user))
                .ToListAsync();

            // Supprimer les galeries de l'utilisateur connecté de la liste des galeries publiques
            foreach (Galerie galerie in userGaleries)
            {
                publicGaleries.Remove(galerie);
            }

            return publicGaleries;
        }

        // GET: api/Galeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galerie>> GetGalerie(int id)
        {
            /* if (_context.Galerie == null)
             {
                 return NotFound();
             }
               var galerie = await _context.Galerie.FindAsync(id);

               if (galerie == null)
               {
                   return NotFound();
               }

               return galerie;*/
            Galerie? galerie = await GaleriesService.Get(id);
            return Ok(galerie);
        }

        // PUT: api/Galeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalerie(int id, Galerie galerie)
        {
            // Récupérer l'ID de l'utilisateur actuellement connecté
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            // Vérifier si la galerie appartient à l'utilisateur connecté
            Galerie existingGalerie = await _context.Galerie.FindAsync(id);
            if (existingGalerie == null)
            {
                return NotFound(); // Retourner un statut 404 Not Found si la galerie n'est pas trouvée
            }

            if (!existingGalerie.User.Any(u => u.Id == userId))
            {
                return Forbid(); // Retourner un statut 403 Forbidden si la galerie n'appartient pas à l'utilisateur connecté
            }

            // Mettre à jour la visibilité de la galerie
            existingGalerie.IsPublic = galerie.IsPublic;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Galerie.FindAsync(id) == null)
                {
                    return NotFound(); // Retourner un statut 404 Not Found si la galerie n'est pas trouvée
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); // Retourner un statut 204 No Content pour indiquer que la mise à jour a réussi
        }

        [HttpPut("PutGalerie/{id}/{username}")]
        public async Task<ActionResult<Galerie>> PutGalerieCollabo(int id, string username)
        {
            var galerie = await _context.Galerie.FindAsync(id);
            if (galerie == null)
            {
                return NotFound();
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            User UserPartager = _context.Users.FirstOrDefault(u => u.NormalizedUserName == username.ToUpper());

            if (galerie.User.Contains(UserPartager))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { MessagePack = "Utilisateur déjà partagé"}); 
            }

            if (UserPartager == null)
            {
                return BadRequest("User not found.");
            }

            galerie.User.Add(UserPartager);
            await _context.SaveChangesAsync();

            return galerie;
        }


        // POST: api/Galeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galerie>> PostGalerie(Galerie galerie)
        {
            /* if (_context.Galerie == null)
             {
                 return Problem("Entity set 'VsGalerieContext.Galerie'  is null.");
             }

               //trouver l'utilisateur via son token
               string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
               User? user = await _context.Users.FindAsync(userId);

               if(user != null)
               {
                   if (galerie.User == null)
                   {
                       galerie.User = new List<User>();
                   }
                   galerie.User.Add(user);
                   user.Galeries.Add(galerie);

                   // On ajoute l'objet dan sla BD
                   _context.Galerie.Add(galerie);
                   await _context.SaveChangesAsync();
                   return CreatedAtAction("GetGalerie", new { id = galerie.Id }, galerie);
               }

               return StatusCode(StatusCodes.Status400BadRequest, new {Message = "Utilisateur non trouvé."});*/
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Galerie? newGalerie = await GaleriesService.Post(galerie,userId);
            if (newGalerie == null)
            {
                return Problem("Entity set 'labo8VsContext.Cat'  is null.");
            }

            return CreatedAtAction("GetGalerie", new { id = galerie.Id }, newGalerie);

        }

       

        // DELETE: api/Galeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalerie(int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            // Vérifier si la galerie appartient à l'utilisateur connecté
            Galerie existingGalerie = await _context.Galerie.FindAsync(id);
            if (existingGalerie == null)
            {
                return NotFound(); // Retourner un statut 404 Not Found si la galerie n'est pas trouvée
            }

            if (!existingGalerie.User.Any(u => u.Id == userId))
            {
                return Forbid(); // Retourner un statut 403 Forbidden si la galerie n'appartient pas à l'utilisateur connecté
            }

            _context.Galerie.Remove(existingGalerie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalerieExists(int id)
        {
            return (_context.Galerie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
