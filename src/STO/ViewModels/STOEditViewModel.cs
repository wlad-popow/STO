using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STO.ViewModels
{
    public class STOEditViewModel
    {
        [Display(Name = "Название сервиса")]
        public string Name { get; set; }        
        
        [Display(Name = "Услуги Сервиса")]
        public string Services { get; set; }
                
        [Display(Name = "Адрес")]
        public string Adres { get; set; }

        [Display(Name = "Время открытия")]
        public DateTime Open { get; set; }
        
        [Display(Name = "Время закрытия")]
        public DateTime Close { get; set; }
        
        [Display(Name = "Описание")]
        public string Description { get; set; }
        
        [Display(Name = "Контакты")]
        public string Contacts { get; set; }
        
        [Display(Name = "Район")]
        public string Rajon { get; set; }
    }
}
