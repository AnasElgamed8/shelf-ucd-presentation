using System.Diagnostics;
using ShelfApp.Models;

namespace ShelfApp.UI.Views;

// Story 1: all sellers for one book — local first by price, then overseas by total cost.
public class OffersView : ViewBase
{
    public OffersView(MainForm app, Book book) : base(app)
    {
        Add(Ui.Header($"Results: {book.Title}", back: App.GoBack));

        List<Offer> offers;
        try
        {
            offers = App.Books.GetOffers(book);
        }
        catch (Services.SellersUnavailableException ex)
        {
            Add(Ui.Card(background: T.ErrorBg, children:
            [
                Ui.Row(Ui.Icon("", 16, T.Error), Ui.Text(ex.Message, 11)),
                Ui.PrimaryButton("Retry", App.RenderCurrent, 160),
            ]));
            return;
        }

        var local = offers.Where(o => o.IsLocal).ToList();
        var overseas = offers.Where(o => !o.IsLocal).ToList();

        if (local.Count > 0)
        {
            Add(Ui.Overline($"Local sellers ({local.Count})"));
            foreach (var offer in local)
                Add(OfferCard(offer));
        }
        else
        {
            Add(Ui.Secondary("No local seller has this book. Showing overseas sellers (price includes shipping)."));
        }

        if (overseas.Count > 0)
        {
            if (local.Count > 0)
                Add(Ui.Divider());
            Add(Ui.Overline($"Overseas sellers ({overseas.Count})"));
            foreach (var offer in overseas)
                Add(OfferCard(offer));
        }

        if (offers.Count == 0)
            Add(Ui.Secondary("No sellers have this book right now. Try again later."));
    }

    private Control OfferCard(Offer offer)
    {
        int inner = Ui.ContentWidth - 32;
        var badge = offer.IsLocal
            ? Ui.Badge("Local", T.Success, T.SuccessBg)
            : Ui.Badge("Overseas", T.Warning, T.WarningBg);
        string details = offer.IsLocal
            ? $"·  {offer.Delivery}"
            : $"·  EGP {offer.Price:N0} + EGP {offer.Shipping:N0} shipping, {offer.Delivery}";

        return Ui.Card(children:
        [
            Ui.SplitRow(Ui.Text(offer.Seller, 13), badge, inner),
            Ui.Row(Ui.Text($"EGP {offer.Total:N0}", 22, FontStyle.Bold), WithTopMargin(Ui.Secondary(details), 12)),
            Ui.PrimaryButton("Select", () => OpenSeller(offer)),
        ]);
    }

    private static Control WithTopMargin(Control control, int top)
    {
        control.Margin = new Padding(8, top, 0, 0);
        return control;
    }

    // Error path 2 of the user flow: the seller link fails -> offer to copy it.
    private void OpenSeller(Offer offer)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(offer.Url))
                throw new InvalidOperationException("Seller has no link.");
            Process.Start(new ProcessStartInfo(offer.Url) { UseShellExecute = true });
        }
        catch (Exception ex) when (ex is InvalidOperationException or System.ComponentModel.Win32Exception)
        {
            string link = string.IsNullOrWhiteSpace(offer.Url) ? $"{offer.Seller} (no link available)" : offer.Url;
            if (ConfirmDialog.Ask(this, "Couldn't open seller", "Couldn't open seller. Copy link?", "Copy link", "Dismiss"))
                Clipboard.SetText(link);
        }
    }
}
