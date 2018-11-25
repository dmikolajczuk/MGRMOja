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
        public List<ProduckQuantity> _productList;
        IRabat _rabat;
        public OrderClass()
        {
            _productList = new List<ProduckQuantity>();
            _sum = 0;
            _rabat = new Rabat0();
        }

        public void CalculateSum()
        {
            double? a = 0.0;
            foreach (var item in _productList)
            {
                a += item.quantity * item.product.Price;
            }

            double sum = (double)a;
            _sum = sum - _rabat.CalculateRabat(sum);
            Console.WriteLine(_sum);
        }

        public void AddProduct(ProduckQuantity p)
        {
            var pp = _productList.FirstOrDefault(s => s.product.Id_Product == p.product.Id_Product);
            if (pp == null)
                _productList.Add(p);
            else
                pp.quantity++;
        }

        public void RemuveProduct(ProduckQuantity p)
        {
            _productList.Remove(p);
        }

        public void SetRabat(IRabat r)
        {
            this._rabat = r;
        }
    }
}
