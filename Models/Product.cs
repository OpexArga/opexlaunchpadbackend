namespace OpexShowcase.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty; // ✅ Added

        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public decimal Price { get; set; }

        // Navigation
        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
