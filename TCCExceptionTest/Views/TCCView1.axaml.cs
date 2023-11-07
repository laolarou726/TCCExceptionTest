using System.Reflection;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;

namespace TCCExceptionTest.Views
{
    public partial class TCCView1 : UserControl
    {
        private readonly Rectangle _rectangle1 = new (){Fill = new SolidColorBrush(Colors.Aqua), Tag = "TCCView1-1"};
        private readonly Rectangle _rectangle2 = new() { Fill = new SolidColorBrush(Colors.BlueViolet), Tag = "TCCView1-2" };

        public TCCView1()
        {
            InitializeComponent();
        }

        protected override void OnLoaded(RoutedEventArgs e)
        {
            base.OnLoaded(e);

            Task.Run(async () =>
            {
                var flag = true;

                while (!MainWindow.Cts.IsCancellationRequested)
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
