using OnlineShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private static MainWindow _mainWindow;
        public MainWindow()
        {
            InitializeComponent();
            MainWindow._mainWindow = this;
            MainFrame.Navigate(new LoginPage());
        }
        public static MainWindow MainWindowInstance
        {
            get
            {
                if (_mainWindow == null)
                {
                    _mainWindow = new MainWindow();
                }
                return _mainWindow;
            }
        }
       
        
    }
    
}
