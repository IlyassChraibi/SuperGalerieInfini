using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using VsGalerie.Data;
using VsGalerie.Models;

namespace VsGalerie.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly VsGalerieContext _context;

        public PicturesController(VsGalerieContext context)
        {
            _context = context;
        }

        // GET: api/Pictures
        [HttpGet("{galerieId}")]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPicturesByGalerie(int galerieId)
        {
            var pictures = await _context.Picture.Where(p => p.Galerie.Id == galerieId).ToListAsync();

            if (pictures == null || !pictures.Any())
            {
                return NotFound();
            }

            return pictures;
        }


        // GET: api/Pictures/5
        [HttpGet("{size}/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Picture>> GetPicture(string size, int id)
        {
          if (_context.Picture == null)
          {
              return NotFound();
          }
            var picture = await _context.Picture.FindAsync(id);

            if (picture == null || picture.FileName == null || picture.MimeType == null)
            {
                return NotFound(new { Message = "cette photo n'exitse pas"});
            }

            if (!(Regex.Match(size, "lg|sm").Success))
            {
                return BadRequest(new { Message = "La taille demandée est inadéquate" });
            }
            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + size + "/" + picture.FileName);
            return File(bytes, picture.MimeType);
        }


        // PUT: api/Pictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPicture(int id, Picture picture)
        {
            if (id != picture.Id)
            {
                return BadRequest();
            }

            _context.Entry(picture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PictureExists(id))
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

        // POST: api/Pictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{galerieId}")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Picture>> PostPicture(int galerieId)
        {
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if (file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());

                    Picture picture = new Picture();
                    
                    picture.MimeType = file.ContentType;
                    picture.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    image.Save(Directory.GetCurrentDirectory() + "/images/lg/" + picture.FileName);
                    image.Mutate(i =>
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320}
                    })
                    );

                    image.Save(Directory.GetCurrentDirectory() + "/images/sm/" + picture.FileName);

                    Galerie galerie = await _context.Galerie.FindAsync(galerieId);
                    galerie.Pictures.Add(picture);
                    _context.Picture.Add(picture);
                    await _context.SaveChangesAsync();
                    return Ok(picture);
                }
                else
                {
                    return NotFound(new { Message = "Aucune image fournie" });
                }
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        // POST: api/Pictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{galerieId}")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Picture>> PostCoverPicture(int galerieId)
        {
            try
            {

                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.GetFile("monImage");
                if (file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());
                    
                    Picture picture = new Picture();

                    picture.MimeType = file.ContentType;
                    picture.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    image.Save(Directory.GetCurrentDirectory() + "/images/lg/" + picture.FileName);
                    image.Mutate(i =>
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Width = 320 }
                    })
                    );

                    image.Save(Directory.GetCurrentDirectory() + "/images/sm/" + picture.FileName);

                    Galerie galerie = await _context.Galerie.FindAsync(galerieId);
                   // Mettez à jour l'ID de la couverture avant l'ajout de l'image
                    picture.Galerie = galerie;
                    _context.Picture.Add(picture);
                    await _context.SaveChangesAsync();
                    galerie.CoverId = picture.Id;
                    _context.Entry(picture).State = EntityState.Modified;
                    _context.Update(galerie);
                    await _context.SaveChangesAsync();

                    return Ok(picture);
                }
                else
                {
                    return NotFound(new { Message = "Aucune image fournie" });
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE: api/Pictures/5
        [HttpDelete("{galerieId}/{pictureId}")]
        public async Task<IActionResult> DeletePicture(int galerieId, int pictureId)
        {
            try
            {
                // Récupérer la galerie
                Galerie galerie = await _context.Galerie.FindAsync(galerieId);

                // Vérifier si la galerie existe
                if (galerie == null)
                {
                    return NotFound(new { Message = "La galerie n'existe pas" });
                }

                // Vérifier si la photo existe dans la galerie
                Picture picture = galerie.Pictures.FirstOrDefault(p => p.Id == pictureId);
                if (picture == null)
                {
                    return NotFound(new { Message = "La photo n'existe pas dans la galerie" });
                }

                // Supprimer la référence de la photo dans la galerie
                galerie.Pictures.Remove(picture);

                // Supprimer la photo de la base de données
                _context.Picture.Remove(picture);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "La photo a été supprimée avec succès de la galerie" });
            }
            catch (Exception)
            {
                throw;
            }
        }


        private bool PictureExists(int id)
        {
            return (_context.Picture?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
