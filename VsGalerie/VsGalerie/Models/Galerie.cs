using System.Text.Json.Serialization;

namespace VsGalerie.Models
{
    public class Galerie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublic { get; set; }
        [JsonIgnore]
        public virtual List<User>? User { get; set; }

    }
}
