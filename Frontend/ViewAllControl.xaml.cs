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
            Application.Current.MainWindow.Content = new AllIcus();
        }

        private void AllBeds_Selected(object sender, RoutedEventArgs e)
        {
           Application.Current.MainWindow.Content = new AllBeds();
        }

        private void AllPatients_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new AllPatients();
        }

        private void BedInICU_Selected(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new BedsInIcu();
        }
    }
}
