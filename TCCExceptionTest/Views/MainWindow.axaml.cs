using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TCCExceptionTest.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        P.Children.Clear();
        P.Children.Add(new MainView());
    }
}
