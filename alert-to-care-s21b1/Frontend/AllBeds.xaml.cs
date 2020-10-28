using Backend.Models;
using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AllBeds.xaml
    /// </summary>
    public partial class AllBeds : UserControl
    {
        private ObservableCollection<BedModel> bedList = new ObservableCollection<BedModel>();
        public AllBeds()
        {
            InitializeComponent();
            RetrieveAndDisplayBeds();
        }

        public void RetrieveAndDisplayBeds()
        {
            bedList = new BedApiCalls().GetAllBeds();
            foreach (var bed in bedList)
            {
                this.BedIDListView.Items.Add(bed.BedId);
            }

        }

        private void BedIDList_Selected(object sender, RoutedEventArgs e)
        {
            int pos = BedIDListView.Items.IndexOf(BedIDListView.SelectedItem.ToString());
            var bed = bedList[pos];
            this.bedId.Text = bed.BedId;
            this.icuId.Text = bed.IcuId;
            this.status.Text = bed.BedOccupancyStatus;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPage();
        }
    }
}
