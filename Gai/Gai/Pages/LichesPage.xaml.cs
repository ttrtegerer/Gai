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
    /// Логика взаимодействия для LichesPage.xaml
    /// </summary>
    public partial class LichesPage : Page
    {
        public LichesPage()
        {
            InitializeComponent();
            LvLiches.ItemsSource = App.Context.licence.ToList();
        }

        private void BtnAddVoditel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddVoditelPage());
        }

        private void BtnAddLichec_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddLichec());

        }

        private void BtnEditVoditel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.InfoOfVoditelPage());
        }
    }
}
