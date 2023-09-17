using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem
{
    public class Order
    {
        public List<string> CurrentOrder {  get; set; }

        public Order()
        {
           CurrentOrder = new List<string>();
        }


    }
}
