using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STO.ViewModels
{
    public class UserEditViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Телефоный номер")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "Модель автомобиля")]
        public string Car { get; set; }        
    }
}
