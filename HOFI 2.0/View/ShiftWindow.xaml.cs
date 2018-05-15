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
            BindingExpression bind_StartDateSingle = Tb_StartDateSingle.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_EndDateSingle = Tb_EndDateSingle.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_InstructorID = Tb_MemberNumber.GetBindingExpression(TextBox.TextProperty);

            bind_InstructorID.UpdateSource();
            bind_StartDateSingle.UpdateSource();
            bind_EndDateSingle.UpdateSource();

            controller.ShowSingleShiftList();
        }

        private void Btn_ShowAllShifts_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_StartDateAll = Tb_StartDateAll.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_EndDateAll = Tb_EndDateAll.GetBindingExpression(TextBox.TextProperty);

            bind_StartDateAll.UpdateSource();
            bind_EndDateAll.UpdateSource();

            controller.ShowAllShiftList();
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