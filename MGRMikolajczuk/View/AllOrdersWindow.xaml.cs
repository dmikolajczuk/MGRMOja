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
using Order = MGRMikolajczuk.App_data.Order;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for AllOrdersWindow.xaml
    /// </summary>
    public partial class AllOrdersWindow : Window
    {
        private User _user;
        private Singleton _singleton;
        public AllOrdersWindow(User u)
        {
            _user = u;
            _singleton = Singleton.Instance;

            InitializeComponent();
            setUserlabel();
            DispayactiveOrders();
        }

        private void ButtonNewOrderClick(object sender, RoutedEventArgs e)
        {
            NewOrderWidnow newOrder = new NewOrderWidnow(this);
            newOrder.Show();
        }

        private void setUserlabel()
        {
            this.userLabel.Text = _user.Name;
        }

        public void DispayactiveOrders()
        {
            orderUniformGread.Children.Clear();

            foreach (var item in _singleton.orderList)
            {


                Panel panel = new Grid();
                panel.VerticalAlignment = VerticalAlignment.Center;
                panel.Margin = new Thickness(5,5,5,5);
                
                StackPanel sp = new StackPanel();
                sp.Children.Add(new TextBlock() {Text = item._name, TextAlignment = TextAlignment.Center,});
                sp.Children.Add(new TextBlock() { Text = "Suma: "+item._sum + " zł" , TextAlignment = TextAlignment.Center });

                Button b = new Button();
                b.Content = "Otworz zamówienie";
                b.Click += OrderDetail;
                Style s = this.FindResource("ButtonShadow") as Style;
                b.Style = s;
                b.Height = 50;

                sp.Children.Add(b);

                panel.Children.Add(new Border()
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Child = sp
                });
                orderUniformGread.Children.Add(panel);
            }
        }

        private void OrderDetail(object sender, RoutedEventArgs e)
        {
            NewProductsWindow np = new NewProductsWindow();
            np.Show();
        }
    }
}
