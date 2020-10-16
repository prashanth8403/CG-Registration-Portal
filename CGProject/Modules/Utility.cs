using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rook.Utility
{
    public class Utility
    {
        public static bool ContainsAny(string haystack, string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }
            return false;
        }

        public static string SectionParser(int RNO)
        {
            string section = " ";
            if (RNO == 0)
                return section;
            if (RNO < 300)
            {
                if (RNO >= 1 && RNO < 74)
                    section = "A";
                else if (RNO >= 74 && RNO <= 148)
                    section = "B";
                else
                    section = "C";
            }
            else if (RNO > 350 && RNO < 500)
            {
                if (RNO < 411)
                    section = "A";
                else if (RNO >= 411 && RNO <= 421)
                    section = "B";
                else
                    section = "C";
            }
            else
                section = "-";
            return section;
        }
    }
}