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
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = Controller.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_BookingMenu_Click(object sender, RoutedEventArgs e)
        {
            BookingMenu bookingMenu = new BookingMenu();
            bookingMenu.Show();
            this.Close();
        }

        private void Btn_MembersWindow_Click(object sender, RoutedEventArgs e)
        {
            MemberOverlayWindow members = new MemberOverlayWindow();
            members.Show();
            this.Close();
        }

        private void Btn_ShiftMenu_Click(object sender, RoutedEventArgs e)
        {
            RegisterShiftWindow shiftMenu = new RegisterShiftWindow();
            shiftMenu.Show();
            this.Close();
        }

        private void Btn_InstructorsWindow_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow instructorsWindow = new InstructorsWindow();
            instructorsWindow.Show();
            this.Close();
        }
    }
}
