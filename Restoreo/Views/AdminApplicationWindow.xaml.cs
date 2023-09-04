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
using Restoreo.ViewModels;

namespace Restoreo.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminApplicationWindow.xaml
    /// </summary>
    public partial class AdminApplicationWindow : Window
    {
        public AdminApplicationWindow()
        {
            InitializeComponent();
            this.DataContext = new AdminApplicationViewModels();
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
