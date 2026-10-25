namespace ShelfApp.Models;

public class Book
{
    public int Id { get; init; }
    public string Title { get; init; } = "";
    public string Author { get; init; } = "";
    public string Isbn { get; init; } = "";
    public int Pages { get; init; }
    public double Rating { get; init; }
    public string[] Genres { get; init; } = [];
    public List<Offer> Offers { get; init; } = [];
}

// One seller's offer for a book (Story 1: Compare Prices).
public class Offer
{
    public string Seller { get; init; } = "";
    public decimal Price { get; init; }
    public decimal Shipping { get; init; }
    public string Delivery { get; init; } = "";
    public bool IsLocal { get; init; }
    public string Url { get; init; } = "";

    // Overseas sellers are compared by total cost (price + shipping).
    public decimal Total => Price + Shipping;
}
