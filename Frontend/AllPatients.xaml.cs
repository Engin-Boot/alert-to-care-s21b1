using Backend.Models;
using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for AllPatients.xaml
    /// </summary>
    public partial class AllPatients : UserControl
    {

        ObservableCollection<string> _patientIdList;
        ObservableCollection<PatientModel> _patients;
        public AllPatients()
        {
            InitializeComponent();
            this._patientIdList = new ObservableCollection<string>();
            this.DataContext = this;
            RetrievePatients();
        }

        public ObservableCollection<string> PatientIdList
        {
            get { return this._patientIdList; }
            set { this._patientIdList = value; }
        }

        public void RetrievePatients()
        {
            _patients = new PatientApiCalls().GetAllPatients();
            foreach (var patient in _patients)
            {
                this.PatientIdList.Add(patient.PatientId);
            }
        }

       
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMainPage();
        }
        private void LoadMainPage()
        {

            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new MainPage());
        }

        private void patientIdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedId = this.patientIdList.SelectedItem.ToString();
            var patient = _patients.ToList().Find(patient => patient.PatientId == selectedId);
            this.patientId.Text = patient.PatientId;
            this.icuId.Text = patient.IcuId;
            this.bedId.Text = patient.BedId;
            this.name.Text = patient.Name;
            this.age.Text = patient.Age.ToString();
            this.address.Text = patient.Address;
            this.gender.Text = patient.Gender;
            this.contact.Text = patient.ContactNo;
        }
    }
}
