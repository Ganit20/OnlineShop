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
using OnlineShop.Model;
namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page, IShopPage
    {
        public AdminPanel()
        {
            InitializeComponent();
            CategoriesTab.Content = new AdminPanelControl();
            ProductTab.Content = new AdminPanelProductsControl();
        }
       public void Refresh()
        {
            (TabControl.SelectedContent as IShopPage)?.Refresh();
        }
    }
}
