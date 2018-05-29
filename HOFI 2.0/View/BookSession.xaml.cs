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
    /// Interaction logic for ScheduleSession.xaml
    /// </summary>
    public partial class BookSession : Window
    {
        Controller.Controller _Controller = Controller.Controller.GetInstance();
        public BookSession()
        {
            InitializeComponent();
            this.DataContext = _Controller;
            
        }
        

        private void Btn_ScheduleSession_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression _Bind_MemberNumber = tb_TypeMemberNumber.GetBindingExpression(TextBox.TextProperty);
            BindingExpression _Bind_BookingDate = Pick_BookingDate.GetBindingExpression(DatePicker.TextProperty);

            _Bind_MemberNumber.UpdateSource();
            _Bind_BookingDate.UpdateSource();

            _Controller.BookSession();
            
        }

        private void Btn_CreateMember_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression _Bind_MemberNumber = tb_CreateMemberNumber.GetBindingExpression(TextBox.TextProperty);
            BindingExpression _Bind_Name = tb_CreateName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression _Bind_PhoneNumber = tb_CreatePhoneNumber.GetBindingExpression(TextBox.TextProperty);
            BindingExpression _Bind_Email = tb_CreateEmail.GetBindingExpression(TextBox.TextProperty);
            BindingExpression _Bind_Age = tb_CreateAge.GetBindingExpression(TextBox.TextProperty);

            _Bind_MemberNumber.UpdateSource();
            _Bind_Name.UpdateSource();
            _Bind_PhoneNumber.UpdateSource();
            _Bind_Email.UpdateSource();
            _Bind_Age.UpdateSource();

            _Controller.CreateNewMember();

        }

        private void Btn_ReturnToBookingMenu_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow _BookingMenu = new BookingWindow();
            _BookingMenu.Show();
            this.Close();
        }
    }
}
