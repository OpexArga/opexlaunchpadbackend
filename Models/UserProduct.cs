namespace OpexShowcase.Models;
public class UserProduct
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // 👇 URL path seperti: saas0001_opexai
    public string AccessPath { get; set; } = string.Empty;

    // (Optional) Status aktif/expired ke depannya
    public bool IsActive { get; set; } = true;
}
