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
    /// Interaction logic for BedsInIcu.xaml
    /// </summary>
    public partial class BedsInIcu : UserControl
    {
        ObservableCollection<string> _icuList = new ObservableCollection<string>();
        ObservableCollection<string> _bedIdList = new ObservableCollection<string>();
        ObservableCollection<BedModel> _bedList = new ObservableCollection<BedModel>();

        public BedsInIcu()
        {
            InitializeComponent();
            _icuList = RetrieveIcus();
            this.DataContext = this;

        }
        public ObservableCollection<string> RetrieveIcus()
        {
            var icus = new IcuApiCalls().GetAllIcus();
            foreach (var icu in icus)
            {
                this.IcuList.Add(icu.IcuId);
            }
            return this.IcuList;
        }

        public ObservableCollection<string> RetrieveBeds()
        {
            this.BedIdList.Clear();
            
            _bedList = new BedApiCalls().GetAllBedsFromAnIcu(this.icuList.SelectedItem.ToString());
            foreach (var bed in _bedList)
            {
                this.BedIdList.Add(bed.BedId);
            }
            return this.BedIdList;

        }

        public ObservableCollection<string> IcuList
        {
            get { return this._icuList; }
            set { this._icuList = value; }
        }

        public ObservableCollection<string> BedIdList
        {
            get { return this._bedIdList; }
            set { this._bedIdList = value; }
        }

        private void icuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RetrieveBeds();
        }

        private void bedIdList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.bedIdList.SelectedItem == null)
                return;
            string selectedBedID = this.bedIdList.SelectedItem.ToString();
            var bed = _bedList.ToList().Find(bed => bed.BedId == selectedBedID);
            
            this.bedId.Text = bed.BedId;
            this.icuId.Text = bed.IcuId;
            this.status.Text = bed.BedOccupancyStatus;
            
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
    }
}
