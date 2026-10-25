using ShelfApp.Models;

namespace ShelfApp.Services;

// Fake "bookstore API" data. In a real version this would come from the
// marketplace APIs listed in our stakeholder map.
public static class BookCatalog
{
    public static readonly IReadOnlyList<Book> Books =
    [
        new Book
        {
            Id = 1, Title = "Crime and Punishment", Author = "Fyodor Dostoyevsky", Isbn = "9780140449136",
            Pages = 430, Rating = 4.2, Genres = ["Classic", "Fiction"],
            Offers =
            [
                Local("Seller B", 235, "3 days"),
                Local("Seller A", 210, "2 days"),
                Local("Seller C", 260, "3 days"),
                Overseas("Seller D", 300, 90, "9–14 days"),
                Overseas("Seller E", 280, 140, "12–18 days", url: ""), // no deep link -> shows the "Couldn't open seller" path
            ]
        },
        new Book
        {
            Id = 2, Title = "Alice in Wonderland", Author = "Lewis Carroll", Isbn = "9780141439761",
            Pages = 200, Rating = 4.0, Genres = ["Classic", "Fantasy"],
            Offers = [Local("Seller A", 120, "2 days"), Local("Seller C", 105, "4 days"), Overseas("Seller D", 150, 90, "9–14 days")]
        },
        new Book
        {
            Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Isbn = "9780061120084",
            Pages = 281, Rating = 4.3, Genres = ["Classic", "Fiction"],
            Offers = [Local("Seller B", 190, "3 days"), Overseas("Seller D", 210, 90, "9–14 days")]
        },
        new Book
        {
            Id = 4, Title = "If There's No Tomorrow", Author = "Jennifer L. Armentrout", Isbn = "9781484715758",
            Pages = 367, Rating = 3.9, Genres = ["Young Adult"],
            Offers = [Local("Seller A", 275, "2 days"), Local("Seller B", 260, "3 days")]
        },
        new Book
        {
            Id = 5, Title = "War and Peace", Author = "Leo Tolstoy", Isbn = "9780199232765",
            Pages = 1225, Rating = 4.1, Genres = ["Classic", "Historical"],
            Offers = [Local("Seller C", 420, "5 days"), Overseas("Seller D", 380, 90, "9–14 days")]
        },
        new Book
        {
            Id = 6, Title = "Ulysses", Author = "James Joyce", Isbn = "9780199535675",
            Pages = 730, Rating = 3.7, Genres = ["Classic", "Modernist"],
            // Only overseas sellers (Story 1, acceptance criterion 2)
            Offers = [Overseas("Seller E", 310, 140, "12–18 days"), Overseas("Seller D", 330, 90, "9–14 days")]
        },
        new Book
        {
            Id = 7, Title = "Moby-Dick", Author = "Herman Melville", Isbn = "9780142437247",
            Pages = 635, Rating = 3.5, Genres = ["Classic", "Adventure"],
            Offers = [Local("Seller A", 290, "2 days")]
        },
        new Book
        {
            Id = 8, Title = "The Brothers Karamazov", Author = "Fyodor Dostoyevsky", Isbn = "9780374528379",
            Pages = 796, Rating = 4.4, Genres = ["Classic", "Philosophy"],
            Offers = [Local("Seller B", 395, "3 days"), Overseas("Seller D", 360, 90, "9–14 days")]
        },
        new Book
        {
            Id = 9, Title = "Animal Farm", Author = "George Orwell", Isbn = "9780451526342",
            Pages = 112, Rating = 4.0, Genres = ["Classic", "Satire"],
            Offers = [Local("Seller A", 95, "2 days"), Local("Seller C", 85, "4 days")]
        },
        new Book
        {
            Id = 10, Title = "The Little Prince", Author = "Antoine de Saint-Exupéry", Isbn = "9780156012195",
            Pages = 96, Rating = 4.3, Genres = ["Classic", "Fable"],
            Offers = [Local("Seller B", 110, "3 days"), Overseas("Seller D", 120, 90, "9–14 days")]
        },
        new Book
        {
            Id = 11, Title = "The Hobbit", Author = "J.R.R. Tolkien", Isbn = "9780547928227",
            Pages = 310, Rating = 4.3, Genres = ["Fantasy"],
            Offers = [Local("Seller A", 240, "2 days"), Local("Seller C", 225, "4 days"), Overseas("Seller E", 200, 140, "12–18 days")]
        },
        new Book
        {
            Id = 12, Title = "1984", Author = "George Orwell", Isbn = "9780451524935",
            Pages = 328, Rating = 4.2, Genres = ["Classic", "Dystopian"],
            Offers = [Local("Seller B", 180, "3 days")]
        },
    ];

    public static Book? Find(int id) => Books.FirstOrDefault(b => b.Id == id);

    // Search by title, author or ISBN (case-insensitive, partial match).
    public static List<Book> Search(string query)
    {
        query = query.Trim();
        if (query.Length == 0)
            return [];

        string isbnQuery = query.Replace("-", "").Replace(" ", "");
        return Books
            .Where(b => b.Title.Contains(query, StringComparison.OrdinalIgnoreCase)
                     || b.Author.Contains(query, StringComparison.OrdinalIgnoreCase)
                     || b.Isbn == isbnQuery)
            .ToList();
    }

    private static Offer Local(string seller, decimal price, string delivery) => new()
    {
        Seller = seller, Price = price, Delivery = delivery, IsLocal = true,
        Url = $"https://example.com/{seller.Replace(" ", "-").ToLower()}",
    };

    private static Offer Overseas(string seller, decimal price, decimal shipping, string delivery, string? url = null) => new()
    {
        Seller = seller, Price = price, Shipping = shipping, Delivery = delivery, IsLocal = false,
        Url = url ?? $"https://example.com/{seller.Replace(" ", "-").ToLower()}",
    };
}
