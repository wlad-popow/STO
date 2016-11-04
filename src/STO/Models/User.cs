using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STO.Models
{
    public class User
    {
        public string Id { get; private set; }
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }
        public string Password { get; set; }
    }
}
