using System.Globalization;
using System.Windows.Controls;

namespace Validation
{
    internal class MustNotBe9ValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) => 
            value.Equals("9")
             ? new ValidationResult(false, "Must not be 9! :(")
             : ValidationResult.ValidResult;
    }
}
