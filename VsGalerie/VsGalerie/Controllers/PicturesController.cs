﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPicture()
        {
          if (_context.Picture == null)
          {
              return NotFound();
          }
            return await _context.Picture.ToListAsync();
        }

        // GET: api/Pictures/5
        [HttpGet("{size}/{id}")]
        public async Task<ActionResult<Picture>> GetPicture(int id)
        {
          if (_context.Picture == null)
          {
              return NotFound();
          }
            var picture = await _context.Picture.FindAsync(id);

            if (picture == null)
            {
                return NotFound();
            }

            return picture;
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
        [HttpPost]
        public async Task<ActionResult<Picture>> PostPicture(Picture picture)
        {
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile? file = formCollection.Files.First();
                if (file != null)
                {
                    Image image = Image.Load(file.OpenReadStream());

                    
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

                    _context.Entry(picture).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

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
            return Ok();
        }

        // DELETE: api/Pictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            if (_context.Picture == null)
            {
                return NotFound();
            }
            var picture = await _context.Picture.FindAsync(id);
            if (picture == null)
            {
                return NotFound();
            }

            _context.Picture.Remove(picture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PictureExists(int id)
        {
            return (_context.Picture?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}