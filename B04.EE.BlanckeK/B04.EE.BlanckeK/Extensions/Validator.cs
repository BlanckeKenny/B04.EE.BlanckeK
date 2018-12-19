using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B04.EE.BlanckeK.Extensions
{
    static class Validator
    {
        public static bool IsGeligeNaam(this string naam)
        {
            return naam != null && (string.IsNullOrEmpty(naam) && naam.Any(char.IsDigit));
        }

        public static bool IsGeldigeLeefTijd(this int leeftijd)
        {
            return leeftijd != 0 && leeftijd < 125;
        }

        public static bool IsInteger(this string integer)
        {
            bool.TryParse(integer, out bool isInteger);
            return isInteger;
        }
    }
}
