using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class ItemMasterVM
    {
        public int rowNo { get; set; }
        public long id { get; set; }
        public string itemCode { get; set; }
        public string categoryName { get; set; }
        public Nullable<int> categoryId { get; set; }
        public byte[] photo { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }

        public string weight { get; set; }
        public string unit { get; set; }
        public Nullable<decimal> melting { get; set; }
        public Nullable<decimal> carret { get; set; }
        public Nullable<decimal> qty { get; set; }
        public string remarks { get; set; } 

        public virtual CategoryMasterVM CategoryMaster { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItemDetailsVM> StockItemDetails { get; set; }
    }
}
