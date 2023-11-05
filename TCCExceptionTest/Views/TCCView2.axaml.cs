using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System.Threading.Tasks;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace TCCExceptionTest.Views
{
    public partial class TCCView2 : UserControl
    {
        private readonly Rectangle _rectangle1 = new() { Fill = new SolidColorBrush(Colors.Aqua) };
        private readonly Rectangle _rectangle2 = new() { Fill = new SolidColorBrush(Colors.BlueViolet) };

        public TCCView2()
        {
            InitializeComponent();
        }

        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);

            Task.Run(async () =>
            {
                var flag = true;

                while (true)
                {
                    await Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        TCC.Content = flag ? _rectangle1 : _rectangle2;
                        flag = !flag;
                    });

                    await Task.Delay(100);
                }
            });
        }
    }
}
