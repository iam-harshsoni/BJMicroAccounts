using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
   public class EntryVM
    {
        public int rowNo { get; set; }
        public int entryTypeId { get; set; }
        public string drcrLedger { get; set; }

        public long voucherRefNo { get; set; }
        public Nullable<long> crId { get; set; }
        public Nullable<long> drId { get; set; }
        public Nullable<decimal> amt { get; set; }
        public string date { get; set; }
        public string stringDate { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }
        public string remarks { get; set; }
        public virtual EntryVM tbl_Payment1 { get; set; }
        public virtual EntryVM tbl_Payment2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionVM> tbl_TransactionMaster { get; set; }
    }
}
