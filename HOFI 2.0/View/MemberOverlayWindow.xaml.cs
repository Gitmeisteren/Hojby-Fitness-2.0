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
    /// Interaction logic for Members.xaml
    /// </summary>
    public partial class MemberOverlayWindow : Window
    {
        Controller controller = Controller.GetInstance();
        public MemberOverlayWindow()
        {
            InitializeComponent();
            this.DataContext = controller;
        }

        private void Btn_ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();

        }



        public void btn_SeachForMember_Click(object sender, RoutedEventArgs e)
        {
            
            BindingExpression bind_MemberNumber = tb_SearchForMember.GetBindingExpression(TextBox.TextProperty);
            
            bind_MemberNumber.UpdateSource();
            
            controller.SearchForMember();
        }

        private void Btn_OpenmembersJournal_Click(object sender, RoutedEventArgs e)
        {
            MemberJournals memberJournals = new MemberJournals();
            memberJournals.Show();
            this.Close();
        }
    }
}