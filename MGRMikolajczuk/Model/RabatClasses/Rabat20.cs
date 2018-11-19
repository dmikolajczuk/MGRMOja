using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model.RabatClasses
{
    public class Rabat20 : IRabat
    {
        public double CalculateRabat(double sum)
        {
            return sum * 20 / 100;
        }
    }
}
