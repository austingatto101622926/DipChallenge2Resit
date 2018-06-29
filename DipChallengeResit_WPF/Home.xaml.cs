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

namespace DipChallengeResit_WPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Control Control;
        public Home()
        {
            InitializeComponent();
            Control = new Control(this);
        }

        private void Procedures_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Control.Procedures);
        }

        private void Owners_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Control.Owners);
        }
    }
}
