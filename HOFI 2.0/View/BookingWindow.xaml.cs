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
using Controller;

namespace View
{
    /// <summary>
    /// Interaction logic for BookingMenu.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        Controller.Controller _Controller = Controller.Controller.GetInstance();
        public BookingWindow()
        {
            InitializeComponent();
            _Controller.UpdateCalendar();
            this.DataContext = _Controller;
        }

        private void Btn_BookSession_Click(object sender, RoutedEventArgs e)
        {
            BookSession _BookSession = new BookSession();
            _BookSession.Show();
            Close();
        }

        private void ButtonReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _MainWindow = new MainWindow();
            _MainWindow.Show();
            this.Close();
            
        }

        private void Btn_NonMemberBookingWindow_Click(object sender, RoutedEventArgs e)
        {
            NonMemberBookingWindow _NonMemberBookingWindow = new NonMemberBookingWindow();

            _NonMemberBookingWindow.Show();
            this.Close();
        }
    }
}
