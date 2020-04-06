using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Domain.ViewModels
{
    public class EmployeeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name="Имя")]
        [Required(ErrorMessage ="Имя обязательно")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage ="Длинна строки от 3 до 200 символов")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия обязательна")]
        [StringLength(maximumLength: 200, MinimumLength = 3, ErrorMessage = "Длинна строки от 3 до 200 символов")]
        [MinLength(3, ErrorMessage = "Минимум 3 символа")]
        public string SecondName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
       
        [Required(ErrorMessage ="Не указан возраст!")]
        [Range(0, 150, ErrorMessage = "Возрас может быть от 0 до 150 лет!")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }
}
