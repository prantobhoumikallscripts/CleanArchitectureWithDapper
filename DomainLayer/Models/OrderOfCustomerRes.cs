using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class OrderOfCustomerRes
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public int PaymentAmount { get; set; }
        public bool PaymentDone { get; set; }
      
    }
}
