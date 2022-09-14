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
using System.Windows.Shapes;

namespace Airlines_App
{
    /// <summary>
    /// Interaction logic for FlightList.xaml
    /// </summary>
    public partial class FlightList : Window
    {
        public FlightList()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            Flight flight = new Flight();
            this.Visibility = Visibility.Collapsed;
            flight.Show();
        }

        private void btn_dashbord_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard3 = new Dashboard();
            this.Visibility = Visibility.Collapsed;
            dashboard3.Show();
        }
    }
}
