using ShelfApp.Models;
using ShelfApp.Services;

namespace ShelfApp.UI.Views;

// Book detail: drop-risk warning (Story 3), best price, compare + add to library.
public class BookDetailView : ViewBase
{
    private readonly Book _book;

    public BookDetailView(MainForm app, Book book) : base(app)
    {
        _book = book;
        Add(Ui.Header("Book Details", back: App.GoBack));

        int infoWidth = Ui.ContentWidth - 200;
        var genres = Ui.Row(book.Genres.Select(g => (Control)Ui.Badge(g, T.TextSecondary, T.SurfaceElevated)).ToArray());
        Add(Ui.Row(
            Ui.Cover(book, 160, 220),
            Ui.Column(
                Ui.Text(book.Title, 18, FontStyle.Bold, maxWidth: infoWidth),
                Ui.Text(book.Author, 12, color: T.TextSecondary, maxWidth: infoWidth),
                Ui.Secondary($"★ {book.Rating:0.0} · {book.Pages} pages"),
                genres)));

        if (!App.DismissedWarnings.Contains(book.Id))
            Add(DropRiskCard());

        Add(BestPriceCard());

        Add(Ui.SecondaryButton("Compare all prices", () => App.ShowOffers(book), Ui.ContentWidth));

        if (App.GetEntry(book.Id) == null)
        {
            Add(Ui.PrimaryButton("Add to library", AddToLibrary, Ui.ContentWidth));
        }
        else
        {
            var inLibrary = Ui.PrimaryButton("✓ In your library", () => { }, Ui.ContentWidth);
            inLibrary.Enabled = false;
            Add(inLibrary);
        }
    }

    // Icon + text + reason, never colour alone (accessibility checklist #4).
    private Control DropRiskCard()
    {
        var risk = DropRiskCalculator.Calculate(_book, App.Data);
        var (glyph, title, fg, bg) = risk.Level switch
        {
            RiskLevel.High => ("", "DROP RISK: HIGH", T.Error, T.ErrorBg),
            RiskLevel.Medium => ("", "DROP RISK: MEDIUM", T.Warning, T.WarningBg),
            RiskLevel.Low => ("", "DROP RISK: LOW", T.Success, T.SuccessBg),
            _ => ("", "DROP RISK: NOT AVAILABLE", T.TextSecondary, T.Surface),
        };

        var card = Ui.Card(background: bg, children:
        [
            Ui.Row(Ui.Icon(glyph, 18, fg), Ui.Text(title, 14, FontStyle.Bold, fg)),
            Ui.Text(risk.Reason, 12),
            Ui.LinkButton("Dismiss", () =>
            {
                App.DismissedWarnings.Add(_book.Id);
                App.RenderCurrent();
            }, fg),
        ]);
        card.Margin = new Padding(0, 16, 0, 16);
        card.AccessibleRole = risk.Level == RiskLevel.High ? AccessibleRole.Alert : AccessibleRole.Grouping;
        card.AccessibleName = $"{title}. {risk.Reason}";
        return card;
    }

    private Control BestPriceCard()
    {
        try
        {
            var best = App.Books.GetOffers(_book).FirstOrDefault();
            if (best == null)
                return Ui.Card(children: [Ui.Secondary("No sellers have this book right now.")]);

            string delivery = best.IsLocal ? $"{best.Delivery} delivery" : $"Overseas · incl. shipping · {best.Delivery}";
            return Ui.Card(children:
            [
                Ui.Secondary("Best price"),
                Ui.Text($"{best.Seller} · EGP {best.Total:N0}", 20, FontStyle.Bold),
                Ui.Text(delivery, 11, color: best.IsLocal ? T.Success : T.Warning),
            ]);
        }
        catch (SellersUnavailableException ex)
        {
            return Ui.Card(background: T.ErrorBg, children:
            [
                Ui.Text(ex.Message, 11),
                Ui.PrimaryButton("Retry", App.RenderCurrent, 160),
            ]);
        }
    }

    private void AddToLibrary()
    {
        var risk = DropRiskCalculator.Calculate(_book, App.Data);
        if (risk.Level == RiskLevel.High &&
            !ConfirmDialog.Ask(this, "High drop risk",
                "This book has a high drop risk for you. Add anyway?", "Add anyway"))
        {
            return;
        }

        App.AddToLibrary(_book);
        App.RenderCurrent();
    }
}
