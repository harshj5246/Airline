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
    /// Interaction logic for Flight.xaml
    /// </summary>
    public partial class Flight : Window
    {
        public Flight()
        {
            InitializeComponent();
        }

        private void btn_bookNow_Click(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            this.Visibility = Visibility.Collapsed;
            booking.Show();
        }

        private void btn_dashbord_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard4 = new Dashboard();
            this.Visibility = Visibility.Collapsed;
            dashboard4.Show();
        }
    }
}
