using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
    public class Statistic
    {
        public double GetAvg(List<GroupSUM> list)
        {
            double sum = 0.0;
            foreach (var item in list)
            {
                sum += item._sum;
            }

            return sum/list.Count;
        }

        public double GetWeightAvg(List<GroupSUM> list)
        {
            double sum = 0.0;
            foreach (var item in list)
            {
                sum += (double)item._sum * (int)item._date.DayOfWeek;
            }

            return sum / 21;
        }

        public GroupSUM GetMaxvalue(List<GroupSUM> list)
        {
            return list.Max();
        }

        public GroupSUM GetMINvalue(List<GroupSUM> list)
        {
            return list.Min();
        }

        public double Median(List<GroupSUM> list)
        {
            list.Sort();
            GroupSUM[] x = list.ToArray();
            int n = list.Count, n2 = n / 2 - 1;

            if (n % 2 == 1)
                return x[(n + 1) / 2 - 1]._sum;

            return 0.5 * (x[n2]._sum + x[n2 + 1]._sum);
        }
    }
}
