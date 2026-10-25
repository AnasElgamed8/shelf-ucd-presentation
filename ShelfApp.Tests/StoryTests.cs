using ShelfApp.Models;
using ShelfApp.Services;
using Xunit;

namespace ShelfApp.Tests;

// Each test maps to an acceptance criterion from our user stories.
public class Story1_ComparePricesTests
{
    [Fact]
    public void LocalSellersComeFirst_SortedByPrice()
    {
        var book = BookCatalog.Find(1)!; // Crime and Punishment
        var offers = BookService.SortLocalFirst(book.Offers);

        Assert.Equal(["Seller A", "Seller B", "Seller C"], offers.Take(3).Select(o => o.Seller));
        Assert.All(offers.Take(3), o => Assert.True(o.IsLocal));
        Assert.All(offers.Skip(3), o => Assert.False(o.IsLocal));
    }

    [Fact]
    public void OverseasSellers_AreSortedByTotalIncludingShipping()
    {
        var offers = BookService.SortLocalFirst(
        [
            new Offer { Seller = "Cheap price, big shipping", Price = 100, Shipping = 300 },
            new Offer { Seller = "Higher price, cheap shipping", Price = 200, Shipping = 50 },
        ]);

        Assert.Equal("Higher price, cheap shipping", offers[0].Seller);
    }

    [Fact]
    public void SearchFails_WhenOffline()
    {
        var service = new BookService(() => false);
        Assert.Throws<SellersUnavailableException>(() => service.Search("Crime"));
    }

    [Theory]
    [InlineData("crime and", 1)]
    [InlineData("ORWELL", 2)]
    [InlineData("978-0140449136", 1)]
    [InlineData("no such book", 0)]
    public void Search_MatchesTitleAuthorOrIsbn(string query, int expected)
    {
        var service = new BookService(() => true);
        Assert.Equal(expected, service.Search(query).Count);
    }
}

public class Story3_DropRiskTests
{
    private static readonly Book LongBook = new() { Title = "Long", Pages = 430 };
    private static readonly Book ShortBook = new() { Title = "Short", Pages = 150 };

    [Fact]
    public void FewerThanFiveBooks_NotEnoughHistory()
    {
        var history = new[] { (500, ReadingStatus.Dropped), (600, ReadingStatus.Dropped) };
        var risk = DropRiskCalculator.Calculate(LongBook, history);

        Assert.Equal(RiskLevel.NotEnoughHistory, risk.Level);
        Assert.Contains("Not enough history yet", risk.Reason);
    }

    [Fact]
    public void BooksStillBeingRead_DontCountAsHistory()
    {
        var history = Enumerable.Repeat((500, ReadingStatus.Reading), 10);
        Assert.Equal(RiskLevel.NotEnoughHistory, DropRiskCalculator.Calculate(LongBook, history).Level);
    }

    [Fact]
    public void Dropped3Of4LongBooks_IsHighRisk_WithReason()
    {
        var history = new[]
        {
            (1225, ReadingStatus.Dropped), (730, ReadingStatus.Dropped), (635, ReadingStatus.Dropped),
            (796, ReadingStatus.Finished), (200, ReadingStatus.Finished),
        };
        var risk = DropRiskCalculator.Calculate(LongBook, history);

        Assert.Equal(RiskLevel.High, risk.Level);
        Assert.StartsWith("You dropped 3 of 4", risk.Reason);
    }

    [Fact]
    public void SameHistory_ShortBook_IsLowRisk()
    {
        var history = new[]
        {
            (1225, ReadingStatus.Dropped), (730, ReadingStatus.Dropped), (635, ReadingStatus.Dropped),
            (796, ReadingStatus.Finished), (200, ReadingStatus.Finished),
        };
        Assert.Equal(RiskLevel.Low, DropRiskCalculator.Calculate(ShortBook, history).Level);
    }

    [Fact]
    public void SampleUser_GetsHighRiskForCrimeAndPunishment()
    {
        var risk = DropRiskCalculator.Calculate(BookCatalog.Find(1)!, UserData.CreateSample());
        Assert.Equal(RiskLevel.High, risk.Level);
    }
}

public class ReadingStatsTests
{
    [Fact]
    public void Streak_CountsConsecutiveDays()
    {
        var today = new DateTime(2026, 10, 25);
        var days = new[] { today, today.AddDays(-1), today.AddDays(-2), today.AddDays(-4) };
        Assert.Equal(3, ReadingStats.CurrentStreak(days, today));
    }

    [Fact]
    public void Streak_IsKept_IfYouHaventReadYetToday()
    {
        var today = new DateTime(2026, 10, 25);
        var days = new[] { today.AddDays(-1), today.AddDays(-2) };
        Assert.Equal(2, ReadingStats.CurrentStreak(days, today));
    }

    [Fact]
    public void Streak_IsZero_AfterMissingADay()
    {
        var today = new DateTime(2026, 10, 25);
        Assert.Equal(0, ReadingStats.CurrentStreak([today.AddDays(-2)], today));
    }
}
