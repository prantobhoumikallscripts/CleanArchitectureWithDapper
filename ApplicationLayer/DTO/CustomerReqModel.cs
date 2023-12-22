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
        public long PhoneNumber { get; set; }

        public int RegionId { get; set; }

        public string VillageOrRoadName { get; set; }

        public string PostOffice { get; set; }

        public string PoliceStation { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public int PinCode { get; set; }

        public DateTime DOB { get; set; }

        public GenderType Gender { get; set; } = GenderType.Unknown;


        public AccountReqModel AccountDetails { get; set; } = new AccountReqModel();
    }

   
}

