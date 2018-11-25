using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
    public class CheckPassAndLogin
    {

        public bool ChceckPassNumeric(string p1)
        {
            bool isNumeric = int.TryParse(p1, out int  nn);

            return isNumeric;
        }

        public bool ChceckPassEqals(string p1, string p2)
        {
            return p1.Equals(p2);
        }

        public bool CheckPassLength(string p1)
        {
            if (p1.Length == 4)
                return true;
            else
                return false;
        }
    }
}
