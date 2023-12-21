using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class OrderRes
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public int PaymentAmount { get; set; }

        public string DelivaryStatus { get; set; }

        public bool PaymentDone { get; set; }
        public int CustomerId { get; set; }

        public List<Product> Products { get; set; }=new List<Product>();
    }
}
