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
    /// Interaction logic for AdminRegisterShift.xaml
    /// </summary>
    public partial class AdminRegisterShift : Window
    {
        Controller _Controller = Controller.GetInstance();
        public AdminRegisterShift()
        {
            InitializeComponent();
            DataContext = _Controller;
        }

        private void Btn_AdminReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _Mainwindow = new MainWindow();
            _Mainwindow.Show();
            this.Close();
        }

        private void Btn_AdminShiftList_Click(object sender, RoutedEventArgs e)
        {
            ShiftWindow _ShiftWindow = new ShiftWindow();
            _ShiftWindow.Show();
            this.Close();
        }

        private void Btn_AdminRegisterShift_Click(object sender, RoutedEventArgs e)
        {
            

            BindingExpression _Bind_MemberNumber = Tb_AdminTypeMemberNumber.GetBindingExpression(TextBox.TextProperty);
            BindingExpression _Bind_ShiftDate = Pick_AdminShiftDate.GetBindingExpression(DatePicker.TextProperty);


            _Bind_MemberNumber.UpdateSource();
            _Bind_ShiftDate.UpdateSource();

            _Controller.RegisterShift(Cmb_ShiftType.Text);
        }
    }
}
