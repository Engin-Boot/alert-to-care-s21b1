using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Frontend.ApiCalls;
using System.ComponentModel;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for DeleteIcu.xaml
    /// </summary>
    public partial class DeleteIcu : UserControl, INotifyPropertyChanged
    {
        string icuId;
        ObservableCollection<string> _icuList = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public DeleteIcu()
        {
            InitializeComponent();
            _icuList = RetrieveIcus();
            this.DataContext = this;

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
        public ObservableCollection<string> IcuList
        {
            get { return this._icuList; }
            set { this._icuList = value; }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var icuId = IcuId;
            var result = new IcuApiCalls().RemoveIcu(icuId);
            MessageBox.Show(result);
            if(result == "ICU deleted successfully")
            {
                if(_icuList.Count == 1)
                { 
                    var window = Application.Current.MainWindow;
                    var leftside = window.FindName("LeftSide") as DockPanel;
                    leftside.Children.Clear();
                    leftside.Children.Add(new IcuConfiguration());
                }
                else
                {
                    LoadMainPage();
                }
            }
            
            
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}
