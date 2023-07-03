using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeesWebApplication.ViewModels
{
    public class EmployeesViewModel : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Фамилия является обязательной.")]
        [Display(Name = "Фамилия")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Максимальная длина строки 100 символов, минимальная длина строки 2 символа.")]
        [RegularExpression(@"([А-ЯЁ][а-яё\-0-9]+)|([A-Z][a-z]+)", ErrorMessage = "Строка имела неверный формат.")]
        public string LastName { get; set; } = null!;


        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LastName == "Иванов" && (DateTime.UtcNow.Year - Birthday.Year <= 30))
                yield return new ValidationResult("Иванов должен быть старше 30 лет.", new[] { nameof(LastName), nameof(Birthday) } );

            //yield return ValidationResult.Success!;
        }
    }
}
