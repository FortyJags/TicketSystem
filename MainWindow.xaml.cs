using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TicketSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Order _customerOrder;
        private string _stockCheckPath = @"C:\CodingProjects\TicketSystemPython\StockCheck.py";
        private int _currentOrderNumber = 0;
        private bool _newOrder;
        


        public MainWindow()
        {
            InitializeComponent();           
            _customerOrder = new();
            DataContext = Order;
            _newOrder = true;
        }

        private void GenearateTicket_Click(object sender, RoutedEventArgs e)
        {
            string _orderedItems = String.Empty;

            foreach(var item in _customerOrder.CurrentOrder)
            {
                _orderedItems += item;               
            }
            _newOrder = true;
            _customerOrder.OrderAsList = "Order complete";
            Order.Text = _customerOrder.OrderAsList;

        }

           //create a senderButton variable to get the content of the button. Pass the content through a switch to determine which button was pressed

        private void Additem_Click(object sender, RoutedEventArgs e)
        {
            var senderButton = sender as Button;

            switch (senderButton!.Content.ToString())
            {
                case "Burger": _customerOrder.CurrentOrder.Add("Burger"); RunStockChecker(_stockCheckPath, "Burger"); break;
                case "Cake": _customerOrder.CurrentOrder.Add("Cake"); RunStockChecker(_stockCheckPath, "Cake"); break;

            }
            DisplayOrder();

        }

     


        private void RunStockChecker(string filePath, string argument)
        {
            ProcessStartInfo startInfo = new();
            //FileName used to indicate what executable to run the code on
            startInfo.FileName = "python.exe";
         
            startInfo.Arguments = string.Format("\"{0}\" {1}", filePath, argument);
           
            //set to false to redirect output to C# code
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            using (Process process = Process.Start(startInfo)!)
            {
                using(StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Debug.WriteLine($"Python returned: {result}");
                }

            }
        }


        private void DisplayOrder()
        {
            if(_newOrder == true)
            {
                _currentOrderNumber = GenerateOrderNumber();
                
            }
            _customerOrder.OrderAsList = $"Customer order no: {_currentOrderNumber} \n";
            Debug.WriteLine(_currentOrderNumber);
            foreach (var item  in _customerOrder.CurrentOrder)
            {
                _customerOrder.OrderAsList += $"* {item}\n";
            }
            

            Order.Text = _customerOrder.OrderAsList;
        }

        private int GenerateOrderNumber()
        {
            _newOrder = false;        
            return _currentOrderNumber++;      

        }



        }
    }
