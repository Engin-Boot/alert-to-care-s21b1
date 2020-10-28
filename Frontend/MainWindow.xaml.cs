using Frontend.ApiCalls;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var count = new IcuApiCalls().GetAllIcus().Count();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (count == 0)
                this.Content = new IcuConfiguration();
            else
                this.Content = new MainPage();


        }
    }
}
