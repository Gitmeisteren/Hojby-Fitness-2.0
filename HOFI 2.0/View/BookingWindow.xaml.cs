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
    public partial class BookingWindow : Window
    {
        Controller _Controller = Controller.GetInstance();
        public BookingWindow()
        {
            InitializeComponent();
            _Controller.UpdateCalendar();
            this.DataContext = _Controller;
        }

        private void Btn_ScheduleSession_Click(object sender, RoutedEventArgs e)
        {
            ScheduleSession _ScheduleSession = new ScheduleSession();
            _ScheduleSession.Show();
            Close();
        }

        private void ButtonReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _MainWindow = new MainWindow();
            _MainWindow.Show();
            this.Close();
            
        }
    }
}
