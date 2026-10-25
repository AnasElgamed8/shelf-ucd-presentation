namespace ShelfApp.UI;

// Colours from our design system (deck-generation-prompt.md).
public class Theme
{
    public Color Background { get; init; }
    public Color Surface { get; init; }
    public Color SurfaceElevated { get; init; }
    public Color Primary { get; init; }
    public Color OnPrimary { get; init; }
    public Color TextPrimary { get; init; }
    public Color TextSecondary { get; init; }
    public Color Divider { get; init; }
    public Color Error { get; init; }
    public Color ErrorBg { get; init; }
    public Color Success { get; init; }
    public Color SuccessBg { get; init; }
    public Color Warning { get; init; }
    public Color WarningBg { get; init; }

    public static readonly Theme Dark = new()
    {
        Background = Hex("#0D0D0D"),
        Surface = Hex("#1A1A1A"),
        SurfaceElevated = Hex("#242424"),
        Primary = Hex("#E8DCCC"),
        OnPrimary = Hex("#0D0D0D"),
        TextPrimary = Hex("#F5F0E8"),
        TextSecondary = Hex("#A89E90"),
        Divider = Hex("#2A2A2A"),
        Error = Hex("#E05555"),
        ErrorBg = Hex("#2A1A1A"),
        Success = Hex("#44CC44"),
        SuccessBg = Hex("#0D2A1A"),
        Warning = Hex("#CCAA44"),
        WarningBg = Hex("#2A2A1A"),
    };

    public static readonly Theme Light = new()
    {
        Background = Hex("#F5F0E8"),
        Surface = Hex("#FFFFFF"),
        SurfaceElevated = Hex("#ECE4D8"),
        Primary = Hex("#2A2420"),
        OnPrimary = Hex("#F5F0E8"),
        TextPrimary = Hex("#1A1A1A"),
        TextSecondary = Hex("#5C5348"),
        Divider = Hex("#DDD3C5"),
        Error = Hex("#B03030"),
        ErrorBg = Hex("#F8E0E0"),
        Success = Hex("#1E7A1E"),
        SuccessBg = Hex("#DFF2DF"),
        Warning = Hex("#8A6A00"),
        WarningBg = Hex("#F5ECCC"),
    };

    public static Theme Current { get; set; } = Dark;

    private static Color Hex(string hex) => ColorTranslator.FromHtml(hex);
}
