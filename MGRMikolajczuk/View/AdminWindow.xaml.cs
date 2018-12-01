using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private int userID;
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void ButtonSaveUser_OnClick(object sender, RoutedEventArgs e)
        {
            CheckPassAndLogin check = new CheckPassAndLogin();
            CaffeDataContext db = new CaffeDataContext();
            HashClass hash = new HashClass();

            if (check.ChceckPassEqals(Pass1TB.Text, Pass2TB.Text) && check.ChceckPassNumeric(Pass1TB.Text)
                                                                  && check.CheckPassLength(Pass1TB.Text))
            {
                int IdMax = db.Users.Max(s => s.Id_user);
                User u = new User()
                {
                    Name = UserNameTB.Text,
                    Id_user = IdMax + 1,
                    Password = hash.GetHashString(Pass1TB.Text)
                };
                db.Users.InsertOnSubmit(u);
                db.SubmitChanges();

                MessageBox.Show("Zapisoano zmiany !!!");
                Pass1TB.Text = "";
                Pass2TB.Text = "";
                UserNameTB.Text = "";

            }

            else
            {
                MessageBox.Show("Nieprawidłowe dane !");
            }

        }


        private void LogoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        private void UniformGridUsers_OnLoaded()
        {
            CaffeDataContext db = new CaffeDataContext();
            UniformGridUsers.Children.Clear();
            var users = db.Users;
            foreach (var item in users)
            {
                RadioButton rb = new RadioButton();
                rb.Content = item.Name;
                rb.Checked += RadiobuttonChecked;
                rb.Tag = item.Id_user;
                UniformGridUsers.Children.Add(rb);
            }

        }

        private void RadiobuttonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            userID = (int)rb.Tag;
            //Console.WriteLine(userName);
        }

        private void setUserlabel()
        {
            this.userLabel.Text = "ADMIN";
        }


        private void ButtonSavePassChange_OnClick(object sender, RoutedEventArgs e)
        {
            CheckPassAndLogin check = new CheckPassAndLogin();
            if (check.ChceckPassEqals(Pass11TB.Text, Pass22TB.Text) && check.ChceckPassNumeric(Pass11TB.Text)
                                                                  && check.CheckPassLength(Pass11TB.Text))
            {
                CaffeDataContext db = new CaffeDataContext();
                HashClass hash = new HashClass();
                User u = db.Users.FirstOrDefault(s => s.Id_user == userID);
                u.Password = hash.GetHashString(Pass11TB.Text);
                db.SubmitChanges();

                MessageBox.Show("Zapisano zmieny  !!!");
                Pass11TB.Text = "";
                Pass22TB.Text = "";
            }

            else
            {
                MessageBox.Show("Nieprawidłowe dane !");
            }

        }

        private void ButtonAddNewProduct_OnClick(object sender, RoutedEventArgs e)
        {
            CaffeDataContext db = new CaffeDataContext();
            int IdMax = db.Products.Max(s => s.Id_Product);
            double price;
            if (double.TryParse(PriceTB.Text, out price) || string.IsNullOrEmpty(ProduktNameTB.Text))
            {
                Product p = new Product()
                {
                    Name = ProduktNameTB.Text,
                    Category = CategoryComboBox.Text,
                    Price = price,
                    Id_Product = IdMax + 1
                };
                db.Products.InsertOnSubmit(p);
                db.SubmitChanges();

            }
            else
                MessageBox.Show("Nieprawidłowe dane !!!");

            Console.WriteLine(price);
        }


        private void CategoryComboBox_OnLoaded()
        {
            CaffeDataContext db = new CaffeDataContext();
            var result = db.Products.GroupBy(s => s.Category).ToList();
            CategoryComboBox.Items.Clear();
            foreach (var item in result)
            {
                ComboBoxItem cbItem = new ComboBoxItem();
                cbItem.Content = item.Key;
                CategoryComboBox.Items.Add(cbItem);
            }
        }


        private void DisplayGroupOrder()
        {
            CaffeDataContext db = new CaffeDataContext();
            var dd =
                from order in db.Orders
                group order by order.Date
                into g
                select new
                {
                    g.Key,
                    Suma = g.Sum(p => p.Sum),
                };

            DataTable dt = new DataTable();
            DataColumn _date = new DataColumn("Data");
            DataColumn _sum = new DataColumn("Podsumowanie zamowień");
            dt.Columns.Add(_date);
            dt.Columns.Add(_sum);
            foreach (var item in dd)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Key;
                dr[1] = item.Suma+" zł";
                dt.Rows.Add(dr);

            }

            DataOrders.ItemsSource = dt.DefaultView;
        }

        private void DataOrders_OnLoaded(object sender, RoutedEventArgs e)
        {
            DisplayGroupOrder();
        }

        private void ChangeUserPass_OnLoaded(object sender, RoutedEventArgs e)
        {
            UniformGridUsers_OnLoaded();
        }

        private void CategoryComboBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            CategoryComboBox_OnLoaded();
        }

        private void UserLabel_OnLoaded(object sender, RoutedEventArgs e)
        {
           setUserlabel();
        }
    }
}
