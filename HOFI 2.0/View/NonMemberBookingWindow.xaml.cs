﻿using System;
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
    /// Interaction logic for NonMemberBookingWindow.xaml
    /// </summary>
    public partial class NonMemberBookingWindow : Window
    {
        Controller.Controller _Controller = Controller.Controller.GetInstance();
        public NonMemberBookingWindow()
        {
            InitializeComponent();
            DataContext = _Controller;
        }

        private void Btn_CreateNonMember_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_NonMemberName = tb_NonMemberName.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bind_NonMemberPhoneNumber = tb_NonMemberPhoneNumber.GetBindingExpression(TextBox.TextProperty);

            bind_NonMemberName.UpdateSource();
            bind_NonMemberPhoneNumber.UpdateSource();

            _Controller.CreateNonMember();
        }

        private void Btn_RegisterNonMemberBooking_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression bind_NonMemberPhoneNumber = tb_RegisterNonMemberPhoneNumber.GetBindingExpression(TextBox.TextProperty);
            bind_NonMemberPhoneNumber.UpdateSource();

            _Controller.RegisterNonMemberBooking();
        }

        private void Btn_ReturnBookingWindow_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow _bookingWindow = new BookingWindow();
            _bookingWindow.Show();

            this.Close();
        }
    }
}
