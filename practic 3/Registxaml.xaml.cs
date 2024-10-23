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

namespace practic_3
{
    /// <summary>
    /// Логика взаимодействия для Registxaml.xaml
    /// </summary>
    public partial class Registxaml : Window
    {
        private AkademeEntities db = new AkademeEntities();
        public Registxaml()
        {
            InitializeComponent();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string username = txtRegister.Text;
            string password = txtRegisterPassword.Password;
            string namee = txtName.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }

            var existingUser = db.Role.FirstOrDefault(u => u.Login == username);

            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким именем уже существует. Попробуйте другое имя пользователя.");
                return;
            }

           Role newUser = new Role
           {
                Login = username,
                Password = password,
                name= namee,
                IdRole =2
            };
            db.Role.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Пользователь успешно зарегистрирован.");
            txtRegister.Text = "";
            txtRegisterPassword.Password = "";
            this.Close();
        }
        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtVisiblePassword.Visibility = Visibility.Visible;
            txtRegisterPassword.Visibility = Visibility.Collapsed;
            txtVisiblePassword.Text = txtRegisterPassword.Password;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtVisiblePassword.Visibility = Visibility.Collapsed;
            txtRegisterPassword.Visibility = Visibility.Visible;
            txtRegisterPassword.Password = txtVisiblePassword.Text;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}