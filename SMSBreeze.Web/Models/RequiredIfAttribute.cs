using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMSBreeze.Web.Models
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private string FirstPropertyName { get; set; }
        private string SecondPropertyName { get; set; }
        private string ThirdPropertyName { get; set; }
        private string ErrorMessages { get; set; }
        private object DesiredValue { get; set; }

        public RequiredIfAttribute(string FirstPropertyName, string SecondPropertyName, string ThirdPropertyName, Object desiredvalue, string errormessages)
        {
            this.FirstPropertyName = FirstPropertyName;
            this.SecondPropertyName = SecondPropertyName;
            this.ThirdPropertyName = ThirdPropertyName;
            this.ErrorMessages = errormessages;
            this.DesiredValue = desiredvalue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(FirstPropertyName).GetValue(instance, null);
            Object proprtyvalue2 = type.GetProperty(FirstPropertyName).GetValue(instance, null);
            Object proprtyvalue3 = type.GetProperty(FirstPropertyName).GetValue(instance, null);
            if (proprtyvalue.ToString() == DesiredValue.ToString() && value.ToString() == "N/A")
            {
                return new ValidationResult(ErrorMessage);
            }
            if (proprtyvalue2.ToString() == DesiredValue.ToString() && value.ToString() == "N/A")
            {
                return new ValidationResult(ErrorMessage);
            }
            if (proprtyvalue3.ToString() == DesiredValue.ToString() && value.ToString() == "N/A")
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
