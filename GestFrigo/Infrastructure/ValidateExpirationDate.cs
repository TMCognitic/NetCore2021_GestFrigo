using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GestFrigo.Infrastructure
{
    public class ValidateExpirationDate : CompareAttribute
    {
        public ValidateExpirationDate(string otherProperty) : base(otherProperty)
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type sourceType = validationContext.ObjectInstance.GetType();
            PropertyInfo otherPropertyInfo = sourceType.GetProperty(OtherProperty);
            try
            {
                DateTime otherValue = (DateTime)otherPropertyInfo.GetMethod.Invoke(validationContext.ObjectInstance, null);
                if(otherValue < (DateTime)value)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"{validationContext.MemberName} must be less than {OtherProperty}");
            }
            catch (InvalidCastException)
            {
                return new ValidationResult($"{validationContext.MemberName} and {OtherProperty} must have the same type");
            }
            catch (NullReferenceException)
            {
                return new ValidationResult($"{validationContext.MemberName} is Required");
            }
        }
    }
}