using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCore.Models
{
    class User
    {
        public string Id { get; private set; }
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }
        public string Password { get; set; }
    }
}
