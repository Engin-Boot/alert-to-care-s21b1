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
    /// Interaction logic for ViewAllControl.xaml
    /// </summary>
    public partial class ViewAllControl : UserControl
    {
        public ViewAllControl()
        {
            InitializeComponent();
        }

        private void AllICUs_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new AllIcus());
        }

        private void AllBeds_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new AllBeds());
        }

        private void AllPatients_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new AllPatients());
        }

        private void BedInICU_Selected(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow;
            var leftside = window.FindName("LeftSide") as DockPanel;
            leftside.Children.Clear();
            leftside.Children.Add(new BedsInIcu());
        }
    }
}
