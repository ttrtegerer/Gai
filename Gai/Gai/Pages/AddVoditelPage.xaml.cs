using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddVoditelPage.xaml
    /// </summary>
    public partial class AddVoditelPage : Page
    {
        public string PhotoSoures = "";
        public AddVoditelPage()
        {
            InitializeComponent();
            TboxCod.Text = (App.Context.drivers.Max(p => p.Id) + 1).ToString();
            TboxCod.IsEnabled = false;
        }

        private void BtnAddImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog Ofd = new OpenFileDialog();
                Ofd.Filter = "Image |*.png; *.jpg; *.jpeg";
                if (Ofd.ShowDialog() == true)
                {
                    var MainImageData = File.ReadAllBytes(Ofd.FileName);
                    Photo.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(MainImageData);
                    int IndexOfSubstring = Ofd.FileName.IndexOf("Photo") + 6;
                    PhotoSoures = Ofd.FileName.Substring(IndexOfSubstring);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnAddVoditel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ErrorMessage = CheckErrors();
                if (ErrorMessage.Length > 1)
                {
                    MessageBox.Show(ErrorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Entitis.drivers Driver = new Entitis.drivers
                    {
                        Sername = TboxSername.Text,
                        Name = TboxName.Text,
                        Middlename = TboxOtchestvo.Text,
                        PasportSeria = Convert.ToInt32(TboxSPasport.Text),
                        PasportNumber = Convert.ToInt32(TboxNPasport.Text),
                        Address = TboxAdresReg.Text,
                        AddresLife = TboxAdresProzi.Text,
                        Company = TboxAdresJob.Text,
                        Jobname = TboxJobLevel.Text,
                        Phone = TboxPhone.Text,
                        Email = TboxPochta.Text,
                        Photo = PhotoSoures.ToString(),
                        Description = TboxDescription.Text
                    };
                    App.Context.drivers.Add(Driver);
                    App.Context.SaveChanges();
                    MessageBox.Show("Водитель успешно добавлен");
                    TboxCod.Text = (App.Context.drivers.Max(p => p.Id) + 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private string CheckErrors()
        {
            var ErrorBuilder = new StringBuilder();
            if (TboxName.Text == "" || !Regex.IsMatch(TboxName.Text, @"^[А-Яа-я]|\s+$")) ErrorBuilder.AppendLine("Имя обязательно для заполнения и содержит только буквы;");
            if (TboxSername.Text == "" || !Regex.IsMatch(TboxSername.Text, @"^[А-Яа-я]|\s+$")) ErrorBuilder.AppendLine("Фамилия обязательна для заполнения и содержит только буквы;");
            if (TboxOtchestvo.Text == "" || !Regex.IsMatch(TboxOtchestvo.Text, @"^[А-Яа-я]|\s+$")) ErrorBuilder.AppendLine("Отчество обязательно для заполнения и содержит только буквы;");
            if (TboxSPasport.Text == "" || !Regex.IsMatch(TboxSPasport.Text, @"^[0-9]+$")) ErrorBuilder.AppendLine("Поле паспорт серия должена быть заполнена в нужном формате и не может быть пустым;");
            if (TboxNPasport.Text == "" || !Regex.IsMatch(TboxNPasport.Text, @"^[0-9]+$")) ErrorBuilder.AppendLine("Поле паспорт номер должен быть заполнен в нужном формате и не может быть пустым;");
            if (TboxAdresReg.Text == "") ErrorBuilder.AppendLine("Поле адрес регистрации не может быть пустым;");
            if (TboxAdresProzi.Text == "") ErrorBuilder.AppendLine("Поле адрес проживания не может быть пустым;");
            if (TboxPhone.Text == "" || !Regex.IsMatch(TboxPhone.Text, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{6,7}$")) ErrorBuilder.AppendLine("Телефон должен быть заполнен в нужном формате и не может быть пустым;");
            if (TboxPochta.Text == "" || !Regex.IsMatch(TboxPochta.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")) ErrorBuilder.AppendLine("Почта должна быть заполнена в нужном формате и не может быть пустой;");
            if (PhotoSoures == null) ErrorBuilder.AppendLine("Фотографию нужно обязательно добавить;");
            return ErrorBuilder.ToString();
        }

        private void BtnEditVoditel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.InfoOfVoditelPage());
        }

        private void BtnAddLichec_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddLichec());
        }

        private void BtnViewLichec_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.LichesPage());
        }
    }
}
