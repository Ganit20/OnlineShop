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
        ObservableCollection<Category> CategoryList;
        ObservableCollection<Product> ProductList;
        public ShopMainScreen()
        {
            InitializeComponent();
            CategoryList = new ObservableCollection<Category>();
            ProductList = new ObservableCollection<Product>();
            DownloadProductsAndCategories();
            this.DataContext = this;
        }

        private void DownloadProductsAndCategories()
        {
            using (var context = new OnlineShopDBContext())
            {
               
               var products = context.Products;
                foreach (var p in products)
                    ProductList.Add(p);
                var categories = context.Categories;
                foreach (var c in categories)
                    CategoryList.Add(c);
            }
        }
    }
}
