using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lym.Application.DtoValidation
{
    /// <summary>
    /// dto 入参验证
    /// </summary>
    public class DtoValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueType = value.GetType();
            foreach (var propertyInfo in valueType.GetProperties())
            {
                var propertyInfoValue = propertyInfo.GetValue(value);
                var propertyInfoName = propertyInfo.Name;
                if (propertyInfoValue == null || string.IsNullOrEmpty(propertyInfoValue.ToString()))
                {
                    return new ValidationResult($"{propertyInfoName} 不能为空");
                }
            }
             
            return ValidationResult.Success;
        }
    }
}
