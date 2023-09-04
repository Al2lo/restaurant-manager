using Restoreo.ViewModels;
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

namespace Restoreo.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContinuePageAdmin.xaml
    /// </summary>
    public partial class ContinuePageAdmin : Page
    {
        public ContinuePageAdmin(AdminApplicationViewModels widnow)
        {
            InitializeComponent();
            this.DataContext = new ControlInfoPagesAdmin(widnow);
        }
    }
}
