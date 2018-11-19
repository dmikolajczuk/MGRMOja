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

        private void ClickBack(object sender, RoutedEventArgs e)
        {
            OrderDetailWindow w = new OrderDetailWindow(order);
            this.Close();
            w.Show();
        }

        private void ChekedRabat(object sender, RoutedEventArgs e)
        {
            if (order == null)
                return;

            var radio = sender as RadioButton;
            string radioName = radio.Name;

            CheckButtonBack(radioName);

            RabatFactory rababaFactory = new RabatFactory();
            order.SetRabat(rababaFactory.ProductRabat(radioName));

            order.CalculateSum();
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
