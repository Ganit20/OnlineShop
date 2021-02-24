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
    /// Interaction logic for ProductExplorer.xaml
    /// </summary>
    public partial class ProductExplorer : Page,IShopPage
    {
        /// <summary>
        /// List of categories to show in category explorer
        /// </summary>
        public ObservableCollection<Category> CategoryList { get; set; }
        Category actualCategory;
        Category ActualCategory 
        { 
            get => actualCategory;
            set {
                if (value != null)
                    actualCategory = value;
                else
                    actualCategory = CategoryList[0];
                DownloadProductsAndCategories();
            } 
        }
        /// <summary>
        /// List of categories to show in category explorer
        /// </summary>
        public ObservableCollection<Product> ProductList { get; set; }
        public ProductExplorer()
        {
            InitializeComponent();
            CategoryList = new ObservableCollection<Category>();
            ProductList = new ObservableCollection<Product>();
            DownloadProductsAndCategories();
            this.DataContext = this;
        }
        private void DownloadProductsAndCategories()
        {
            ProductList.Clear();
            CategoryList.Clear();
            using (var context = new OnlineShopDBContext())
            {
                IQueryable<Product> products;
                if (ActualCategory != null)
                     products = context.Products.Where(x => x.ProductCategoryId == ActualCategory.Id);
                else
                     products = context.Products;
                foreach (var p in products)
                    ProductList.Add(p);
                var categories = context.Categories;
                foreach (var c in categories)
                    CategoryList.Add(c);
            }
        }

        public void Refresh()
        {
            DownloadProductsAndCategories();
        }

        private void ChangeCategory(object sender, SelectionChangedEventArgs e)
        {
            if((Category)((ListView)e.Source).SelectedItem!=null)
            ActualCategory = (Category)((ListView)e.Source).SelectedItem;
        }

        private void AddToCartClick(object sender, RoutedEventArgs e)
        {
            var item = (Product)((Button)e.Source).DataContext;
            using (var context = new OnlineShopDBContext())
            {
                context.ShoppingCarts.Add(new ShoppingCart()
                {
                    ProductId = item.Id,
                    UserId = StaticInfo.UserId
                }) ;
                context.SaveChanges();
            }
        }
    }
}
