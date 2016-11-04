using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class UserViewModel
    {
        public string Id { get; private set; }
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
