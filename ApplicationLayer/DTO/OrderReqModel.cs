using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class OrderReqModel
    {
    
        public string ShippingAddress { get; set; }

        public int PaymentAmount { get; set; }

        public bool PaymentDone { get; set; }

        public List<int> ProductIDs { get; set; }
    }
}
