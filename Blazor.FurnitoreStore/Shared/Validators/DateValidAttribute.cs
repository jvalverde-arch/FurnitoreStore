using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.FurnitoreStore.Shared.Validators
{
    public class DateValidAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime fechaCreacion = (DateTime)value;

            DateTime fechaNacimiento = ((Client)validationContext.ObjectInstance).BirthDate;

            if (fechaCreacion>fechaNacimiento)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult
                    ("Creation date can not be greater than current date.");
        }
    }
}
