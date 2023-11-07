using System;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TCCExceptionTest.Views;

public partial class MainWindow : Window
{
    public static readonly CancellationTokenSource Cts = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        P.Children.Clear();
        P.Children.Add(new MainView());
    }

    override protected void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        Cts.Cancel();
    }
}
