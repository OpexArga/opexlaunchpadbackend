namespace OpexShowcase.Models;
public class UserProduct
{
    public int UserId { get; set; }
    public required User User { get; set; }

    public int ProductId { get; set; }
    public required Product Product { get; set; }
}