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
    /// Interaction logic for AllIcus.xaml
    /// </summary>
    public partial class AllIcus : UserControl
    {
        private ObservableCollection<IcuModel> icuList = new ObservableCollection<IcuModel>();
        public AllIcus()
        {
            InitializeComponent();
            RetrieveAndDisplayIcus();
        }

        public void RetrieveAndDisplayIcus()
        {
            icuList = new IcuApiCalls().GetAllIcus();
            foreach (var icu in icuList)
            {
                this.IcuIDListView.Items.Add(icu.IcuId);
            }
            
        }

        private void IcuIDList_Selected(object sender, RoutedEventArgs e)
        {
            int pos = IcuIDListView.Items.IndexOf(IcuIDListView.SelectedItem.ToString());
            var icu = icuList[pos];
            this.icuId.Text = icu.IcuId;
            this.layout.Text = icu.Layout;
            this.maxBeds.Text = icu.MaxBeds.ToString();
            this.bedsPresent.Text = icu.NoOfBeds.ToString();

            List<Backend.Models.BedModel> beds = new BedApiCalls().GetAllBedsFromAnIcu(icu.IcuId).ToList();
            this.freeBeds.Text = beds.FindAll(bed => bed.BedOccupancyStatus == "Free").Count.ToString();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new MainPage());
        }
    }
}
