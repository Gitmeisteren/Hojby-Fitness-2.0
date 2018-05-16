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
        Controller controller = Controller.GetInstance();
        public EditInstructorWindow()
        {
            InitializeComponent();
            DataContext = controller;
        }

        private void Btn_UpdateEmail_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_NewEmail = tb_NewInstructorEmail.GetBindingExpression(TextBox.TextProperty);

            bind_NewEmail.UpdateSource();
            controller.ChangeEmail();

        }

        private void Btn_ReturnInstructorsWindow_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow _InstructorsWindow = new InstructorsWindow();
            _InstructorsWindow.Show();

            this.Close();
        }


    }
}
