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

namespace BankManagementSystem.Pages
{
    /// <summary>
    /// Interaction logic for DashBoardWindow.xaml
    /// </summary>
    public partial class DashBoardWindow : Window
    {
        public DashBoardWindow()
        {
            InitializeComponent();
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            FormConfig.depositWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            FormConfig.accountListWindow.Show();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            FormConfig.withdrawWindow.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
