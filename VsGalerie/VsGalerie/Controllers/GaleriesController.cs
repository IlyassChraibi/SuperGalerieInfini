using System;
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
        private readonly VsGalerieContext _context;

        public GaleriesController(VsGalerieContext context)
        {
            _context = context;
        }

        // GET: api/Galeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Galerie>>> GetGalerie()
        {
          if (_context.Galerie == null)
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
            return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
        }

        // GET: api/Galeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Galerie>> GetGalerie(int id)
        {
          if (_context.Galerie == null)
          {
              return NotFound();
          }
            var galerie = await _context.Galerie.FindAsync(id);

            if (galerie == null)
            {
                return NotFound();
            }

            return galerie;
        }

        // PUT: api/Galeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalerie(int id, Galerie galerie)
        {
            if (id != galerie.Id)
            {
                return BadRequest();
            }

            _context.Entry(galerie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalerieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Galeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Galerie>> PostGalerie(Galerie galerie)
        {
          if (_context.Galerie == null)
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

            return StatusCode(StatusCodes.Status400BadRequest, new {Message = "Utilisateur non trouvé."});

        }

        // DELETE: api/Galeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalerie(int id)
        {
            if (_context.Galerie == null)
            {
                return NotFound();
            }
            var galerie = await _context.Galerie.FindAsync(id);
            if (galerie == null)
            {
                return NotFound();
            }

            _context.Galerie.Remove(galerie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GalerieExists(int id)
        {
            return (_context.Galerie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
