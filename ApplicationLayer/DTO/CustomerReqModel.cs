using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class CustomerReqModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int RegionId { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public GenderType Gender { get; set; } = GenderType.Unknown;


        public AccountReqModel AccountDetails { get; set; } = new AccountReqModel();
    }

   
}

