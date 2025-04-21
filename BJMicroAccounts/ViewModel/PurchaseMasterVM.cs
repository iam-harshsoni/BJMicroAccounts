using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class PurchaseMasterVM
    {
        public long IdForGrid { get; set; }    //As combine payment and receipt entry is there in grid we use this to store id of both sales and purchase
        public string refNoBillNoForGrid { get; set; } // same as above comments
        public long pId { get; set; }
        public int rowNo { get; set; }  

        public string refNo { get; set; }
        public string ledgerName { get; set; }
        public string combineRefNo { get; set; }

        public Nullable<long> ledgerId { get; set; }
        public string date { get; set; }
        //public Nullable<decimal> totalWeight { get; set; }
        public string totalWeight { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> totalMelting { get; set; }
        public Nullable<decimal> totalPurchaseMelting { get; set; }
        public Nullable<decimal> totalMaking { get; set; }
        public Nullable<decimal> totalFine { get; set; }
        public Nullable<decimal> totalAmt { get; set; }
        public string remarks { get; set; }
        public string createdDate { get; set; }
        public string updateDate { get; set; }

        public string monthYear { get; set; }
        public string amtinWord { get; set; }

        public virtual AccLedgerVm tbl_AccLedger { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetailsVM> tbl_PurchaseDetail { get; set; }

        public List<PurchaseDetailsVM> PurhaseDetailVM { get; set; }
    }
}
