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
            _Controller.ChangeEmail();

        }

        private void Btn_AdminReturnInstructorsWindow_Click(object sender, RoutedEventArgs e)
        {
            _InstructorsWindow.Show();

            this.Close();
        }

        private void Btn_DeleteInstructor_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_InstructorID = tb_AdminInstructorID.GetBindingExpression(TextBox.TextProperty);

            bind_InstructorID.UpdateSource();
            _Controller.DeleteInstructor();
        }
    }
}
