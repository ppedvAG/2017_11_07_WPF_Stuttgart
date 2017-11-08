using System.Windows;

namespace Templates
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Button_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Was clicked!");

        private void CreateCustomer(object sender, RoutedEventArgs e) => customerControl.Content = new Customer
        {
            Id = 39456,
            Name = "Franz Xaver Gruber",
            IsPrime = true
        };
    }
}
