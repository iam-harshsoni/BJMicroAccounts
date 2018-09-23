using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class TransactionVM
    {
        public long tId { get; set; }
        public System.DateTime tDate { get; set; }
        public string voucherType { get; set; }
        public Nullable<long> voucherRefNo { get; set; }
        public Nullable<decimal> crAmt { get; set; }
        public Nullable<decimal> drAmt { get; set; }
        public Nullable<long> ledgerId { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }
        public Nullable<long> loginId { get; set; }

        public virtual EntryVM tbl_Payment { get; set; }
        public virtual UserLoginVM tbl_UserLogiln { get; set; }
    }
}
