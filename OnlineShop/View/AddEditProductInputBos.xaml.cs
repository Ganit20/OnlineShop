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
using System.Windows.Shapes;
using OnlineShop.Model;
using static OnlineShop.Model.InputBoxOutput;

namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for AddEditProductInputBos.xaml
    /// </summary>
    public partial class AddEditProductInputBos : Window
    {
        public ObservableCollection<Category> Categories { get; set; }
        public AddEditProductInputBos(Product product,ObservableCollection<Category> categories)
        {
            InitializeComponent();
            Product = product;
            Result = BoxOutput.Cancel;
            Categories = categories;
            this.DataContext = this;
            
        }
        public Product Product { get; set; }
        /// <summary>
        /// Product item that can be used to Edit or add depend on action
        /// </summary>
        public BoxOutput Result { get; set; }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            if (Product.ProductName != "" && Product.ProductName != null)
            {
                Result = BoxOutput.Ok;
                this.Close();
            }
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Result = BoxOutput.Cancel;
            this.Close();
        }



        private void ChangeProductCategory(object sender, SelectionChangedEventArgs e)
        {
            if(((ComboBox)e.Source).SelectedItem!=null)
            Product.ProductCategoryId = ((Category)((ComboBox)e.Source).SelectedItem).Id;
        }
    }
}
