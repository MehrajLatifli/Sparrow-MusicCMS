using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MusicCMS.Helpers
{
    public class PasswordToHiddenCharactersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringValue = value as String;
            if (stringValue == null)
            {
                return value;
            }
            else
            {

                return RemoveIllegalCharacters(stringValue);
            }


        }

        private object RemoveIllegalCharacters(string stringValue)
        {
            string s= string.Empty;

            if (stringValue.Length > 0)
            {
                if(stringValue!="Password")
                {
                    char[] str1 = stringValue.ToCharArray();

                    // looping through each character of string
                    for (int i = 0; i < stringValue.Length; i++)
                    {

                        //// storing integer ASCII value of
                        //// the character in 'asc'

                        //int asc = str1[i];

                        //// 'rem' contains coded value which
                        //// needs to be rounded to 26
                        //int rem = asc - (39 - (str1[i] - 47));

                        //// converting 'rem' character in range
                        //// 0-25 and storing in 'm'
                        //int m = rem % 39;

                        //// printing character by adding ascii value of 'a'
                        //// so that it becomes in the desired range i.e. a-z
                        str1[i] = (char)('❋');

                    }

                    String str2 = String.Join("", str1);

                    return str2;
                }
            }

            return stringValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = (string)value;

            List<string> list = new List<string>();

                list.Add(text);

            if (list.Count > 0)
            {

                foreach (var item in list)
                {

                    Debug.WriteLine(item);
                }

              

                
            }
            return value;
        }
    }
}
