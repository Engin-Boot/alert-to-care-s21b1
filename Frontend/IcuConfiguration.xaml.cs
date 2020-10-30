using Backend.Models;
using Frontend.ApiCalls;
using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class IcuConfiguration : UserControl
    {
        LayoutModel layoutModel = new LayoutModel();
        IcuApiCalls icuApiObj = new IcuApiCalls();
        int numIcus=0;
            
        public IcuConfiguration()
        {
            InitializeComponent();
            this.DataContext = layoutModel;
            numIcus = icuApiObj.GetAllIcus().Count;
            if(numIcus == 0)
            {
                this.cancelButton.IsEnabled = false ;
            }
        }
        
        private  void NextButton_Click(object sender, RoutedEventArgs e)
        {
            
            var icu = new Backend.Models.IcuModel()
            {
                IcuId = layoutModel.IcuId,
                NoOfBeds = 0,
                Layout = layoutModel.Layout.Substring(0, 1),
                MaxBeds = layoutModel.MaxBeds
            };
            string msg = icuApiObj.AddIcu(icu);
            MessageBox.Show(msg);
            Application.Current.MainWindow.Content = new MainPage();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPage();
        }

        /*private void AddIcu()
        {
            

        }*/
    }
}
