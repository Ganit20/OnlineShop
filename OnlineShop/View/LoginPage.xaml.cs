using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (LoginInput.Text == "" || PasswordInput.Password == "")
                return;
            using(var context = new OnlineShopDBContext())
            {
                string sqlQuery = $"Select * from Users Where Login='{LoginInput.Text}'";
                var user = context.Users.FromSqlRaw(sqlQuery).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Wrong Username or Password");
                    return;
                }
                if (LoginInput.Text == user.Login && PasswordInput.Password == user.Password)
                {
                    StaticInfo.UserName = user.Login;
                    StaticInfo.UserEmail = user.Email;
                    StaticInfo.UserRole = context.UserRoles.FromSqlRaw($"Select * from UserRoles Where Id='{user.UserRoleId}'").FirstOrDefault().RoleName;
                }
                MainWindow.MainWindowInstance.MainFrame.Navigate(new ShopMainScreen());
            }
            
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWindowInstance.MainFrame.Navigate(new RegisterPage());
        }
    }
}
