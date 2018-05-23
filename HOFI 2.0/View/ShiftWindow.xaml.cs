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
    /// Interaction logic for ShiftWindow.xaml
    /// </summary>
    public partial class ShiftWindow : Window
    {
        Controller controller = Controller.GetInstance();
        public ShiftWindow()
        {
            InitializeComponent();
            this.DataContext = controller;
        }

        private void Btn_ShowSingleShifts_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_StartDateSingle = Pick_StartDateSingle.GetBindingExpression(DatePicker.TextProperty);
            BindingExpression bind_EndDateSingle = Pick_EndDateSingle.GetBindingExpression(DatePicker.TextProperty);
            BindingExpression bind_InstructorID = Tb_MemberNumber.GetBindingExpression(TextBox.TextProperty);

            bind_InstructorID.UpdateSource();
            bind_StartDateSingle.UpdateSource();
            bind_EndDateSingle.UpdateSource();

            controller.ShowShiftList();
        }

        private void Btn_PrintShifts_Click(object sender, RoutedEventArgs e)
        {
            controller.ExportShiftList();
        }

        private void Btn_ReturnToShiftMenu_Click(object sender, RoutedEventArgs e)
        {

            RegisterShift shiftMenu = new RegisterShift();
            shiftMenu.Show();
            this.Close();
        }

        private void Btn_TestKnap_Click(object sender, RoutedEventArgs e)
        {
            controller.TestStatestik();
        }
    }
}