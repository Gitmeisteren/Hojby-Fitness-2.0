using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
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
    /// Interaction logic for MemberJournals.xaml
    /// </summary>
    public partial class MemberJournals : Window
    {
        Controller controller = Controller.GetInstance();
        public MemberJournals()
        {
            InitializeComponent();
            this.DataContext = controller;
        }

        private void Btn_BookSession_Click(object sender, RoutedEventArgs e)
        {
            
            controller.ExportToPDF(cmb_goal.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void chb_TrainingProgram_Checked(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.exorlive.com/dk/login")
            ;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemberOverlayWindow memberOverlayWindow = new MemberOverlayWindow();

            memberOverlayWindow.Show();
            this.Close();
        }
    }
}