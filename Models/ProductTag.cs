namespace OpexShowcase.Models
{
    public class ProductTag
    {
        public int Id { get; set; }
        public string Tag { get; set; } = string.Empty;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
