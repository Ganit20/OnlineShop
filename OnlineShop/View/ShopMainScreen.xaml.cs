using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ShopMainScreen.xaml
    /// </summary>
    public partial class ShopMainScreen : Page
    {
        IShopPage ActualPage;
        ProductExplorer productExplorer;
       ProductExplorer ProductExplorer 
        { 
            get
            {
                if(productExplorer == null)
                {
                    productExplorer = new ProductExplorer();
                }
                return productExplorer;
            }
            set
            {
                productExplorer = value;
            }
        }
        AdminPanel adminPanel; 
        AdminPanel AdminPanel 
        { 
            get
            {
                if(adminPanel == null)
                {
                    adminPanel = new AdminPanel();
                }
                return adminPanel;
            }
            set
            {
                adminPanel = value;
            }
        }
        ProfilePage profilePage;
        ProfilePage ProfilePage
        { 
            get
            {
                if(profilePage == null)
                {
                    profilePage = new ProfilePage();
                }
                return profilePage;
            }
            set
            {
                profilePage = value;
            }
        }
        public ShopMainScreen()
        {
            InitializeComponent();
            ShopPageFrame.Navigate(ProductExplorer);
            ActualPage = ProductExplorer;
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            ActualPage.Refresh();
        }

        private void HomePageClick(object sender, RoutedEventArgs e)
        {
            if (ActualPage == ProductExplorer)
                ActualPage.Refresh();
            else
            {
                ShopPageFrame.Navigate(ProductExplorer);
                ActualPage = ProductExplorer;
            }
        }

        private void AdminPanelClick(object sender, RoutedEventArgs e)
        {
            if (StaticInfo.IsAdmin)
            {
                ShopPageFrame.Navigate(AdminPanel);
                ActualPage = AdminPanel;
            }
            else
                MessageBox.Show("You do not have permission to do this");

        }

        private void CartClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void ProfileClick(object sender, RoutedEventArgs e)
        {
            if (ActualPage == ProfilePage)
                ActualPage.Refresh();
            else
            {
                ShopPageFrame.Navigate(ProfilePage);
                ActualPage = ProfilePage;
            }
        }
    }
}
