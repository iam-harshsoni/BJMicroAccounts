using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class LedgerDetailsVM
    {
        public int rowNo { get; set; }
        public long? id { get; set; }
        public Nullable<long> ledgerId { get; set; }
        public string address { get; set; }
        public Nullable<decimal> contact { get; set; }
        public string  createdDate { get; set; }
        public string updateDate { get; set; }

        public string ledgerName { get; set; }
        public decimal? opBal { get; set; }
        public string drcr { get; set; }
        public string groupName { get; set; }
        public virtual AccLedgerVm AccLedger { get; set; }

        public string OpBalWithDC { get; set; }

        public decimal pendingAmt { get; set; }
    }
}
