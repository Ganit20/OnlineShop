using Microsoft.EntityFrameworkCore;
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

namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.Password != ConfirmPasswordInput.Password)
                MessageBox.Show("Passwords do not match each other");
            if(!EmailInput.Text.Contains('@') && !EmailInput.Text.Contains('.'))
                MessageBox.Show("Enter valid Email");
            if (LoginInput.Text != "" && PasswordInput.Password != "" && ConfirmPasswordInput.Password != "" && EmailInput.Text != "") {
                using (var context = new OnlineShopDBContext())
                {
                    var customer = new User()
                    {
                        Login = LoginInput.Text,
                        Password = PasswordInput.Password,
                        Email = EmailInput.Text,
                        UserRoleId = 2,
                    };
                    context.Users.Add(customer);

                    context.SaveChanges();

                    MainWindow.MainWindowInstance.MainFrame.Navigate(new LoginPage());
                } }
            else
            {
                MessageBox.Show("Fill all inputs");
            } 

        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainWindowInstance.MainFrame.Navigate(new LoginPage());
        }
    }
}
