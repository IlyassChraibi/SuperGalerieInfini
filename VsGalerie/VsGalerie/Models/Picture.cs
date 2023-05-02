namespace VsGalerie.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? FileName { get; set; }
        public string? MimeType { get; set; }
    }
}
