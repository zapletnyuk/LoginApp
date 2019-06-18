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

namespace LoginApp
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void ExitImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool check = false;
                string login = LoginTBox.Text;
                login = login.Replace(" ", "");
                string password = PasswordBox.Password.ToString();
                password = password.Replace(" ", "");
                if (login == String.Empty)
                    throw new ArgumentException("Empty login string.");
                if (password == String.Empty)
                    throw new ArgumentException("Empty password string.");
                if (PasswordBox.Password.ToString().Length < 8)
                    throw new ArgumentException("Password should be at least 8 characters long.");
                UserContext db = new UserContext();
                foreach(User u in db.Users)
                {
                    if (u.Login == LoginTBox.Text)
                    {
                        check = true;
                        LoginTBox.Text = "";
                        PasswordBox.Password = "";
                        MessageBox.Show("This login already exists.");
                        break;
                    }
                    else if (u.Password == PasswordBox.Password.ToString())
                    {
                        check = true;
                        LoginTBox.Text = "";
                        PasswordBox.Password = "";
                        MessageBox.Show("This password already exists.");
                        break;
                    }
                }
                if (!check)
                {
                    User user = new User { Login = LoginTBox.Text, Password = PasswordBox.Password.ToString() };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("New user is created.");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
