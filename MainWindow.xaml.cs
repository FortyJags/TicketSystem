using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicketSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MenuItems _items;
        private readonly Order _customerOrder;


        public MainWindow()
        {
            InitializeComponent();
            _items = new();
            _customerOrder = new();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string _orderedItems = String.Empty;

            foreach(var item in _customerOrder.CurrentOrder)
            {
                _orderedItems += item;
                Debug.WriteLine(item);
            }
            MessageBox.Show(_orderedItems);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _customerOrder.CurrentOrder.Add(MenuItems.Items.Burger);
            MessageBox.Show($"{_customerOrder.CurrentOrder.Count}");
        }
    }
}
