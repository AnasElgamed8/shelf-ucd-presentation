using ShelfApp.Models;
using ShelfApp.Services;

namespace ShelfApp.UI;

// Small factory methods so every screen uses the same fonts, colours and sizes.
public static class Ui
{
    public const int ContentWidth = 720;
    public const string FontName = "Segoe UI";
    public const string IconFont = "Segoe MDL2 Assets";

    private static Theme T => Theme.Current;

    public static Label Text(string text, float size = 11, FontStyle style = FontStyle.Regular,
                             Color? color = null, int maxWidth = ContentWidth)
    {
        return new Label
        {
            Text = text,
            AutoSize = true,
            MaximumSize = new Size(maxWidth, 0),
            Font = new Font(FontName, size, style),
            ForeColor = color ?? T.TextPrimary,
            BackColor = Color.Transparent,
            Margin = new Padding(0, 2, 0, 2),
        };
    }

    public static Label Secondary(string text, float size = 10.5f, int maxWidth = ContentWidth) =>
        Text(text, size, FontStyle.Regular, T.TextSecondary, maxWidth);

    // Section title, e.g. "RECOMMENDED FOR YOU"
    public static Label Overline(string text)
    {
        var label = Text(text.ToUpper(), 10, FontStyle.Bold);
        label.Margin = new Padding(0, 20, 0, 8);
        return label;
    }

    public static Label Icon(string glyph, float size, Color color) => new()
    {
        Text = glyph,
        AutoSize = true,
        Font = new Font(IconFont, size),
        ForeColor = color,
        BackColor = Color.Transparent,
        Margin = new Padding(0, 4, 8, 0),
        AccessibleRole = AccessibleRole.Graphic,
    };

    public static Button PrimaryButton(string text, Action onClick, int width = ContentWidth - 32)
    {
        var button = BaseButton(text, onClick, width);
        button.BackColor = T.Primary;
        button.ForeColor = T.OnPrimary;
        button.FlatAppearance.BorderSize = 0;
        return button;
    }

    public static Button SecondaryButton(string text, Action onClick, int width = ContentWidth - 32)
    {
        var button = BaseButton(text, onClick, width);
        button.BackColor = Color.Transparent; // takes the colour of the card it sits on
        button.ForeColor = T.TextPrimary;
        button.FlatAppearance.BorderColor = T.Primary;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.MouseOverBackColor = T.SurfaceElevated;
        return button;
    }

    // Text-only button (e.g. "Dismiss", "← Back")
    public static Button LinkButton(string text, Action onClick, Color? color = null)
    {
        var button = BaseButton(text, onClick, 0);
        button.AutoSize = true;
        button.MinimumSize = new Size(0, 40);
        button.BackColor = Color.Transparent;
        button.ForeColor = color ?? T.TextPrimary;
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseOverBackColor = T.SurfaceElevated;
        return button;
    }

    private static Button BaseButton(string text, Action onClick, int width)
    {
        var button = new Button
        {
            Text = text,
            AccessibleName = text,
            FlatStyle = FlatStyle.Flat,
            Font = new Font(FontName, 11, FontStyle.Bold),
            Size = new Size(width, 48), // touch-target size from our accessibility checklist
            Cursor = Cursors.Hand,
            Margin = new Padding(0, 6, 8, 6),
            UseVisualStyleBackColor = false,
        };
        button.Click += (_, _) => onClick();
        return button;
    }

    // A rounded-looking box on the surface colour that stacks its children vertically.
    public static FlowLayoutPanel Card(int width = ContentWidth, Color? background = null, params Control[] children)
    {
        var card = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            MinimumSize = new Size(width, 0),
            MaximumSize = new Size(width, 0),
            Padding = new Padding(16),
            Margin = new Padding(0, 0, 16, 16),
            BackColor = background ?? T.Surface,
        };
        card.Controls.AddRange(children);
        return card;
    }

    public static FlowLayoutPanel Row(params Control[] children)
    {
        var row = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            Margin = new Padding(0),
            BackColor = Color.Transparent,
        };
        row.Controls.AddRange(children);
        return row;
    }

    public static FlowLayoutPanel Column(params Control[] children)
    {
        var column = Row(children);
        column.FlowDirection = FlowDirection.TopDown;
        return column;
    }

    // One control on the left, one on the right ("space-between").
    public static Panel SplitRow(Control left, Control right, int width)
    {
        left.Dock = DockStyle.Left;
        right.Dock = DockStyle.Right;
        var panel = new Panel
        {
            Width = width,
            Height = Math.Max(left.PreferredSize.Height, right.PreferredSize.Height),
            Margin = new Padding(0, 2, 0, 2),
            BackColor = Color.Transparent,
        };
        panel.Controls.Add(left);
        panel.Controls.Add(right);
        return panel;
    }

    // Screen title with an optional "← Back" button and optional control on the right.
    public static Panel Header(string title, Action? back = null, Control? right = null)
    {
        var titleLabel = Text(title, 20, FontStyle.Bold);
        var left = Row();
        if (back != null)
            left.Controls.Add(LinkButton("←  Back", back));
        left.Controls.Add(titleLabel);
        var header = SplitRow(left, right ?? new Panel { Width = 1, BackColor = Color.Transparent }, ContentWidth);
        header.Height = Math.Max(header.Height, 48);
        header.Margin = new Padding(0, 0, 0, 16);
        return header;
    }

    public static Label Badge(string text, Color foreground, Color background) => new()
    {
        Text = text,
        AutoSize = true,
        Font = new Font(FontName, 9.5f, FontStyle.Bold),
        ForeColor = foreground,
        BackColor = background,
        Padding = new Padding(8, 4, 8, 4),
        Margin = new Padding(0, 4, 6, 4),
    };

    // Drop risk badge: coloured dot + text, so meaning never depends on colour alone.
    public static Label RiskBadge(RiskLevel level) => level switch
    {
        RiskLevel.High => Badge("● High Risk", T.Error, T.ErrorBg),
        RiskLevel.Medium => Badge("● Med Risk", T.Warning, T.WarningBg),
        RiskLevel.Low => Badge("● Low Risk", T.Success, T.SuccessBg),
        _ => Badge("● Risk: not enough history", T.TextSecondary, T.SurfaceElevated),
    };

    // Placeholder book cover: coloured box with the title in the corner.
    public static Panel Cover(Book book, int width, int height)
    {
        Color[] colours = [Hex(0x2A2A2A), Hex(0x3A2E40), Hex(0x3A3424), Hex(0x3A2A26), Hex(0x24323A), Hex(0x2C3A2A)];
        var cover = new Panel
        {
            Size = new Size(width, height),
            BackColor = colours[book.Id % colours.Length],
            Margin = new Padding(0, 0, 16, 8),
            AccessibleName = $"Cover of {book.Title}",
            AccessibleRole = AccessibleRole.Graphic,
        };
        var label = new Label
        {
            Text = book.Title,
            Dock = DockStyle.Bottom,
            AutoSize = false,
            Height = Math.Min(height / 2, 48),
            Font = new Font(FontName, width < 100 ? 7.5f : 9, FontStyle.Bold),
            ForeColor = Color.FromArgb(0xF5, 0xF0, 0xE8),
            Padding = new Padding(6, 0, 6, 4),
            TextAlign = ContentAlignment.BottomLeft,
        };
        cover.Controls.Add(label);
        return cover;
    }

    public static ProgressStrip Progress(double fraction, int width) => new(fraction) { Width = width };

    public static Panel Divider(int width = ContentWidth) => new()
    {
        Size = new Size(width, 1),
        BackColor = T.Divider,
        Margin = new Padding(0, 8, 0, 8),
    };

    private static Color Hex(int rgb) => Color.FromArgb(255, Color.FromArgb(rgb));
}

// Custom progress bar (the built-in one can't be recoloured).
public class ProgressStrip : Control
{
    private readonly double _fraction;

    public ProgressStrip(double fraction)
    {
        _fraction = Math.Clamp(fraction, 0, 1);
        Height = 10;
        Margin = new Padding(0, 12, 0, 6);
        DoubleBuffered = true;
        AccessibleRole = AccessibleRole.ProgressBar;
        AccessibleName = $"{(int)Math.Round(_fraction * 100)} percent read";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var theme = Theme.Current;
        e.Graphics.Clear(theme.SurfaceElevated);
        using var fill = new SolidBrush(theme.Primary);
        e.Graphics.FillRectangle(fill, 0, 0, (int)(Width * _fraction), Height);
    }
}
