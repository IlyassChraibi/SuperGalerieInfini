using System.ComponentModel.DataAnnotations.Schema;

namespace VsGalerie.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? MimeType { get; set; }

        public virtual Galerie? Galerie { get; set; }
    }
}
