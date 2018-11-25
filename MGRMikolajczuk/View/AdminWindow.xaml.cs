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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private int userID;
        public AdminWindow()
        {
            InitializeComponent();
            setUserlabel();
            UniformGridUsers_OnLoaded();
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
    }
}
