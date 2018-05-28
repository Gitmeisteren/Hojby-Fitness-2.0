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
using Controller;

namespace View
{
    /// <summary>
    /// Interaction logic for InstructorsWindow.xaml
    /// </summary>
    public partial class InstructorsWindow : Window
    {
        Controller.Controller _Controller = Controller.Controller.GetInstance();
        public InstructorsWindow()
        {
            InitializeComponent();
            DataContext = _Controller;
            _Controller.ShowInstructors();

        }



        private void Btn_ReturntoMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _MainWindow = new MainWindow();

            _MainWindow.Show();
            this.Close();
        }


        private void Btn_EditInstructor_Click(object sender, RoutedEventArgs e)
        {
            EditInstructorWindow _EditInstructorWindow = new EditInstructorWindow();
            AdminEditInstructorWindow _AdminEditInstructorWindow = new AdminEditInstructorWindow();

            if(_Controller.LoginCredentials == "hofi353")
            {
                _AdminEditInstructorWindow.Show();
                
            }
            else
            {
            _EditInstructorWindow.Show();
                this.Close();
            }
            
        }

    }
}
