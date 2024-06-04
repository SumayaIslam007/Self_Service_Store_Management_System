using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Transaction
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
