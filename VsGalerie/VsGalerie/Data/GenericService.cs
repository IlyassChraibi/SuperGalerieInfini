using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
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


        public async Task<T?> Put(int id, T t, string userId) 
        {
            // Rechercher l'utilisateur dans la base de données
            User user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return null; // Retourner null si l'utilisateur n'est pas trouvé
            }

            // Vérifier si la galerie existe
            T existingGalerie = await _context.FindAsync<T>(id);
            if (existingGalerie == null)
            {
                return null;
            }

            // Vérifier si l'utilisateur est propriétaire de la galerie
            PropertyInfo userIdProperty = existingGalerie.GetType().GetProperty("UserId");
            if (userIdProperty != null)
            {
                string existingUserId = userIdProperty.GetValue(existingGalerie)?.ToString();
                if (existingUserId != userId)
                {
                    return null;
                }
            }

            // Mettre à jour la visibilité de la galerie
            PropertyInfo isPublicProperty = existingGalerie.GetType().GetProperty("IsPublic");
            if (isPublicProperty != null)
            {
                // Inverser la valeur de la propriété 'IsPublic' de la galerie existante
                isPublicProperty.SetValue(existingGalerie, !(bool)isPublicProperty.GetValue(existingGalerie));
            }

            // Mettre à jour la galerie dans la base de données
            _context.Update(existingGalerie);
            await _context.SaveChangesAsync();

            return existingGalerie;
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
