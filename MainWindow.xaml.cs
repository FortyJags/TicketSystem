﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
            RunStockChecker(@"C:\CodingProjects\TicketSystemPython\StockCheck.py");

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



        private void RunStockChecker(string filePath)
        {
            ProcessStartInfo startInfo = new();
            //FIleName used to indicate what executable to run the code on
            startInfo.FileName = "python.exe";
            //Add any arguments here using string.Format
            startInfo.Arguments = filePath;
            //set to false to redirect output to C# code
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            using (Process process = Process.Start(startInfo))
            {
                using(StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Debug.WriteLine(result);
                }

            }
        }
    }
}
