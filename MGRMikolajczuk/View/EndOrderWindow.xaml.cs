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
using MGRMikolajczuk.Model.RabatClasses;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for EndOrderWindow.xaml
    /// </summary>

    public partial class EndOrderWindow : Window
    {
        private OrderClass _orderClass;
        private User _user;
        private AllOrdersWindow _allOrdersWindow;
        public EndOrderWindow(OrderClass oo, User u, AllOrdersWindow all)
        {
            InitializeComponent();
            _orderClass = oo;
            _user = u;
            _allOrdersWindow = all;
            DisplayOrder();
        }

        private void ClickEndOrder(object sender, RoutedEventArgs e)
        {
            AddOrder ad = new AddOrder();
            ad.Add(_orderClass,_user.Id_user, paymentSystem());
            Singleton s = Singleton.Instance;

            s.orderList.Remove(_orderClass);
            _allOrdersWindow.DispayActiveOrders();
            this.Close();
        }

        private string paymentSystem()
        {
            if (CartRadioButton.IsChecked == true)
                return "KARTA";
            else if (CashRadioButton.IsChecked == true)
                return "GOTOWKA";
            else if (NoneRadioButton.IsChecked == true)
                return "KOSZT_FIRMY";
            return null;
        }

        private void DisplayOrder()
        {
            TextBlockName.Text = _orderClass._name;
            TextBlockSum.Text = _orderClass._sum + " zł";
        }

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            OrderDetailWindow w = new OrderDetailWindow(_orderClass,_user,_allOrdersWindow);
            this.Close();
            w.Show();
        }

        private void ChekedRabat(object sender, RoutedEventArgs e)
        {
            if (_orderClass == null)
                return;

            var radio = sender as RadioButton;
            string radioName = radio.Name;

            CheckButtonBack(radioName);

            RabatFactory rababaFactory = new RabatFactory();
            _orderClass.SetRabat(rababaFactory.ProductRabat(radioName));

            _orderClass.CalculateSum();
            DisplayOrder();
        }

        private void CheckButtonBack(string radioName)
        {
            if (radioName != "_0RabatRadioButton")
                BackButton.IsEnabled = false;
            else
                BackButton.IsEnabled = true;
        }
    }
}
