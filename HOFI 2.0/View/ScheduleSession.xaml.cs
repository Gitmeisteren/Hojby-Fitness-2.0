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
            this.DataContext = controller;
        }
        

        private void btn_AppointSession_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_MemberNumber = tb_TypeMemberNumber.GetBindingExpression(TextBox.TextProperty);

            BindingExpression bind_BookingDate = tb_TypeBookingDate.GetBindingExpression(TextBox.TextProperty);

            bind_MemberNumber.UpdateSource();
            bind_BookingDate.UpdateSource();

            controller.ScheduleSession();

            
            
        }
    }
}
