namespace Adresgegevens.Models
{
    public partial class Adresgegeven
    {
        public long Id { get; set; }
        public string? Straat { get; set; }
        public long? Huisnummer { get; set; }
        public string? Postcode { get; set; }
        public string? Plaats { get; set; }
        public string? Land { get; set; }
    }
}
