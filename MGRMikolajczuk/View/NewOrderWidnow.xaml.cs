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
using MGRMikolajczuk.View;

namespace MGRMikolajczuk.View
{
    /// <summary>
    /// Interaction logic for NewOrderWidnow.xaml
    /// </summary>
    public partial class NewOrderWidnow : Window
    {
        private AllOrdersWindow allOrdersWindow;
        private Singleton singleton;
        public NewOrderWidnow (AllOrdersWindow aallw)
        {
            InitializeComponent();
            singleton = Singleton.Instance;
            allOrdersWindow = aallw;
            singleton.orderList.Add(new Order()
            {
                _name = "Zamowienie3",
                _sum = 0.00

            });
            allOrdersWindow.DispayactiveOrders();
            //this.Close();
        }
    }
}
