using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AFFv2
{
    public class RssTextTrimmer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null) return null;

            int maxLength = 200;
            int strLength = 0;
            string fixedString = "";

            fixedString = Regex.Replace(value.ToString(), "<[^>]+>", string.Empty);


            fixedString = fixedString.Replace("\r", "").Replace("\n", "");


            fixedString = HttpUtility.HtmlDecode(fixedString);

            strLength = fixedString.ToString().Length;

            if (strLength == 0)
            {
                return null;
            }


            else if (strLength >= maxLength)
            {
                fixedString = fixedString.Substring(0, maxLength);


                fixedString = fixedString.Substring(0, fixedString.LastIndexOf(" "));
            }

            fixedString += "...";

            return fixedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
