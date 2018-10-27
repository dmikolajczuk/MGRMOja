using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MGRMikolajczuk.App_data;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for NewProductsWindow.xaml
    /// </summary>
    public partial class NewProductsWindow : Window
    {
        public NewProductsWindow()
        {
            InitializeComponent();
            DisplayProduct();
        }

        public void DisplayProduct()
        {
            CaffeDataContext db = new CaffeDataContext();

            var products = db.Products;

            foreach (var item in products)
            {
                Button b = new Button();

                b.Content = item.Name;
                b.Tag = item.Price;
                Style s = this.FindResource("ButtonShadow") as Style;
                b.Style = s;
                UniformGridNewProduct.Children.Add(b);
            }
        }

    }
}
