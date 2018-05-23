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
    /// Interaction logic for AdminEditInstructorWindow.xaml
    /// </summary>
    public partial class AdminEditInstructorWindow : Window
    {
       
        Controller _Controller = Controller.GetInstance();
        InstructorsWindow _InstructorsWindow = new InstructorsWindow();


        public AdminEditInstructorWindow()
        {
            InitializeComponent();
            DataContext = _Controller;
        }

        private void Btn_AdminUpdateEmail_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_NewEmail = tb_AdminNewInstructorEmail.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_InstructorID = tb_AdminInstructorID.GetBindingExpression(TextBox.TextProperty);

            bind_NewEmail.UpdateSource();
            bind_InstructorID.UpdateSource();
            _Controller.UpdateEmail();

        }

        private void Btn_AdminReturnInstructorsWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_AdminDeleteInstructor_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_InstructorID = tb_AdminInstructorID.GetBindingExpression(TextBox.TextProperty);

            bind_InstructorID.UpdateSource();
            ConfirmationWindow _ConfirmationWindow = new ConfirmationWindow();
            _ConfirmationWindow.Show();
        }

        private void Btn_AdminAddInstructor_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_InstructorID = tb_InstructorID.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_InstructorName = tb_InstructorName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_InstuctorEmail = tb_InstructorEmail.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_HireDate = tb_HireDate.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_PhoneNumber = tb_PhoneNumber.GetBindingExpression(TextBox.TextProperty);

            bind_InstructorID.UpdateSource();
            bind_InstructorName.UpdateSource();
            bind_InstuctorEmail.UpdateSource();
            bind_HireDate.UpdateSource();
            bind_PhoneNumber.UpdateSource();

            _Controller.AddInstructor();
        }

        private void Btn_AdminUpdatePhoneNumber(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_MemberNumber = tb_AdminInstructorID.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_AdminEditPhoneNumber = tb_AdminEditPhoneNumber.GetBindingExpression(TextBox.TextProperty);
            

            bind_AdminEditPhoneNumber.UpdateSource();
            bind_MemberNumber.UpdateSource();

            _Controller.UpdatePhoneNumber();
        }
    }
}
