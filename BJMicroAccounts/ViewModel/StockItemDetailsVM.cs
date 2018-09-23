using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class StockItemDetailsVM
    {
        public long id { get; set; }
        public Nullable<long> itemId { get; set; }
        public string weight { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> melding { get; set; }
        public Nullable<decimal> carret { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string remarks { get; set; }
        public string createdDate { get; set; }
        public string upadtedDate { get; set; }

        public virtual ItemMasterVM ItemMaster { get; set; }
    }
}
