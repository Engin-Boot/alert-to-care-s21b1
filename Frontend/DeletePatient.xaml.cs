using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for DeletePatient.xaml
    /// </summary>
    public partial class DeletePatient : UserControl, INotifyPropertyChanged
    {
        ObservableCollection<string> _patientIdList;
        string patientId;

        public event PropertyChangedEventHandler PropertyChanged;

        public DeletePatient()
        {
            InitializeComponent();
            this._patientIdList = new ObservableCollection<string>();
            this.DataContext = this;
            RetrievePatients();
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string PatientId
        {
            get { return this.patientId; }
            set
            {
                if (this.patientId != value)
                {
                    this.patientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }

        public ObservableCollection<string> PatientIdList
        {
            get { return this._patientIdList; }
            set { this._patientIdList = value; }
        }

        public void RetrievePatients()
        {
            var patients = new PatientApiCalls().GetAllPatients();
            foreach(var patient in patients)
            {
                this.PatientIdList.Add(patient.PatientId);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = new PatientApiCalls().RemovePatient(PatientId);
            MessageBox.Show(result);
            LoadMainPage();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
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
    }
}
