﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class AccountResModel
    {
        public int AccountNumber { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public int Balance { get; set; }
    }
}
