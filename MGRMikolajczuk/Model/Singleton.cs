using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
    public class Singleton

    {
        private static Singleton instance;
        public List<Order> orderList;

        protected Singleton()
        {
            orderList = new List<Order>();

            orderList.Add(new Order()
            {
                _name = "Zamowienie1",
                _sum = 55.66
            });

            orderList.Add(new Order()
            {
                _name = "Zamowienie2",
                _sum = 11.11
            });
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
