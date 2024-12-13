namespace HenriksHobbyLager.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public float? Price { get; set; }
        public int? Stock { get; set; }
        public string? Category { get; set; }
        public string? DateCreated { get; set; }
        public string? DateUpdated { get; set; }
    }
}
