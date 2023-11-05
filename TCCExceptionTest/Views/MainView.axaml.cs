using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace TCCExceptionTest.Views;

public partial class MainView : UserControl
{
    private readonly TCCView1 _tccView1 = new();
    private readonly TCCView2 _tccView2 = new();

    public MainView()
    {
        InitializeComponent();
    }

    private async Task SwitchView()
    {
        var flag = true;

        while (true)
        {
            await Dispatcher.UIThread.InvokeAsync(() => TCC.Content = flag ? _tccView1 : _tccView2);

            flag = !flag;

            await Task.Delay(2000);
        }
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        SwitchView();
    }
}
