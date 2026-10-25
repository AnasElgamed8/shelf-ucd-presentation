namespace ShelfApp.UI.Views;

// Every screen is a scrolling column centred in the window.
public class ViewBase : UserControl
{
    protected readonly MainForm App;
    protected readonly FlowLayoutPanel Page;

    protected static Theme T => Theme.Current;

    public ViewBase(MainForm app)
    {
        App = app;
        DoubleBuffered = true;
        BackColor = T.Background;
        Page = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            BackColor = T.Background,
        };
        Controls.Add(Page);
    }

    protected void Add(params Control[] controls) => Page.Controls.AddRange(controls);

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        int side = Math.Max(24, (ClientSize.Width - Ui.ContentWidth - SystemInformation.VerticalScrollBarWidth) / 2);
        Page.Padding = new Padding(side, 24, side, 24);
    }
}
