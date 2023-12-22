using DomainLayer.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class SingleCustomerResModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int RegionId { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }

        public Account AccountDetails { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
