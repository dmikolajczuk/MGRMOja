using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
   public class GroupSUM
    {
        public double _sum;
        public DateTime _date;

        public GroupSUM(double s, DateTime d)
        {
            this._sum = s;
            this._date = d;
        }
    }
}
