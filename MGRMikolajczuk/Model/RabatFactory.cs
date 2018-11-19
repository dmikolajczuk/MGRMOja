using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGRMikolajczuk.Model.RabatClasses;

namespace MGRMikolajczuk.Model
{
    class RabatFactory
    {

        public IRabat ProductRabat(string name)
        {
            if (name.Equals("_0RabatRadioButton"))
                return new Rabat0();
            else if (name.Equals("_10RabatRadioButton"))
                return new Rabat10();
            else if (name.Equals("_20RabatRadioButton"))
                return new Rabat20();
            else if (name.Equals("_30RabatRadioButton"))
                return new Rabat30();
            else if (name.Equals("_50RabatRadioButton"))
                return new Rabat50();
            else
                return null;
        }
    }
}
