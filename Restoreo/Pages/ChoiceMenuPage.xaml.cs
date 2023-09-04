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
using Restoreo.ViewModels;

namespace Restoreo.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoiceMenuPage.xaml
    /// </summary>
    public partial class ChoiceMenuPage : Page
    {
        public ChoiceMenuPage()
        {
            InitializeComponent();
            DataContext = new MenusViewModel();
        }
    }
}
