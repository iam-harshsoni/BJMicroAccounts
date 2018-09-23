using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJMicroAccounts.ViewModel
{
   public class TaxDetailsVM
    {
        public long taxDetailsId { get; set; }
        public Nullable<long> tId { get; set; }
        public Nullable<decimal> cgst_per { get; set; }
        public Nullable<decimal> cgst_rate { get; set; }
        public Nullable<decimal> sgst_per { get; set; }
        public Nullable<decimal> sgst_rate { get; set; }
        public Nullable<decimal> igst_per { get; set; }
        public Nullable<decimal> igst_rate { get; set; }
        public Nullable<System.DateTime> cDate { get; set; }
        public Nullable<System.DateTime> uDate { get; set; }

        public virtual TaxMasterVM tbl_TaxMaster { get; set; }
    }
}
