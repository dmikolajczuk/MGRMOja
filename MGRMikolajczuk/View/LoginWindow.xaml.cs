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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using MGRMikolajczuk.App_data;
using MGRMikolajczuk.Model;
using MGRMikolajczuk.View;

namespace MGRMikolajczuk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String _loginString = "";

        public MainWindow()
        {
            InitializeComponent();
            DispayLogin();
        }

        private void DispayLogin()
        {
            loginBox.Text = _loginString;
        }

        private bool CheckLengthLogin()
        {
            if (_loginString.Length < 4) return true;
            else return false;
        }

        private void ButtonKayClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button) sender;
            if (CheckLengthLogin())
                _loginString += b.Content;
            DispayLogin();
        }


        private void ButtonBack(object sender, RoutedEventArgs e)
        {
            if (_loginString.Length > 0)
                _loginString = _loginString.Substring(0, _loginString.Length - 1);
            DispayLogin();
        }

        private void ButtonLoginClick(object sender, RoutedEventArgs e)
        {
            HashClass hs = new HashClass();

            CaffeDataContext db  = new CaffeDataContext();
            User user = db.Users.FirstOrDefault(s => s.Password.Equals(hs.GetHashString(_loginString)));

            if (user == null)
            {
                MessageBox.Show("Nieprawidłowe dane logowania !");
                _loginString = "";
            }
            else
            {
                AllOrdersWindow allOrdersWindow = new AllOrdersWindow(user);
                this.Close();
                allOrdersWindow.Show();
            }
        }
    }
}
