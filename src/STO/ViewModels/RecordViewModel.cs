using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STO.ViewModels
{
    public class RecordViewModel
    {
        [Required]
        [Display(Name = "Телефоный номер")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [Required]
        [Display(Name = "Модель автомобиля")]
        public string ModelCar { get; set; }
        public string UserId { get; set; }
        public string STOId { get; set; }
    }
}
