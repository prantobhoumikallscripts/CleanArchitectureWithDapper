﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Enities
{
    public class Order
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public int PaymentAmount { get; set; }

        public string DelivaryStatus { get; set; }

        public bool PaymentDone { get; set; }
        public int CustomerId { get; set; }
    }
}
