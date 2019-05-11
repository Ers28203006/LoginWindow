using LoginWindow.DataAccess;
using LoginWindow.Models;
using LoginWindow.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LoginWindow.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        User user = new User();

        private void AuthorizationButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            int choice = 0;
            using (var context = new UsersContext())
            {
                List<User> users = context.Users.ToList();
                foreach (var u in users)
                {
                    if (u.Login == login)
                    {
                        user = u;
                        ++choice;
                        break;
                    }
                }

                if (choice == 0) MessageBox.Show("Зарегистрируйтесь, такой логин в базе отсутствует");

                else
                {
                    if (DataEncryptor.IsValidPassword(password, user.Password))
                    {
                        MessageBox.Show("Добро пожаловать в систему!");
                        Close();
                    }

                    else
                    {
                        MessageBox.Show("Не верно введен пароль");
                        loginTextBox.Clear();
                        passwordTextBox.Clear();
                    }
                }
            }
        }
        private void RegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            using (var context = new UsersContext())
            {
                List<User> users = context.Users.ToList();
                int choce = 0;

                foreach (var u in users)
                    if (u.Login == login)
                    {
                        MessageBox.Show("Логин существует, авторизуйтесь");
                        ++choce;
                        break;
                    }

                if (choce == 0)
                {
                    context.Users.Add
                    (
                        new User
                        {
                            Login = login,
                            Password = DataEncryptor.HashPassword(password)
                        }
                    );
                    context.SaveChanges();
                    MessageBox.Show("Логин успешно зарегистрирован!");
                    loginTextBox.Clear();
                    passwordTextBox.Clear();
                }
            }
        }
    }
}
