using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicCMS_Admin.Helpers
{
    public static class PasswordValidator
    {
        private const string ALLOWED_SPECIAL_CHARS = @"@#$%&*+_()':;?.,![]\-";
        private static string ESCAPED_SPECIAL_CHARS;

        static PasswordValidator()
        {
            var escapedChars = new List<char>();
            foreach (char c in ALLOWED_SPECIAL_CHARS)
            {
                if (c == '[' || c == ']' || c == '\\' || c == '-')
                    escapedChars.AddRange(new[] { '\\', c });
                else
                    escapedChars.Add(c);
            }
            ESCAPED_SPECIAL_CHARS = new string(escapedChars.ToArray());
        }

        public static bool IsValidPassword(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            // Length requirement?
            if (input.Length < 8) return false;

            // First just check for a digit
            if (!Regex.IsMatch(input, @"\d")) return false;

            // Then check for special character
            if (!Regex.IsMatch(input, "[" + ESCAPED_SPECIAL_CHARS + "]")) return false;

            // Require a letter?
            if (!Regex.IsMatch(input, "[a-zA-Z]")) return false;

            // DON'T allow anything else:
            if (Regex.IsMatch(input, @"[^a-zA-Z\d" + ESCAPED_SPECIAL_CHARS + "]")) return false;

            return true;
        }
    }
}
