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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string password = "";
        public string memberNumber = "";
        Controller controller = Controller.GetInstance();
        MainWindow mainwindow = new MainWindow();
        public Login()
        {
            InitializeComponent();
            this.DataContext = controller;
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            password = txtBox_Password.Text;
            memberNumber = txtBox_MemberNumber.Text;
            controller.CheckLogin(password, memberNumber);
            if (txtBlock_ErrorMessageBlock.Text == "Godkendt")
            {
                mainwindow.Show();
                this.Close();
            }
        }
    }
}