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

namespace Gai.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        int PopitkaVhoda = 0;
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TboxLogin.Text != "" || TboxPassword.Text != "")
            {
                if (TboxLogin.Text == "inspector" && TboxLogin.Text == TboxPassword.Text)
                {
                    MessageBox.Show("Успешный вход");
                    NavigationService.Navigate(new AddVoditelPage());
                }
                else
                {
                    MessageBox.Show("Логин или пароль не правильные");
                    PopitkaVhoda++;
                    if (PopitkaVhoda >= 3)
                    {
                        BtnLogin.IsEnabled = false;
                        for (int i = 60; i >= 0; i--)
                        {
                            BtnLogin.Content = String.Format("Заблокировано {0} секунд", i);
                            await Task.Delay(1000);
                        }
                        BtnLogin.Content = "Войти";
                        BtnLogin.IsEnabled = true;
                    }

                }

            }
            else MessageBox.Show("Логин или пароль не могут быть пустыми");
        }
    }
}
