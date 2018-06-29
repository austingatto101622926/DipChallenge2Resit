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
using DipChallengeResit_DataAccess;
using DipChallengeResit_DataAccess.Models;

namespace DipChallengeResit_WPF
{
    /// <summary>
    /// Interaction logic for Procedures.xaml
    /// </summary>
    public partial class Procedures : Page
    {
        Control Control;
        List<Procedure> procedures;

        public Procedures(Control control)
        {
            InitializeComponent();
            Control = control;
            PopulateElements();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = sender as Button;
            Control.Treatments = new Treatments(Control, int.Parse(btnSender.Tag.ToString()));
            NavigationService.Navigate(Control.Treatments);
        }

        private async void PopulateElements()
        {
            procedures = await Control.DataAccess.Procedure.GET();
            ProcedureListView.ItemsSource = procedures;
        }
    }
}

