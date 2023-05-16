using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VsGalerie.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? MimeType { get; set; }

        [JsonIgnore]
        public virtual Galerie? Galerie { get; set; }
    }
}
