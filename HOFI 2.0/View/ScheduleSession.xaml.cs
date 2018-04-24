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
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for ScheduleSession.xaml
    /// </summary>
    public partial class ScheduleSession : Window
    {
        Controller controller = new Controller();
        public ScheduleSession()
        {
            InitializeComponent();
        }
        
        public string tb_TypeMemberNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string memberNumber;
            memberNumber = tb_TypeMemberNumber.Text;
            return memberNumber;
        }

        private string tb_TypeBookingDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            string bookingDate;
            bookingDate = tb_TypeBookingDate.Text;
            return bookingDate;
        }

        private void btn_AppointSession_Click(object sender, RoutedEventArgs e)
        {
          
            
        }
    }
}
