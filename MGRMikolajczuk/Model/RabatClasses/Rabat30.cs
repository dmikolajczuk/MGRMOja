﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model.RabatClasses
{
    public class Rabat30 : IRabat
    { 
        public double CalculateRabat(double sum)
        {
            return sum * 30 / 100;
        }
    }
}
