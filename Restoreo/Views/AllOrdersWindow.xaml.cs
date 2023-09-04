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
using System.Windows.Shapes;

namespace Restoreo.Views
{
    /// <summary>
    /// Логика взаимодействия для AllOrdersWindow.xaml
    /// </summary>
    public partial class AllOrdersWindow : Window
    {
        public AllOrdersWindow()
        {
            InitializeComponent();
        }
        private void CloseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        private void MinimizeClick(object sender, MouseEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
