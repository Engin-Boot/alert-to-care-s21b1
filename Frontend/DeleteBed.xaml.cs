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
    /// Interaction logic for DeleteBed.xaml
    /// </summary>
    public partial class DeleteBed : UserControl, INotifyPropertyChanged
    {
        ObservableCollection<string> _icuList = new ObservableCollection<string>();
        ObservableCollection<string> _bedList = new ObservableCollection<string>();
        string icuId;
        string bedId;

        public event PropertyChangedEventHandler PropertyChanged;

        public DeleteBed()
        {
            InitializeComponent();
            _icuList = RetrieveIcus();
            this.DataContext = this;

        }
        public string BedId
        {
            get { return this.bedId; }
            set
            {
                if (this.bedId != value)
                {
                    this.bedId = value;
                    OnPropertyChanged(nameof(BedId));
                }
            }
        }
        public string IcuId
        {
            get { return this.icuId; }
            set
            {
                if (this.icuId != value)
                {
                    this.icuId = value;
                    OnPropertyChanged(nameof(IcuId));
                }
            }
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
            this.BedList.Clear();
            
            var beds = new BedApiCalls().GetAllBedsFromAnIcu(this.icuList.SelectedItem.ToString());
            foreach(var bed in beds)
            {
                this.BedList.Add(bed.BedId);
            }
            return this.BedList;

        }

        public ObservableCollection<string> IcuList
        {
            get { return this._icuList; }
            set { this._icuList = value; }
        }

        public ObservableCollection<string> BedList
        {
            get { return this._bedList; }
            set { this._bedList = value; }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var icuId = IcuId;
            var bedId = BedId;
            var result = new BedApiCalls().RemoveBed(icuId,bedId);
            MessageBox.Show(result);
            Application.Current.MainWindow.Content = new MainPage();
        }

        
        private void icuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RetrieveBeds();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPage();
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
