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
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new AddBed());
        }
        private void AddIcuItem_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new IcuConfiguration());
        }
        private void DeleteBedItem_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new DeleteBed());
        }
        private void DeleteIcuItem_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new DeleteIcu());
        }

        private void AddPatientItem_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new AddNewPatient(null,null));
        }
        private void DeletePatientItem_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new DeletePatient());
        }
    }
}
