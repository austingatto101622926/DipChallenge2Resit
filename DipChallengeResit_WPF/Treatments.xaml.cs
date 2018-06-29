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
    /// Interaction logic for Treatments.xaml
    /// </summary>
    public partial class Treatments : Page
    {
        Control Control;
        List<Treatment> treatments;

        public Treatments(Control control, int? procedureID = null)
        {
            InitializeComponent();
            Control = control;
            PopulateElements(procedureID);
        }

        private async void PopulateElements(int? procedureID)
        {

            treatments = await Control.DataAccess.Treatment.GET();
            if (procedureID == null)
            {
                TreatmentListView.ItemsSource = treatments;
            }
            else
            {
                TreatmentListView.ItemsSource = treatments.Where(T => T.ProcedureID == procedureID);
            }
        }
    }
}
