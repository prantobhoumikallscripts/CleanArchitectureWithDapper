﻿using DomainLayer.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class AllCustomerResponseModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Region RegionDetails { get; set; }

        public int ContinentCode { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        public string Gender { get; set; }
    }
}
