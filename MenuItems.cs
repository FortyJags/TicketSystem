using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    public class MenuItems: INotifyPropertyChanged
    {
        private string item1 = "Burger";


        public string Item1 { get { return item1; } set { if (item1 != value) { item1 = value; OnPropertyChanged(Item1); } } }

        public event PropertyChangedEventHandler? PropertyChanged;


        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
