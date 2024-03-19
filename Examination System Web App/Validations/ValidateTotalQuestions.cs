using Examination_System_Web_App.View_Models;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.Validations
{
    public class ValidateTotalQuestions : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var exam = (ExamGenVM)validationContext.ObjectInstance;

            if (exam.TotalQuestions != 10)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

    }
    
}
