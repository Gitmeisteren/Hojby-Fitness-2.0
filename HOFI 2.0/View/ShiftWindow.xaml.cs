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
        string shiftEndDate = "";
        string shiftStartDate = "";
        string memberNumber = "";
        public ShiftWindow()
        {
            InitializeComponent();
            this.DataContext = controller;
        }

        private void Btn_ShowSingleShifts_Click(object sender, RoutedEventArgs e)
        {
            shiftEndDate = Tb_EndDateSingle.Text;///
            shiftStartDate = Tb_StartDateSingle.Text;
            memberNumber = Tb_MemberNumber.Text;
            controller.ShowSingleShiftList(memberNumber, shiftStartDate, shiftEndDate);
        }

        private void Btn_ShowAllShifts_Click(object sender, RoutedEventArgs e)
        {
            shiftEndDate = Tb_EndDateAll.Text;
            shiftStartDate = Tb_StartDateAll.Text;
            controller.ShowAllShiftList(shiftStartDate, shiftEndDate);
        }

        private void Btn_PrintShifts_Click(object sender, RoutedEventArgs e)
        {
            string shiftListContent = TBlock_ShiftList.Text;
            controller.ExportShiftList(shiftListContent);
        }

        private void Btn_ReturnToShiftMenu_Click(object sender, RoutedEventArgs e)
        {

            RegisterShift shiftMenu = new RegisterShift();
            shiftMenu.Show();
            this.Close();
        }
    }
}
