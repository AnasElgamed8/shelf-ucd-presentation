using System.Net.NetworkInformation;
using ShelfApp.Models;

namespace ShelfApp.Services;

public class SellersUnavailableException : Exception
{
    public SellersUnavailableException()
        : base("Couldn't reach sellers. Check connection or try again.") { }
}

// Talks to the (fake) seller APIs. Search and offers need a connection;
// the user's own library does not.
public class BookService
{
    private readonly Func<bool> _isOnline;

    public BookService(Func<bool> isOnline)
    {
        _isOnline = isOnline;
    }

    public static bool HasNetwork() => NetworkInterface.GetIsNetworkAvailable();

    public bool IsOnline => _isOnline();

    public List<Book> Search(string query)
    {
        if (!IsOnline)
            throw new SellersUnavailableException();
        return BookCatalog.Search(query);
    }

    public List<Book> All()
    {
        if (!IsOnline)
            throw new SellersUnavailableException();
        return BookCatalog.Books.ToList();
    }

    public List<Offer> GetOffers(Book book)
    {
        if (!IsOnline)
            throw new SellersUnavailableException();
        return SortLocalFirst(book.Offers);
    }

    // Story 1: local sellers first sorted by price, then overseas sorted by total cost.
    public static List<Offer> SortLocalFirst(IEnumerable<Offer> offers) =>
        offers.OrderBy(o => o.IsLocal ? 0 : 1)
              .ThenBy(o => o.Total)
              .ToList();
}
