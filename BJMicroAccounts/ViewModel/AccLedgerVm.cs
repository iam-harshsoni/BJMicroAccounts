using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class AccLedgerVm
    {
        public long rowNo { get; set; }
        public long Id { get; set; }
        public long groupId { get; set; }
        public string ledgerName { get; set; }

        public string groupName { get; set; }
        public string ledgerNameWithCreditors { get; set; }
        public Nullable<decimal> opBalance { get; set; }
        public string opBalanceDC { get; set; }
        public Nullable<int> type { get; set; }
        public string notes { get; set; }
        public string createdDate { get; set; }
        public string updateDate { get; set; }  
        public virtual AccGroupVM AccGroup { get; set; }

        public virtual ICollection<LedgerDetailsVM> LedgerDetails { get; set; }
    }
}
