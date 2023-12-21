using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Account
    {
        public int AccountNo { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public int CustomerId { get; set; }
        public int Balance { get; set; }
    }
}
