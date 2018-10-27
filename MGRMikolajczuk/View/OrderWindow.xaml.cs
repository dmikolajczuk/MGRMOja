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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private User user;
        public OrderWindow(User u)
        {
            user = u;
            InitializeComponent();
            setUserlabel();
        }

        private void ButtonNewOrderClick(object sender, RoutedEventArgs e)
        {

        }

        private void setUserlabel()
        {
            this.userLabel.Text = user.Name;
        }
    }
}
