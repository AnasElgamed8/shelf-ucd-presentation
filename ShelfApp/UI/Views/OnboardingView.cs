namespace ShelfApp.UI.Views;

// First launch: 3 short screens explaining the app's value, then sync choice.
public class OnboardingView : ViewBase
{
    private record Step(string Glyph, string Title, string Body, string Button);

    private static readonly Step[] Steps =
    [
        new("", "Find the best price.\nNever lose your place.",
            "Search any book. See local sellers first, sorted by price. Your progress syncs across devices.",
            "Get Started"),
        new("", "Don't waste money on books you'll drop",
            "Shelf learns your patterns. If a book has a high drop risk for YOU, we will tell you why — before you buy.",
            "Continue"),
        new("", "Sync your library everywhere",
            "Your progress, notes and drop-risk history stay private and synced.",
            "Finish Setup"),
    ];

    private int _step;

    public OnboardingView(MainForm app) : base(app)
    {
        Build();
    }

    private void Build()
    {
        foreach (var old in Page.Controls.Cast<Control>().ToList())
            old.Dispose();
        var step = Steps[_step];
        int width = Ui.ContentWidth;

        var illustration = Ui.Card(width, children: [Ui.Icon(step.Glyph, 64, T.Primary)]);
        illustration.Padding = new Padding(width / 2 - 56, 48, 0, 48);

        Add(new Panel { Height = 40, Width = 1 });
        Add(illustration);
        Add(Ui.Text(step.Title, 20, FontStyle.Bold, maxWidth: width));
        Add(Ui.Secondary(step.Body, 11.5f, width));

        if (_step == Steps.Length - 1)
        {
            var sync = new CheckBox
            {
                Text = "Enable sync",
                Checked = App.Data.SyncEnabled,
                AutoSize = true,
                Font = new Font(Ui.FontName, 11),
                ForeColor = T.TextPrimary,
                Margin = new Padding(0, 16, 0, 0),
            };
            sync.CheckedChanged += (_, _) => App.Data.SyncEnabled = sync.Checked;
            Add(sync);
        }

        var stepLabel = Ui.Secondary($"Step {_step + 1} of {Steps.Length}");
        stepLabel.Margin = new Padding(0, 16, 0, 8);
        Add(stepLabel);

        Add(Ui.PrimaryButton(step.Button, Next, width));
    }

    private void Next()
    {
        if (_step < Steps.Length - 1)
        {
            _step++;
            Build();
            return;
        }

        App.Data.OnboardingDone = true;
        App.Save();
        App.ShowHome();
    }
}
