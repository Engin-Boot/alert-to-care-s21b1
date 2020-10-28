using Frontend.ViewModel;
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

namespace Frontend
{
    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        public MenuControl()
        {
            InitializeComponent();
        }

        private void AddBedItem_Selected(object sender, RoutedEventArgs e)
        {
            
            Application.Current.MainWindow.Content = new AddBed();
            //this.Content = addIcu;
        }
        private void AddIcuItem_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new IcuConfiguration();
        }
        private void DeleteBedItem_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new DeleteBed();
        }
        private void DeleteIcuItem_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new DeleteIcu();
        }

        private void AddPatientItem_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AddNewPatient(null,null);
        }
        private void DeletePatientItem_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new DeletePatient();
        }
    }
}
