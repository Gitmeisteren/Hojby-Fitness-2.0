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
    /// Interaction logic for Members.xaml
    /// </summary>
    public partial class MemberOverlayWindow : Window
    {
        Controller.Controller _Controller = Controller.Controller.GetInstance();
        public MemberOverlayWindow()
        {
            InitializeComponent();
            this.DataContext = _Controller;
        }




        public void Btn_SeachForMember_Click(object sender, RoutedEventArgs e)
        {
            
            BindingExpression _Bind_MemberNumber = tb_SearchForMember.GetBindingExpression(TextBox.TextProperty);
            
            _Bind_MemberNumber.UpdateSource();
            
            _Controller.SearchForMember();
        }


        private void Btn_ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow _Mainwindow = new MainWindow();
            _Mainwindow.Show();
            this.Close();

        }

        private void Btn_OpenMembersJournal(object sender, RoutedEventArgs e)
        {
            MemberJournals _MemberJournals = new MemberJournals();
            _MemberJournals.Show();
            this.Close();
        }
    }
}