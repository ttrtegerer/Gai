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
    /// Логика взаимодействия для InfoOfVoditelPage.xaml
    /// </summary>
    public partial class InfoOfVoditelPage : Page
    {
        public string PhotoSoures = "";
        public InfoOfVoditelPage()
        {
            InitializeComponent();
            TboxCod.IsEnabled = false;
            TboxCatLichec.IsEnabled = false;
            TboxSeriaLichec.IsEnabled = false;
            TboxNumberLichec.IsEnabled = false;
            TboxDateStart.IsEnabled = false;
            TboxDateEnd.IsEnabled = false;
            CboxVoditel.ItemsSource = App.Context.drivers.ToList();
        }

        private void BtnAddVoditel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddVoditelPage());
        }

        private void BtnEditImage_Click(object sender, RoutedEventArgs e)
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
                    MessageBox.Show(PhotoSoures);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnEditVoditel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Entitis.drivers Driver = (Entitis.drivers)CboxVoditel.SelectedItem;
                var ErrorMessage = CheckErrors();
                if (CboxVoditel.SelectedItem == null)
                {
                    MessageBox.Show("Выберите водителя для редактирования");
                }
            else { 
                   
                if (ErrorMessage.Length > 1)
                {
                    MessageBox.Show(ErrorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    {
                        Driver.Sername = TboxSername.Text;
                        Driver.Name = TboxName.Text;
                        Driver.Middlename = TboxOtchestvo.Text;
                        Driver.PasportSeria = Convert.ToInt32(TboxSPasport.Text);
                        Driver.PasportNumber = Convert.ToInt32(TboxNPasport.Text);
                        Driver.Address = TboxAdresReg.Text;
                        Driver.AddresLife = TboxAdresProzi.Text;
                        Driver.Company = TboxAdresJob.Text;
                        Driver.Jobname = TboxJobLevel.Text;
                        Driver.Phone = TboxPhone.Text;
                        Driver.Email = TboxPochta.Text;
                        Driver.Photo = PhotoSoures.ToString();
                        Driver.Description = TboxDescription.Text;
                    
                    App.Context.SaveChanges();
                    MessageBox.Show("Водитель успешно редактирован");
                    CboxVoditel.SelectedItem = null;
                    CboxVoditel.ItemsSource = App.Context.drivers.ToList();
                    }  
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

        private void CboxVoditel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CboxVoditel.SelectedItem != null)
            {
               Entitis.drivers Driver = (Entitis.drivers)CboxVoditel.SelectedItem;
                TboxCod.Text = Driver.Id.ToString();
                TboxName.Text = Driver.Name;
                TboxSername.Text = Driver.Sername;
                TboxOtchestvo.Text = Driver.Middlename;
                TboxSPasport.Text = Driver.PasportSeria.ToString();
                TboxNPasport.Text = Driver.PasportNumber.ToString();
                TboxAdresReg.Text = Driver.Address;
                TboxAdresProzi.Text = Driver.AddresLife;
                TboxAdresJob.Text = Driver.Company;
                TboxJobLevel.Text = Driver.Jobname;
                TboxPhone.Text = Driver.Phone;
                TboxPochta.Text = Driver.Email;
                TboxDescription.Text = Driver.Description;
                
                Photo.Source= new BitmapImage(new Uri("Photo\\" + Driver.Photo, UriKind.Relative));
                PhotoSoures = Driver.Photo;
                Entitis.licence DriverLinse =(Entitis.licence)Driver.Gai_licence.Where(p => p.Driverid == Driver.Id).LastOrDefault();
                if (DriverLinse != null)
                {
                    TboxSeriaLichec.Text = Convert.ToString(DriverLinse.LicenceSeries);
                    TboxNumberLichec.Text = Convert.ToString(DriverLinse.LicenceNumber);
                    TboxDateStart.Text = Convert.ToString(DriverLinse.LicenceDate);
                    TboxDateEnd.Text = Convert.ToString(DriverLinse.ExpireDate);
                    TboxCatLichec.Text = DriverLinse.Gai_categories.Name.ToString();
                }
                else
                {
                    TboxSeriaLichec.Text = null;
                    TboxNumberLichec.Text = null;
                    TboxDateStart.Text = null;
                    TboxDateEnd.Text = null;
                    TboxCatLichec.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Выберите водителя");
            }
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
