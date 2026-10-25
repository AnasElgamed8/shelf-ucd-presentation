using ShelfApp.Models;

namespace ShelfApp.UI;

// Themed confirmation box with custom button labels
// (e.g. [Cancel] [Add anyway]) instead of MessageBox's Yes/No.
public class ConfirmDialog : Form
{
    public ConfirmDialog(string title, string message, string confirmText, string cancelText = "Cancel")
    {
        var theme = Theme.Current;
        Text = title;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = theme.Surface;
        Padding = new Padding(24);

        var confirm = Ui.PrimaryButton(confirmText, () => { DialogResult = DialogResult.OK; Close(); }, 160);
        var cancel = Ui.SecondaryButton(cancelText, () => { DialogResult = DialogResult.Cancel; Close(); }, 160);

        var layout = Ui.Column(
            Ui.Text(title, 14, FontStyle.Bold, maxWidth: 400),
            Ui.Text(message, 11, maxWidth: 400),
            Ui.Row(cancel, confirm));
        Controls.Add(layout);

        // Cancel is the safe default for Enter and Esc (error prevention).
        AcceptButton = cancel;
        CancelButton = cancel;
    }

    public static bool Ask(IWin32Window owner, string title, string message, string confirmText, string cancelText = "Cancel")
    {
        using var dialog = new ConfirmDialog(title, message, confirmText, cancelText);
        return dialog.ShowDialog(owner) == DialogResult.OK;
    }
}

// "Which page are you on?" — used by Continue Reading and the Library.
public class ProgressDialog : Form
{
    private readonly NumericUpDown _page;

    public int Page => (int)_page.Value;

    public ProgressDialog(Book book, int currentPage)
    {
        var theme = Theme.Current;
        Text = "Log progress";
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        BackColor = theme.Surface;
        Padding = new Padding(24);

        var label = Ui.Text($"Which page of \"{book.Title}\" are you on? (1–{book.Pages})", 11, maxWidth: 400);
        _page = new NumericUpDown
        {
            Minimum = 0,
            Maximum = book.Pages,
            Value = Math.Clamp(currentPage, 0, book.Pages),
            Width = 160,
            Font = new Font(Ui.FontName, 14),
            AccessibleName = "Current page",
            BackColor = theme.SurfaceElevated,
            ForeColor = theme.TextPrimary,
            Margin = new Padding(0, 8, 0, 8),
        };
        _page.Select(0, _page.Text.Length);

        var save = Ui.PrimaryButton("Save", () => { DialogResult = DialogResult.OK; Close(); }, 140);
        var cancel = Ui.SecondaryButton("Cancel", () => { DialogResult = DialogResult.Cancel; Close(); }, 140);

        Controls.Add(Ui.Column(label, _page, Ui.Row(cancel, save)));
        AcceptButton = save;
        CancelButton = cancel;
    }
}
