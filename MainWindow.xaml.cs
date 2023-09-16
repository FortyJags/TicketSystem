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

        private void GenearateTicket_Click(object sender, RoutedEventArgs e)
        {
            string _orderedItems = String.Empty;

            foreach(var item in _customerOrder.CurrentOrder)
            {
                _orderedItems += item;
                Debug.WriteLine(item);
            }
            MessageBox.Show(_orderedItems);

        }

           //create a senderButton variable to get the content of the button. Pass the content through a switch to determine which button was pressed

        private void Additem_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;

            switch (senderButton!.Content.ToString())
            {
                case "Burger": _customerOrder.CurrentOrder.Add(MenuItems.Items.Burger);break;
                case "Cake": _customerOrder.CurrentOrder.Add(MenuItems.Items.Cake);break;

            }

        }
    }
}
