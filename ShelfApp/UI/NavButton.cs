using System.ComponentModel;

namespace ShelfApp.UI;

// Navigation item with an icon AND a text label
// (Heuristic #6: recognition over recall — v1 had icon-only nav).
public class NavButton : Button
{
    private readonly string _glyph;
    private bool _active;

    public NavButton(string text, string glyph)
    {
        Text = text;
        _glyph = glyph;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Dock = DockStyle.Fill;
        Cursor = Cursors.Hand;
        AccessibleName = text;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Active
    {
        get => _active;
        set
        {
            _active = value;
            AccessibleName = value ? $"{Text}, selected" : Text;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var theme = Theme.Current;
        e.Graphics.Clear(theme.Background);
        var color = _active ? theme.TextPrimary : theme.TextSecondary;

        using var iconFont = new Font(Ui.IconFont, 16);
        using var textFont = new Font(Ui.FontName, 10, _active ? FontStyle.Bold : FontStyle.Regular);
        var flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
        TextRenderer.DrawText(e.Graphics, _glyph, iconFont, new Rectangle(0, 6, Width, 30), color, flags);
        TextRenderer.DrawText(e.Graphics, Text, textFont, new Rectangle(0, 36, Width, 24), color, flags);

        if (Focused && ShowFocusCues)
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(4, 4, Width - 8, Height - 8));
    }
}
