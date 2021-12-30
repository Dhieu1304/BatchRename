using Entity;
using System;
using System.Globalization;

namespace PascalRule
{
    public class PascalRule : IRenameRule
    {
        public string Name => "PascalRule";

        public string Rename(string original)
        {
            string result = original.ToLower().Replace("_", " ");
            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            result = info.ToTitleCase(result).Replace(" ", string.Empty);
            return result;
        }

        public string RenameDir(string original)
        {
            string result = original.ToLower().Replace("_", " ");
            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            result = info.ToTitleCase(result).Replace(" ", string.Empty);
            return result;
        }
    }
}
