 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
namespace ServiceCRM.Testing
{
    public class Models
    {
        public static List<ValidationResult> GetValidationErrors<T>(T model, out bool passed)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            passed = Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}