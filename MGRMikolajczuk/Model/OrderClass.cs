using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
    public class OrderClass
    {
        public String _name;
        public double _sum;
        public List<Product> _productList;
        IRabat _rabat;
        public OrderClass()
        {
            _productList = new List<Product>();
            _sum = 0;
            _rabat = new Rabat0();
        }

        public void CalculateSum()
        {
            double? a = _productList.Sum(s => s.Price);

            double sum = (double)a;
            _sum = sum - _rabat.CalculateRabat(sum);
            Console.WriteLine(_sum);
        }

        public void AddProduct(Product p)
        {
            _productList.Add(p);
        }

        public void RemuveProduct(Product p)
        {
            _productList.Remove(p);
        }

        public void SetRabat(IRabat r)
        {
            this._rabat = r;
        }
    }
}
