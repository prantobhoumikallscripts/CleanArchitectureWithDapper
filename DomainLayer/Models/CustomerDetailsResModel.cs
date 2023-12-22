using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Enities;

namespace DomainLayer.Models
{
    public class CustomerDetailsResModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public Account AccountDetails { get; set; }

        public List<OrderOfCustomerRes> Orders { get; set; } = new List<OrderOfCustomerRes>();

    }
}
