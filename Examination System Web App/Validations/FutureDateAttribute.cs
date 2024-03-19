using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.Validations
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}
