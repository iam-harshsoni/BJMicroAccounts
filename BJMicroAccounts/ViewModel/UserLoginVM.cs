using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.ViewModel
{
    public class UserLoginVM
    {
        public long id { get; set; }
        public Nullable<long> userId { get; set; }
        public string loginId { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public string createdDate { get; set; }
        public string updateDate { get; set; }

        public virtual UserProfileVM UserProfile { get; set; }
    }
}
