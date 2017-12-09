using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Models
{
    class BankAccounts
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
