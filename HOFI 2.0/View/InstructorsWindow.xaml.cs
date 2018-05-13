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
    /// Interaction logic for InstructorsWindow.xaml
    /// </summary>
    public partial class InstructorsWindow : Window
    {
        Controller controller = Controller.GetInstance();
        public InstructorsWindow()
        {
            InitializeComponent();
            DataContext = controller;
            controller.ShowInstructors();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            mainWindow.Show();
            this.Close();
        }

        private void AddInstructor_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_InstructorID   = tb_InstructorID.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_InstructorName = tb_InstructorName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_InstuctorEmail = tb_InstructorEmail.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_HireDate       = tb_HireDate.GetBindingExpression(TextBox.TextProperty);

            bind_InstructorID.UpdateSource();
            bind_InstructorName.UpdateSource();
            bind_InstuctorEmail.UpdateSource();
            bind_HireDate.UpdateSource();

            controller.AddInstructor();
        }

        private void Btn_EditInstructor_Click(object sender, RoutedEventArgs e)
        {
            EditInstructorWindow editInstructorWindow = new EditInstructorWindow();
            editInstructorWindow.Show();

            this.Close();
        }
    }
}
