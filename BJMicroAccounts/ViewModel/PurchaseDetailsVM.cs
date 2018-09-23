using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
   public class PurchaseDetailsVM
    {
        public long pdetailsId { get; set; }
        public Nullable<long> purchaseID { get; set; }
        public Nullable<long> productID { get; set; }
        public Nullable<decimal> weight { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> karat { get; set; }
        public Nullable<decimal> kRate { get; set; }
        public Nullable<decimal> melting { get; set; }
        public Nullable<decimal> purchaseMelting { get; set; }
        public Nullable<decimal> making { get; set; }
        public Nullable<decimal> fine { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }

        public string ItemCode { get; set; }

        public virtual ItemMasterVM ItemMaster { get; set; }
        public virtual PurchaseMasterVM PurchaseMaster { get; set; }
    }
}
