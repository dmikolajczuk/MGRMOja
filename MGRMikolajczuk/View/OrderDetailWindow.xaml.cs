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
using MGRMikolajczuk.Model;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private OrderClass _orderClass;
        private User _user;
        private CaffeDataContext db;
        private AllOrdersWindow allWindow;
        public OrderDetailWindow(OrderClass o, User u, AllOrdersWindow all)
        {
            InitializeComponent();
            _user = u;
            _orderClass = o;
            db = new CaffeDataContext();
            allWindow = all;

            //DisplayProductList();
            DisplayCategory(null, null);
            DisplayProductList();
        }

        public void DisplayProductList()
        {
            ComponentFabryk fabryka = new ComponentFabryk();

            DockPanelProcuctList.Children.Clear();

            foreach (var item in _orderClass._productList)
            {
                
                string s = item.product.Name +"  "+ item.product.Price+ " zł" + "      x" + item.quantity;
                TextBlock tb = fabryka.GeneraTextBlock(s);
                DockPanel.SetDock(tb, Dock.Top);
                tb.TextAlignment = TextAlignment.Left;
                tb.Tag = item.product.Id_Product;
                tb.MouseLeftButtonUp += Clicktb;
                DockPanelProcuctList.Children.Add(tb);

            }

            _orderClass.CalculateSum();


            string ss = "Suma: "+_orderClass._sum+" zł";
            TextBlock tbSum = fabryka.GeneraTextBlock(ss);
            tbSum.FontSize = 20;
            tbSum.TextAlignment = TextAlignment.Right;
            DockPanel.SetDock(tbSum, Dock.Bottom);
            DockPanelProcuctList.Children.Add(tbSum);
        }

        private void Clicktb(object sender, MouseButtonEventArgs e)
        {
            var tb = sender as TextBlock;
            var p = _orderClass._productList.FirstOrDefault(s => s.product.Id_Product == (int)tb.Tag);
            _orderClass.RemuveProduct(p);
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
            ProduckQuantity pp = new ProduckQuantity(product,1);
            _orderClass.AddProduct(pp);
            DisplayProductList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EndOrderWindow ee = new EndOrderWindow(_orderClass,_user,allWindow);
            allWindow.DispayActiveOrders();
            this.Close();
            ee.Show();
        }
    }
}
