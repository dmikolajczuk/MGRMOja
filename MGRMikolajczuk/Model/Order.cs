using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGRMikolajczuk.App_data;

namespace MGRMikolajczuk.Model
{
    public class Order
    {
        public String _name;
        public double _sum;
        public List<Product> _productList;

        public Order()
        {
            _productList = new List<Product>();
            _sum = 0;
        }

        public void CalculateSum()
        {
            double? a = _productList.Sum(s=> s.Price);
            _sum = (double)a;
            //Console.WriteLine(_sum);
        }

        public void AddProduct(Product p)
        {
            _productList.Add(p);
        }
    }
}
