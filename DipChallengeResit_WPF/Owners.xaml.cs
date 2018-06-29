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
using DipChallengeResit_DataAccess.Models;

namespace DipChallengeResit_WPF
{
    /// <summary>
    /// Interaction logic for Owners.xaml
    /// </summary>
    public partial class Owners : Page
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        Control Control;
        List<Owner> owners;
        Owner SelectedOwner;

        public Owners(Control control)
        {
            InitializeComponent();
            Control = control;
            PopulateElements();
        }

        private async void PopulateElements()
        {
            owners = await Control.DataAccess.Owner.GET();
            OwnerListView.ItemsSource = owners;
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            SelectedOwner = null;

            InputOwnerID.Text = "New User";
            InputSurname.Text = "";
            InputGivenName.Text = "";
            InputPhone.Text = "";
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
                if (SelectedOwner == null)
                {
                    SelectedOwner = new Owner();
                    SelectedOwner.Surname = InputSurname.Text;
                    SelectedOwner.GivenName = InputGivenName.Text;
                    SelectedOwner.phone = InputPhone.Text;

                    await Control.DataAccess.Owner.POST(SelectedOwner);
                }
                else
                {
                    SelectedOwner.Surname = InputSurname.Text;
                    SelectedOwner.GivenName = InputGivenName.Text;
                    SelectedOwner.phone = InputPhone.Text;

                    Control.DataAccess.Owner.PUT(SelectedOwner.OwnerID, SelectedOwner);
                }
                PopulateElements();
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await Control.DataAccess.Owner.DELETE(SelectedOwner.OwnerID);
            }
            catch (Exception ex)
            {
                logger.Fatal($"Delete Owner Api Failure: {ex.Message}");
                MessageBox.Show(ex.Message);
            }
            PopulateElements();
        }

        private async void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = sender as Button;
            SelectedOwner = await Control.DataAccess.Owner.GET(int.Parse(btnSender.Tag.ToString()));

            InputOwnerID.Text = SelectedOwner.OwnerID.ToString();
            InputSurname.Text = SelectedOwner.Surname;
            InputGivenName.Text = SelectedOwner.GivenName;
            InputPhone.Text = SelectedOwner.phone;
            PopulateElements();
        }

        private bool validateInput()
        {
            try
            {
                if (InputSurname.Text.Trim() == "") throw new ValidationFailureException("Cannot submit blank Surname value");
                if (InputGivenName.Text.Trim() == "") throw new ValidationFailureException("Cannot submit blank GivenName value");
                if (InputPhone.Text.Trim() == "") throw new ValidationFailureException("Cannot submit blank Phone value");

                if (InputSurname.Text.Any(char.IsDigit)) throw new ValidationFailureException("Surname cannot contain numbers");
                if (InputGivenName.Text.Any(char.IsDigit)) throw new ValidationFailureException("GivenName cannot contain numbers");
                if (!InputPhone.Text.Trim().All(char.IsDigit)) throw new ValidationFailureException("Phone Number cannot contain letters or special characters");

                if (InputPhone.Text.Trim().Count() > 15) throw new ValidationFailureException("Phone Number too large");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
            
        }
    }
}
