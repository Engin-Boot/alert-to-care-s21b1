using Backend.Models;
using Frontend.ApiCalls;
using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using Frontend.Validations;
namespace Frontend
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddNewPatient : UserControl
    {
        PatientDetails _patient;

        public AddNewPatient(string icId, string bId)
        {

            InitializeComponent();
            _patient = new PatientDetails();
            this.DataContext = _patient;
            this._patient.IcuIdList = new AddBed().IcuList;
            if (icId != null)
            {
                _patient.IcuId = icId;
            }
            if (bId != null)
            {
                _patient.BedId = bId;
            }

        }
        public void RetrieveBeds()
        {
            this._patient.BedIdList.Clear();
            var bedsInIcu = new BedApiCalls().GetAllBedsFromAnIcu(icuIdList.SelectedItem.ToString()).ToList();
            foreach (var bed in bedsInIcu)
            {
                if (bed.BedOccupancyStatus == "Free")
                {
                    this._patient.BedIdList.Add(bed.BedId);
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMainPage();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            PatientModel patient = new PatientModel()
            {
                PatientId = _patient.BedId + _patient.Name,
                IcuId = _patient.IcuId,
                BedId = _patient.BedId,
                Name = _patient.Name,
                Age = Int32.Parse(_patient.Age.ToString()),
                Address = _patient.Address,
                Gender = _patient.Gender,
                ContactNo = _patient.Contact
            };
            var result = new PatientApiCalls().AddPatient(patient);
            MessageBox.Show(result);
            LoadMainPage();
        }
        private void LoadMainPage()
        {

            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new MainPage());
        }

        private void icuIdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RetrieveBeds();
        }

        private void genderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
