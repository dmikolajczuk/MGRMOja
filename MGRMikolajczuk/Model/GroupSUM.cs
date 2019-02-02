using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
   public class GroupSUM : IComparable<GroupSUM>
    {
        public double _sum { get; set; }
        public DateTime _date { get; set; }

        public GroupSUM(double s, DateTime d)
        {
            this._sum = s;
            this._date = d;
        }

        public int CompareTo(GroupSUM other)
        {
            return _sum.CompareTo(other._sum);
        }
    }
}
