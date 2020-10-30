using Backend.Models;
using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
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
    /// Interaction logic for AddBed.xaml
    /// </summary>
    public partial class AddBed : UserControl, INotifyPropertyChanged
    {
        ObservableCollection<string> _icuList = new ObservableCollection<string>();
        public event PropertyChangedEventHandler PropertyChanged;

        string icuId;
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
        string result = "";


        public AddBed()
        {
            InitializeComponent();
            _icuList = RetrieveIcus();
            this.DataContext = this;

        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ObservableCollection<string> RetrieveIcus()
        {
            var icus =new IcuApiCalls().GetAllIcus();
            foreach(var icu in icus)
            {
                this.IcuList.Add(icu.IcuId);
            }
            return this.IcuList;
        }
        public ObservableCollection<string> IcuList
        {
            get { return this._icuList; }
            set { this._icuList = value; }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var icuId = this.IcuId;
            result = new BedApiCalls().AddBed(icuId);
            MessageBox.Show(result);
            LoadMainPage();
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
