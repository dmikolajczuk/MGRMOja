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
            DispayActiveOrders();
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

        public void DispayActiveOrders()
        {
            ComponentFabryk fabryka = new ComponentFabryk();
            orderUniformGread.Children.Clear();

            foreach (var item in _singleton.orderList)
            {

                Panel panel = fabryka.GenerateGrid();
                
                StackPanel sp = new StackPanel();
                sp.Children.Add(fabryka.GeneraTextBlock(item._name));
                string n = "Suma: " + item._sum + " zł";
                sp.Children.Add(fabryka.GeneraTextBlock(n));

                Button b = fabryka.GenerateButton(item._name);
                b.Click += OrderDetail;
                sp.Children.Add(b);

                panel.Children.Add(fabryka.GenerateBorder(sp));
                orderUniformGread.Children.Add(panel);
            }
        }

        private void OrderDetail(object sender, RoutedEventArgs e)
        {
            Button button =(Button)sender;
            object orderstring = button.Tag;
            var o = _singleton.orderList.FirstOrDefault(s => s._name.Equals(orderstring));
            //Console.WriteLine(o.ToString());
            OrderDetailWindow np = new OrderDetailWindow(o,_user);
            np.Show();
        }

        private void LogoutButton_OnClick(object sender, RoutedEventArgs e)
        {
          MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }
    }
}
