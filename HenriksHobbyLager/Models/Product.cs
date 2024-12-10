namespace HenriksHobbyLager.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; }
        public DateTime LastUpdated { get; }
    }