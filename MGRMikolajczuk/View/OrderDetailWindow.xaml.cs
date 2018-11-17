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
using MGRMikolajczuk.Model;
using Order = MGRMikolajczuk.Model.Order;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private Order order;
        private CaffeDataContext db;
        public OrderDetailWindow(Order o)
        {
            InitializeComponent();

            order = o;
            db = new CaffeDataContext();

            //DisplayProductList();
            DisplayCategory(null, null);
            DisplayProductList();
        }

        public void DisplayProductList()
        {
            ComponentFabryk fabryka = new ComponentFabryk();

            DockPanelProcuctList.Children.Clear();

            TextBlock tbHead = fabryka.GeneraTextBlock("Lista produktów");
            DockPanel.SetDock(tbHead, Dock.Top);
            tbHead.FontSize = 20;
            DockPanelProcuctList.Children.Add(tbHead);


            foreach (var item in order._productList)
            {
                
                string s = item.Name +"  "+ item.Price+ " zł";
                TextBlock tb = fabryka.GeneraTextBlock(s);
                DockPanel.SetDock(tb, Dock.Top);
                tb.TextAlignment = TextAlignment.Left;
                tb.Tag = item.Id_Product;
                tb.MouseLeftButtonUp += Clicktb;
                DockPanelProcuctList.Children.Add(tb);

            }

            order.CalculateSum();


            string ss = "Suma: "+order._sum+" zł";
            TextBlock tbSum = fabryka.GeneraTextBlock(ss);
            tbSum.FontSize = 20;
            tbSum.TextAlignment = TextAlignment.Right;
            DockPanel.SetDock(tbSum, Dock.Bottom);
            DockPanelProcuctList.Children.Add(tbSum);
        }

        private void Clicktb(object sender, MouseButtonEventArgs e)
        {
            var tb = sender as TextBlock;
            var p = order._productList.FirstOrDefault(s => s.Id_Product == (int)tb.Tag);
            order._productList.Remove(p);
            DisplayProductList();
        }

        public void DisplayCategory(object sender, RoutedEventArgs e)
        {
            UniformGridNewProduct.Children.Clear();
            ComponentFabryk fabryka =  new ComponentFabryk();

            var products = db.Products;
            var result = products.GroupBy(test => test.Category).ToList();

            foreach (var item in result)
            {
                TextBlock tb = fabryka.GeneraTextBlock(item.Key);
                Button b = fabryka.GenerateButton(tb);
                b.Click += DisplayProduct;
                UniformGridNewProduct.Children.Add(b);
            }
        }

        public void DisplayProduct(object sender, RoutedEventArgs e)
        {
            ComponentFabryk fabryka = new ComponentFabryk();
            UniformGridNewProduct.Children.Clear();

            CaffeDataContext db = new CaffeDataContext();
            string ct = ((sender as Button).Content as TextBlock).Text;
            var products = db.Products.Where(s=> s.Category.Equals(ct));

            foreach (var item in products)
            {


                TextBlock tb = fabryka.GeneraTextBlock(item.Name);
                Button b = fabryka.GenerateButton(tb);
                b.Tag = item.Price;
                b.Click += AddProduct;
                UniformGridNewProduct.Children.Add(b);
            }

            Button bb = fabryka.GenerateButton("");
            bb.Content = "Back";      
            bb.Click += DisplayCategory;
            UniformGridNewProduct.Children.Add(bb);
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            string ct = ((sender as Button).Content as TextBlock).Text;

            var product = db.Products.FirstOrDefault(s => s.Name.Equals(ct));
            order.AddProduct(product);
            DisplayProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EndOrderWindow ee = new EndOrderWindow(order);
            this.Close();
            ee.Show();
        }
    }
}
