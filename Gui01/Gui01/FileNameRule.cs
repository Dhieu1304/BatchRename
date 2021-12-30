using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gui01
{
    public class FileNameRule : ValidationRule
    {
        public string fileName { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            fileName = "";
            ValidationResult result = ValidationResult.ValidResult;

            /*try
             {
                 string buffer = (string)(value);
                 if (buffer.Length > 0)
                 {

                 }
             }
             catch (Exception e)
             {
                 result = new ValidationResult(false, "FileName incorrect" + e.Message);
             }*/

            string buffer = (string)(value);

            if (buffer.Length > 0)
            {
                string patten = @"^p{L}+$";
                var regex = new Regex(patten);

                if (!regex.IsMatch(buffer))
                {
                    result = new ValidationResult(false, "FileName incorrect");
                }
            }

            return result;
        }
    }
}
