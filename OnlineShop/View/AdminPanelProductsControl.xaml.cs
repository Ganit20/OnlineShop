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
using static OnlineShop.Model.InputBoxOutput;

namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for AdminPanelProductsControl.xaml
    /// </summary>
    public partial class AdminPanelProductsControl : UserControl, IShopPage
        
    {
        public AdminPanelProductsControl()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            Categories = new ObservableCollection<Category>();
            this.DataContext = this;
            Refresh();
        }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Category> Categories { get; set; }



        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var inputBox = new AddEditProductInputBos(new Product(),Categories);
            inputBox.ShowDialog();
            if (inputBox.Result == BoxOutput.Ok)
            {
                using (var context = new OnlineShopDBContext())
                {
                    context.Products.Add(inputBox.Product);
                    try
                    {
                        context.SaveChanges();
                    }catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    {
                        MessageBox.Show("Fill Every Input");
                    }
                }
                Refresh();
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem != null)
            {
                var inputBox = new AddEditProductInputBos((Product)ProductList.SelectedItem,Categories);
                inputBox.ShowDialog();
                if (inputBox.Result == BoxOutput.Ok)
                {
                    using (var context = new OnlineShopDBContext())
                    {

                        context.Products.Update(inputBox.Product);
                        context.SaveChanges();
                    }

                    Refresh();
                }
            }
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you Sure?", "Alert", MessageBoxButton.YesNo);
            if (ProductList.SelectedItem != null && result == MessageBoxResult.Yes)
            {

                using (var context = new OnlineShopDBContext())
                {
                    context.Products.Remove((Product)ProductList.SelectedItem);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    {
                        MessageBox.Show("Category must not contain any products to be deleted");
                    }
                }
            }
            Refresh();
        }

        public void Refresh()
        {
            using (var context = new OnlineShopDBContext())
            {
                Products.Clear();
                foreach (var c in context.Products)
                {
                    Products.Add(c);
                }
            }
            using (var context = new OnlineShopDBContext())
            {
                Categories.Clear();
                foreach (var c in context.Categories)
                {
                    Categories.Add(c);
                }
            }
        }
    }
}
