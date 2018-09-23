using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
   public class SalesDetailsVM
    {
        public long sDetailsId { get; set; }
        public Nullable<long> salesId { get; set; }
        public Nullable<long> productId { get; set; }
        public Nullable<decimal> weight { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> karrat { get; set; }
        public Nullable<decimal> kRate { get; set; }
        public Nullable<decimal> making { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string createdDate { get; set; }
        public string updateDate { get; set; }

        public string ItemCode { get; set; }
        public virtual ItemMasterVM tbl_ItemMaster { get; set; }
        public virtual SalesMasterVM tbl_SalesMaster { get; set; }
    }
}
