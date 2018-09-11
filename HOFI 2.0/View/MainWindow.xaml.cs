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
using Controller;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller.Controller _Controller = Controller.Controller.GetInstance();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_BookingMenu_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow _BookingMenu = new BookingWindow();
            _BookingMenu.Show();
            this.Close();
        }

        private void Btn_MembersWindow_Click(object sender, RoutedEventArgs e)
        {
            MemberOverlayWindow _Members = new MemberOverlayWindow();
            _Members.Show();
            this.Close();
        }

        private void Btn_ShiftWindow_Click(object sender, RoutedEventArgs e)
        {

            if(_Controller.LoginCredentials == "hofi353" || _Controller.LoginCredentials == "hofi0")
            {
                AdminRegisterShift _AdminRegisterShift = new AdminRegisterShift();
                _AdminRegisterShift.Show();
                this.Close();
            }
            else
            {
            RegisterShift _ShiftWindow = new RegisterShift();
            _ShiftWindow.Show();
            this.Close();
            }

        }

        private void Btn_InstructorsWindow_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow _InstructorsWindow = new InstructorsWindow();
            _InstructorsWindow.Show();
            this.Close();
        }

        private void Btn_InstructorsMenu_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow instructorsWindow = new InstructorsWindow();

            instructorsWindow.Show();
            this.Close();

        }

        private void Btn_LogOff_Click(object sender, RoutedEventArgs e)
        {
            Login _LoginWindow = new Login();

            _LoginWindow.Show();
            _Controller.ResetLoginCredentials();
            this.Close();
        }
    }
}
