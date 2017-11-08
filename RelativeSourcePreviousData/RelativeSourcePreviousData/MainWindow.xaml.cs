using System.Collections.Generic;
using System.Windows;

namespace RelativeSourcePreviousData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            diagram.ItemsSource = GetData();
        }

        private IEnumerable<Item> GetData() => new List<Item>
        {
            new Item(90),
            new Item(46),
            new Item(190),
            new Item(200),
            new Item(0),
            new Item(54),
            new Item(73),
            new Item(137),
            new Item(34),
            new Item(83),
            new Item(53),
            new Item(196),
            new Item(80),
            new Item(90),
            new Item(46),
            new Item(190),
            new Item(200),
            new Item(0),
            new Item(54),
            new Item(73),
            new Item(137),
            new Item(34),
            new Item(83),
            new Item(53),
            new Item(196),
            new Item(80)
        };
    }
}
