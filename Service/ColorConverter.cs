using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Service
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string colorName)
            {
                // Convert color name to Color object
                return Color.FromArgb(GetHexValue(colorName));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetHexValue(string colorName)
        {
            switch (colorName.ToLower())
            {
                case "red":
                    return "#BB2823";
                case "green":
                    return "#43AC16";
                case "blue":
                    return "#144785";
                case "purple":
                    return "#D47DDC";
                case "yellow":
                    return "#BDA127";
                default:
                    return "#000000";
            }
        }
    }
}