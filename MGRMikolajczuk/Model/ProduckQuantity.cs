using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGRMikolajczuk.Model
{
    public class ProduckQuantity
    {
        public Product product;
        public int quantity;

        public ProduckQuantity(Product p, int i)
        {
            this.product = p;
            this.quantity = i;
        }
    }
}
