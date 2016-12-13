using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STO.ViewModels
{
    public class STORegisterViewModel
    {
        [Required]
        [Display(Name = "Название сервиса")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Услуги Сервиса")]
        public string Services { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Adres { get; set; }

        [Required]
        [Display(Name = "Время открытия")]
        public DateTime Open { get; set; }

        [Required]
        [Display(Name = "Время закрытия")]
        public DateTime Close { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Контакты")]
        public string Contacts { get; set; }

        [Required]
        [Display(Name = "Район")]
        public string Rajon { get; set; }
    }
}
