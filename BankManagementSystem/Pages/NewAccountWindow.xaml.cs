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
    /// Interaction logic for NewAccountWindow.xaml
    /// </summary>
    public partial class NewAccountWindow : Window
    {
        public NewAccountWindow()
        {
            InitializeComponent();
            this.DataContext = FormConfig.accountViewModel;
            FormConfig.accountViewModel.IsFormValid = IsFormValid;
        }

        public bool IsFormValid()
        {
            if(txtAcNo.Text.Length != 12)
            {
                txtAcNo.Focus();
                errAc.Visibility = Visibility.Visible;
                errAc.Text = "Account number should have 12 digits ";
                return false;
            }
            else
            {
                errAc.Visibility = Visibility.Hidden;
            }

            if(txtName.Text.Length == 0)
            {
                txtName.Focus();
                errName.Visibility = Visibility.Visible;
                errName.Text = "This field is required";
                return false;
            }
            else
            {
                errName.Visibility = Visibility.Hidden;
            }

            if (rdbCurrent.IsChecked == true || rdbSavings.IsChecked == true)
            {
                errType.Visibility = Visibility.Hidden;
            }
            else
            {
                
                rdbCurrent.Focus();
                errType.Visibility = Visibility.Visible;
                errType.Text = "Please select a type";
                return false;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                txtEmail.Focus();
                errEmail.Visibility = Visibility.Visible;
                errEmail.Text = "Invalid email";
                return false;
            }
            else
            {
                errEmail.Visibility = Visibility.Hidden;
            }

            if(txtPhone.Text.Length != 10)
            {
                txtPhone.Focus();
                errPhone.Visibility = Visibility.Visible;
                errPhone.Text = "Invalid phone number";
                return false;
            }
            else
            {
                errPhone.Visibility = Visibility.Hidden;
            }

            if(txtAddress.Text.Length == 0)
            {
                txtAddress.Focus();
                errAddress.Visibility = Visibility.Visible;
                errAddress.Text = "This field is required";
                return false;
            }
            else
            {
                errAddress.Visibility = Visibility.Hidden;
            }
            
            return true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void WindowClose()
        {
            this.Hide();
        }
    }
}
