using Backend.Models;
using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<string> alertList = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            new VitalApiCalls().StartVitalsUpdate();
            
            var count = new IcuApiCalls().GetAllIcus().Count();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (count == 0)
                LeftSide.Children.Add(new IcuConfiguration());
            else
            {
                MainPage mainPage = new MainPage();
                LeftSide.Children.Add(mainPage);
            }

            KeepMonitoringVitals();
            CheckAllVitals(new object(),new EventArgs());
        }

        public ObservableCollection<string> AlertList
        {
            get { return this.alertList; }
            set { this.alertList = value; }
        }

        public void KeepMonitoringVitals()
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(CheckAllVitals);
            timer1.Interval = 30000; // in miliseconds
            timer1.Start();
        }

        public void CheckAllVitals(object sender, EventArgs e)
        {
            AlertList.Clear();
            //MessageBox.Show("Check All Vitals Called");
            var patientVitals = new VitalApiCalls().GetAllVitals();
            if (patientVitals != null)
            {
                foreach (var patientVital in patientVitals)
                {
                    CheckPatientVitals(patientVital);
                }
            }
        }

        public void CheckPatientVitals(PatientVitalsModel patientVital)
        {
            foreach (var vital in patientVital.Vitals)
            {
                if (!MonitorVital(vital.Value, vital.Lower, vital.Upper))
                {
                    //var tempPatient = new PatientApiCalls().GetPatient(patientVital.PatientId);
                    //this.icuComboBox.Text = tempPatient.IcuId;
                    AlertList.Add(patientVital.PatientId + " : " + vital.VitalName);
                    //MessageBox.Show(tempPatient.PatientId + vital.VitalName);
                    //var BedButton = LogicalTreeHelper.FindLogicalNode(this.BedDock, tempPatient.BedId) as Button;
                    //if (BedButton != null)
                    //    BedButton.Background = Brushes.Red;                    
                }
            }
        }


        public bool MonitorVital(float value, float lower, float upper)
        {
            return value >= lower && value <= upper;
        }


    }
}
