using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
    public class Rabat10 : IRabat
    {
        public double CalculateRabat(double sum)
        {
            return  sum * 10 / 100;
        }
    }
}
