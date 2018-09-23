using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class UserProfileVM
    {
        public int rowNo { get; set; }
        public long userId { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<decimal> mobile { get; set; }
        public string createdDate { get; set; }
        public string updateDate { get; set; }


        public virtual ICollection<UserLoginVM> UserLogins { get; set; }
    }
}
