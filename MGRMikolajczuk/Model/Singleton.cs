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
        public List<OrderClass> orderList;

        protected Singleton()
        {
            orderList = new List<OrderClass>();
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
