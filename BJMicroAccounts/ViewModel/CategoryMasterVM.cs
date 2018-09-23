using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class CategoryMasterVM
    {
        public int rowNo { get; set; }
        public long cId { get; set; }
        public string cName { get; set; }
        public string prefix { get; set; }
        public string createdDate { get; set; }
        public string updatedDate { get; set; }
    }
}
