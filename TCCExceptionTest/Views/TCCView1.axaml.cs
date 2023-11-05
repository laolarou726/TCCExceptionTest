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
        private readonly Rectangle _rectangle1 = new (){Fill = new SolidColorBrush(Colors.Aqua) };
        private readonly Rectangle _rectangle2 = new() { Fill = new SolidColorBrush(Colors.BlueViolet) };

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
