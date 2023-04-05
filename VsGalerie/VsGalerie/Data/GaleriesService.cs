using VsGalerie.Models;

namespace VsGalerie.Data
{
    public class GaleriesService : GenericService<Galerie>
    {
        protected readonly VsGalerieContext context1;

        public GaleriesService(VsGalerieContext context) : base(context)
        {
            context1 = context;
        }

        public virtual async Task DeleteAll()
        {
            context1.Set<Galerie>().RemoveRange(context1.Galerie);
            await context1.SaveChangesAsync();
        }
    }
}
