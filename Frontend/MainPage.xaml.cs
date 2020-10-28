using Backend.Models;
using Frontend.ApiCalls;
using Frontend.ViewModel;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        readonly Dictionary<string, Func<int, List<int>>> BedLayoutFunctionCall;
        public Icudetails _icuDetails;
        ObservableCollection<BedModel> beds = new ObservableCollection<BedModel>();
        List<PatientModel> patients = new List<PatientModel>();

        public MainPage()
        {
            InitializeComponent();
            _icuDetails = new Icudetails();
            this.DataContext = _icuDetails;
           
            BedLayoutFunctionCall = new Dictionary<string, Func<int, List<int>>>
            {
                { "L" , LBedLayout},
                { "U", UBedLayout },
                { "H", HBedLayout }
            };

            RetrieveAllIcusIds();
            this.icuComboBox.SelectedIndex = 0;
            SetUp(_icuDetails.IcuIdList[0]);
        }

        public void SetUp(string icuId)
        {
            var icu = RetrieveIcu(icuId);
            beds = new BedApiCalls().GetAllBedsFromAnIcu(icuId);
            CreateAndPlaceBeds(icu);
            GetAllPatientsInIcu(icuId);
        }

        public IcuModel RetrieveIcu(string icuId)
        {
            var icu = new IcuApiCalls().GetIcu(icuId);
            _icuDetails.UpdateIcuDetails(icu);
            return icu;
        }

        public void GetAllPatientsInIcu(string icuId)
        {
            patients = new PatientApiCalls().GetAllPatients().ToList().FindAll(icu => icu.IcuId == icuId);
        }

        public void RetrieveAllIcusIds()
        {
            this._icuDetails.IcuIdList.Clear();
            var allIcus = new IcuApiCalls().GetAllIcus();
            foreach(var icu in allIcus)
            {
                this._icuDetails.IcuIdList.Add(icu.IcuId);
            }          
        }


        private void CreateAndPlaceBeds(IcuModel icu)
        {
            var index = BedLayoutFunctionCall[icu.Layout].Invoke(icu.MaxBeds);
            var noOfBeds = icu.NoOfBeds;
            V1StackPanel.Children.Clear();
            HStackPanel.Children.Clear();
            V2StackPanel.Children.Clear();
            
            //var index = UBedLayout(BedList);
            for (int i=0; i < index[0] && i < noOfBeds ; i++)
            {
                
                V1StackPanel.Children.Add(CreateSingleBed(i));
            }

            index[1] = index[1] + index[0];
            for (int i = index[0]; i < index[1] && i < noOfBeds; i++)
            {
                HStackPanel.Children.Add(CreateSingleBed(i));
            }

            index[2] = index[2] + index[1];
            for (int i = index[1] ; i < index[2] && i < noOfBeds; i++)
            {
                V2StackPanel.Children.Add(CreateSingleBed(i));
            }
        }

        public Button CreateSingleBed(int i)
        {
            var color = Brushes.LightGray;
            if (beds[i].BedOccupancyStatus == "Occupied")
                color = Brushes.LightGreen;
            
            Button newBed = new Button
            {
                Content = beds[i].BedId,
                Padding = new Thickness(10),
                FontSize = 15,
                Name = beds[i].BedId,
                Background = color,
                Margin=new Thickness(5)
            };

            newBed.MouseEnter += new MouseEventHandler(MouseOverBed);
            newBed.MouseLeave += new MouseEventHandler(MouseLeaveBed);
            return newBed;
        }

        private void MouseOverBed(object sender, RoutedEventArgs e)
       {
            var btn = sender as Button;
            var bedId = btn.Name.ToString();
            
            StackPanel innerStackPanel = new StackPanel();

            Thickness margin = new Thickness(3);
            TextBlock IdTextBlock = new TextBlock()
            {
                Text = bedId,
                Margin = margin
            };
            
            string option = "";
            var bed = beds.ToList().Find(b => b.BedId == bedId);
            if (bed.BedOccupancyStatus == "Free")
                option = "Add Patient";
            else
                option = "Discharge Patient";

            Button optionButton = new Button()
            {
                Content = option,
                Name = bedId,
                Margin = margin
            };

            optionButton.Click += AddOrRemovePatient;

            innerStackPanel.Children.Add(IdTextBlock);
            if (bed.BedOccupancyStatus == "Occupied")
            {
                TextBlock NameTextBlock = new TextBlock()
                {
                    Text = "Name: " + patients.Find(patient => patient.BedId == bedId).Name,
                    Margin = margin
                };
                innerStackPanel.Children.Add(NameTextBlock);

            }
            innerStackPanel.Children.Add(optionButton);
            btn.Content = innerStackPanel;
       }

        private void MouseLeaveBed(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var bedId = btn.Name.ToString();
            btn.Content = bedId;
        }


        private void AddOrRemovePatient(Object sender, RoutedEventArgs e )
        {
            var btn = sender as Button;
            //MessageBox.Show(btn.Name); // BedId
            if (btn.Content.ToString() == "Add Patient")
            {
                
                Application.Current.MainWindow.Content = new AddNewPatient(icuId.Text.ToString(),btn.Name.ToString());
            }
            else
            {
                var result = new PatientApiCalls().RemovePatient(patients.Find(patient => patient.BedId == btn.Name).PatientId);
                MessageBox.Show(result);
                Application.Current.MainWindow.Content = new MainPage();
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if(MenuOptions.Visibility == Visibility.Collapsed)
                MenuOptions.Visibility = Visibility.Visible;
            else if (MenuOptions.Visibility == Visibility.Visible)
                MenuOptions.Visibility = Visibility.Collapsed;

        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
           if (ViewAllOptions.Visibility == Visibility.Collapsed)
                ViewAllOptions.Visibility = Visibility.Visible;
            else if (ViewAllOptions.Visibility == Visibility.Visible)
                ViewAllOptions.Visibility = Visibility.Collapsed;
        }

        private List<int> LBedLayout(int maxBeds)
        {
            var index = new List<int>();
            index.Add(maxBeds/2);
            index.Add(maxBeds / 2 + maxBeds % 2);
            index.Add(0);
            return index;
        }
        private List<int> UBedLayout(int maxBeds)
        {
            var index = new List<int>();
            //noOfBeds = 16;
            int temp = maxBeds / 3;
            index.Add(temp);
            index.Add(temp + maxBeds % 3);
            index.Add(temp);
            return index;
        }
        private List<int> HBedLayout(int maxBeds)
        {

            var index = new List<int>();
            index.Add(maxBeds / 2 + maxBeds % 2);
            index.Add(0);
            index.Add(maxBeds / 2);
            return index;
        }

        private void Icu_Changed(object sender, SelectionChangedEventArgs e)
        {
            SetUp(this.icuComboBox.SelectedItem.ToString());
        }

        /*public void update_Click(object sender, RoutedEventArgs e)
        {
            var beds = new BedApiCalls().GetAllBedsFromAnIcu("IC1");
            CreateAndPlaceBeds(beds);
            RetrieveIcu();
        }*/
    }
}
