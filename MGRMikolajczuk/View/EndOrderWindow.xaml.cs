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
    /// Interaction logic for EndOrderWindow.xaml
    /// </summary>

    public partial class EndOrderWindow : Window
    {
        Order order;
        public EndOrderWindow(Order oo)
        {
            InitializeComponent();
            order = oo;
            DisplayOrder();
        }

        private void ClickEndOrder(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DisplayOrder()
        {
            TextBlockName.Text = order._name;
            TextBlockSum.Text = order._sum +  " zł";
        }
    }
}
