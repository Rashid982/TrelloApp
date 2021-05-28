using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trello.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Visibility == Visibility.Visible)
            {
                PasswordUnmask.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Hidden;
                PasswordUnmask.Text = txtPassword.Password;
            }
            else
            {
                PasswordUnmask.Visibility = Visibility.Hidden;
                txtPassword.Visibility = Visibility.Visible;                
            }            
        }
    }
}
