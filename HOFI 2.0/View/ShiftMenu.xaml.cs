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
    /// Interaction logic for ShiftMenu.xaml
    /// </summary>
    public partial class ShiftMenu : Window
    {
        public string memberNumber = "";
        public string shiftDate = "";
        Controller controller = Controller.GetInstance();
        MainWindow mainwindow = new MainWindow();
        public ShiftMenu()
        {
            InitializeComponent();
            this.DataContext = controller;
        }

        private void Btn_RegisterShift_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_MemberNumber = Tb_TypeMemberNumber.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_ShiftDate = Tb_TypeShiftDate.GetBindingExpression(TextBox.TextProperty);

            bind_MemberNumber.UpdateSource();
            bind_ShiftDate.UpdateSource();

            controller.RegisterShift(Cmb_ShiftType.Text);
        }

        private void Btn_ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ShiftList_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
