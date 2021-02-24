using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for ShopingCartPage.xaml
    /// </summary>
    public partial class ShopingCartPage : Page,IShopPage
    {
        public ObservableCollection<Product> ProductList { get; set; }

        public ShopingCartPage()
        {
            InitializeComponent();
            ProductList = new ObservableCollection<Product>();
            DownloadCart();
            this.DataContext = this;
        }
        public void DownloadCart()
        {
            ProductList.Clear();
            using (var context = new OnlineShopDBContext())
            {
                var userCart = context.ShoppingCarts.Where(x => x.UserId == StaticInfo.UserId);
                using(var pcontext = new OnlineShopDBContext())
                {
                    foreach (var item in userCart)
                    {
                        ProductList.Add(pcontext.Products.Where(x => x.Id == item.Id).FirstOrDefault());
                    }
                }
                
            }
        }

        public void Refresh()
        {
            DownloadCart();
        }
    }
}
