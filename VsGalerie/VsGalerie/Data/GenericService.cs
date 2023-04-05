using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VsGalerie.Models;

namespace VsGalerie.Data
{
    public class GenericService<T> where T : Galerie
    {
        protected readonly VsGalerieContext _context;

        public GenericService(VsGalerieContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAll(string userId)
        {

            /*if (_context.Galerie == null)
            {
                return NotFound();
            }*/

            //trouver l'utilisateur via son token
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                return (IEnumerable<T>)user.Galeries;
            }
            //return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Utilisateur non trouvé." });
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> Get(int id)
        {
            if (_context.Set<T>() == null)
            {
                return null;
            }
            var t = await _context.Set<T>().FindAsync(id);
            if(t == null)
            {
                return null;
            }
            return t;
        }


        public virtual async Task<T?> Put(int id, T t)
        {
           _context.Entry(t).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _context.Set<T>().FindAsync(id) == null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return t;
        }

        public virtual async Task<T?> Post(T t, string userId)
        {
            /*if(_context.Set<T>() == null)
            {
                return null;
            }
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();

            return t;*/
            if (_context.Set<T>() == null)
            {
                return null;
            }

            //trouver l'utilisateur via son token
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                // Ajouter la galerie à la liste des galeries de l'utilisateur
                user.Galeries.Add(t);

                // Ajouter l'utilisateur à la liste des utilisateurs de la galerie
                if (t.User == null)
                {
                    t.User = new List<User>();
                }
                t.User.Add(user);

                _context.Set<T>().Add(t);
                await _context.SaveChangesAsync();

                return t;
            }

            return null;
        }

        public virtual async Task Delete(int id)
        {
            if (_context.Set<T>() == null)
            {
                return;
            }
            var t = await _context.Set<T>().FindAsync(id);
            if (t == null)
            {
                return;
            }

            _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
        }

        internal object Any(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
