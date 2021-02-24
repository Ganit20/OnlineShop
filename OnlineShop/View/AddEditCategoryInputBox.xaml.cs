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
using System.Windows.Shapes;
using static OnlineShop.Model.InputBoxOutput;

namespace OnlineShop.View
{
    /// <summary>
    /// Interaction logic for AddEditCategoryInputBox.xaml
    /// </summary>
    public partial class AddEditCategoryInputBox : Window
    {

        public Category Category {get;set;}
        /// <summary>
        /// Category item that can be used to Edit or add depend on action
        /// </summary>
        public BoxOutput Result { get; set; }
        public AddEditCategoryInputBox(Category category)
        {
            InitializeComponent();
            Category = category;
            Result = BoxOutput.Cancel;
            this.DataContext = this;
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            if (Category.CategoryName != "" && Category.CategoryName != null)
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
        
    }
    
}
