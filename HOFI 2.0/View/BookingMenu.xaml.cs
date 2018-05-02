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
    /// Interaction logic for BookingMenu.xaml
    /// </summary>
    public partial class BookingMenu : Window
    {
        Controller controller = Controller.GetInstance();
        public BookingMenu()
        {
            InitializeComponent();
            controller.UpdateCalendar();
        }

        private void btn_ScheduleSession_Click(object sender, RoutedEventArgs e) //Book træningsforløb
        {
            ScheduleSession scheduleSession = new ScheduleSession();
            scheduleSession.Show();
            this.Close();
        }

        private void ButtonReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
            
        }
    }
}
