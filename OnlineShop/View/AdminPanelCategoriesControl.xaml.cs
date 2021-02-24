using Microsoft.EntityFrameworkCore;
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
using static OnlineShop.Model.InputBoxOutput;

namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for AdminPanelControl.xaml
    /// </summary>
    public partial class AdminPanelControl : UserControl,IShopPage
    {
        public ObservableCollection<Category> Categories { get; set; }
        public AdminPanelControl ( )
        {
            InitializeComponent();
            Categories = new ObservableCollection<Category>();
            this.DataContext = this;
            Refresh();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var inputBox = new AddEditCategoryInputBox(new Category());
            inputBox.ShowDialog();
            if (inputBox.Result == BoxOutput.Ok)
            {
                using (var context = new OnlineShopDBContext())
                {
                    context.Categories.Add(inputBox.Category);
                    context.SaveChanges();
                }
                Refresh();
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (CategoryList.SelectedItem != null)
            {
                var inputBox = new AddEditCategoryInputBox((Category)CategoryList.SelectedItem);
                inputBox.ShowDialog();
                if (inputBox.Result == BoxOutput.Ok)
                {
                    using (var context = new OnlineShopDBContext())
                    {

                        context.Categories.Update(inputBox.Category);
                        context.SaveChanges();
                    }
                
                Refresh();
                }
            }
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
           var result = MessageBox.Show("Are you Sure?", "Alert", MessageBoxButton.YesNo);
            if (CategoryList.SelectedItem != null && result== MessageBoxResult.Yes)
            {
               
                using (var context = new OnlineShopDBContext())
                {
                    context.Categories.Remove((Category)CategoryList.SelectedItem);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
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
                Categories.Clear();
            foreach(var c in context.Categories)
            {
                    Categories.Add(c);
            }
            }
        }
    }
}
