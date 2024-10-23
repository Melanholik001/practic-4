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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practic_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AkademeEntities db = new AkademeEntities();
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password;
            if (txtPassword.Visibility == Visibility.Visible)
            {
                password = txtPassword.Password;
            }
            else
            {
                password = txtVisiblePassword.Text;
            }

            var user = db.Role.FirstOrDefault(u => u.Login == username && u.Password == password);

            if (user != null)
            {
                switch (user.IdRole)
                {
                    case 1: 
                        Adminxaml adminWindow = new Adminxaml();
                        adminWindow.Show();
                        break;
                    default: 
                        Userxaml userWindow = new Userxaml();
                        userWindow.Show();
                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtVisiblePassword.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
            txtVisiblePassword.Text = txtPassword.Password;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtVisiblePassword.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Visible;
            txtPassword.Password = txtVisiblePassword.Text;
        }

        private void regust_Click(object sender, RoutedEventArgs e)
        {
            Registxaml userWindow = new Registxaml();
            userWindow.Show();
        }
    }
}