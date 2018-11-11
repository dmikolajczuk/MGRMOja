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
using Order = MGRMikolajczuk.Model.Order;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private Order order;
        public OrderDetailWindow(Order o)
        {
            InitializeComponent();
            DisplayCategory(null,null);
            order = o;
            DisplayProduct();
        }

        public void DisplayProduct()
        {
            foreach (var item in order._productList)
            {
                TextBlock tb = new TextBlock();
                tb.Text = item.Name;
                DockPanelProcuctList.Children.Add(tb);
            }
        }

        public void DisplayCategory(object sender, RoutedEventArgs e)
        {
            UniformGridNewProduct.Children.Clear();
            CaffeDataContext db = new CaffeDataContext();

            var products = db.Products;
            var result = products.GroupBy(test => test.Category).ToList();

            foreach (var item in result)
            {
                Button b = new Button();

                TextBlock tb = new TextBlock()
                {
                    Text = item.Key,
                    TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center
                };
                b.Content = tb;
                Style s = this.FindResource("ButtonShadow") as Style;
                b.Style = s;
                b.Click += DisplayProduct;
                UniformGridNewProduct.Children.Add(b);
            }
        }

        public void DisplayProduct(object sender, RoutedEventArgs e)
        {
            UniformGridNewProduct.Children.Clear();
            CaffeDataContext db = new CaffeDataContext();
            string ct = ((sender as Button).Content as TextBlock).Text;
            var products = db.Products.Where(s=> s.Category.Equals(ct));

            foreach (var item in products)
            {
                Button b = new Button();

                TextBlock tb = new TextBlock(){Text = item.Name, TextWrapping = TextWrapping.Wrap,
                    TextAlignment = TextAlignment.Center};
                b.Content = tb;
                b.Tag = item.Price;
                Style s = this.FindResource("ButtonShadow") as Style;
                b.Style = s;
                UniformGridNewProduct.Children.Add(b);
            }

            Button bb = new Button();
            bb.Content = "Back";
            Style ss = this.FindResource("ButtonShadowBack") as Style;
            bb.Style = ss;        
            bb.Click += DisplayCategory;
            UniformGridNewProduct.Children.Add(bb);
        }

    }
}
