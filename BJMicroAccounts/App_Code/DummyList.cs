using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.App_Code
{
    public class DummyList
    {
        public string group { get; set; }
        public string date { get; set; }
        public string ledger { get; set; }
        public string amt { get; set; }

        public string crAmt { get; set; }

        public string drAmt { get; set; }

        public string TotalcrAmt { get; set; }

        public string TotaldrAmt { get; set; }
        public string opBal { get; set; }
        public string clBal { get; set; }
    }
}
