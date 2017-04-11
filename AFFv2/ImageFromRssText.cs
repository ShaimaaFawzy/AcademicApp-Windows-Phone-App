using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AFFv2
{
    public class ImageFromRssText : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            List<ImageItem> listUri = GetHtmlImageUrlList(value.ToString());
            return listUri;
        }     
        public static List<ImageItem> GetHtmlImageUrlList(string sHtmlText)
        {
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            List<ImageItem> imgUrlList = new List<ImageItem>();
            foreach (Match match in matches)
            {
                imgUrlList.Add(new ImageItem("img" + i, match.Groups["imgUrl"].Value));
                i++;
            }
            return imgUrlList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
          public class ImageItem
    {
        public ImageItem(string title, string url)
        {
            this.Title = title;
            this.URL = url;
        }

        public string Title { get; set; }
        public string URL { get; set; }
    }
    
}
