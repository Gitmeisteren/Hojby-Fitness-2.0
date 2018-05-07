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
            controller.ExportToPDF();
        }
    }
}