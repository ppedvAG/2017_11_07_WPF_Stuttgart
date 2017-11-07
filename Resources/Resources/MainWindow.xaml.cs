using System.Windows;
using System.Windows.Media;

namespace Resources
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void changeColor(object sender, RoutedEventArgs e)
        {
            var brush = Resources["defaultBackgroundBrush"] as SolidColorBrush;
            if (brush != null)
                brush.Color = Colors.Gold;
        }

        private void changeBrush(object sender, RoutedEventArgs e)
        {
            Resources["defaultBackgroundBrush"] = new SolidColorBrush(Colors.Fuchsia);
        }

        private void changeBrushType(object sender, RoutedEventArgs e)
        {
            Resources["defaultBackgroundBrush"] = new RadialGradientBrush(Colors.GhostWhite, Colors.DarkCyan);
        }
    }
}
