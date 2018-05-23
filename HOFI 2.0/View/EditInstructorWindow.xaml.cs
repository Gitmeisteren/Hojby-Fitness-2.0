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
    /// Interaction logic for EditInstructorWindow.xaml
    /// </summary>
    public partial class EditInstructorWindow : Window
    {
        Controller _Controller = Controller.GetInstance();
        public EditInstructorWindow()
        {
            InitializeComponent();
            DataContext = _Controller;
        }

        private void Btn_UpdateEmail_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_NewEmail = tb_NewInstructorEmail.GetBindingExpression(TextBox.TextProperty);

            bind_NewEmail.UpdateSource();
            _Controller.UpdateEmail();

        }

        private void Btn_ReturnInstructorsWindow_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow _InstructorsWindow = new InstructorsWindow();
            _InstructorsWindow.Show();

            this.Close();
        }

        private void Btn_UpdatePhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_EditPhoneNumber = tb_EditPhoneNumber.GetBindingExpression(TextBox.TextProperty);

            bind_EditPhoneNumber.UpdateSource();

            _Controller.UpdatePhoneNumber();
        }
    }
}
