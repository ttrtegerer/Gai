using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GaiMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDtpPage : ContentPage
    {
        string connectionString = @"Data Source=stud-mssql.sttec.yar.ru,38325;Database=user79_db;" + "User ID=user79_db;Password=user79;Connect Timeout=30;" + "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" + "MultiSubnetFailover=False";
        SqlConnection connection;
        public AddDtpPage()
        {
            InitializeComponent();
            var VoditelList = new List<string>();
            var CarList = new List<string>();
            connection = new SqlConnection(connectionString);
            string query = String.Format("SELECT * From [Gai-drivers] Inner Join [Gai-licence] on [Gai-drivers].Id=[Gai-licence].Driverid");
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();
           
            while (rd.Read())
            {
                VoditelList.Add(rd.GetString(1) +" "+ rd.GetString(2)+" "+rd.GetString(3)+" | "+rd.GetInt32(16)+" "+rd.GetInt32(17)+" |");
                
            }
            rd.Close();
            string Secondquery = String.Format("SELECT * From [Gai-Car]");
            SqlCommand Secondcmd = new SqlCommand(Secondquery, connection);
            
            SqlDataReader Secondrd = Secondcmd.ExecuteReader();

            while (Secondrd.Read())
            {
                CarList.Add(Secondrd.GetString(1) + " | " + Secondrd.GetString(2) + " |");

            }
            Secondrd.Close();
            connection.Close();

            DtpFirstDriver.ItemsSource = VoditelList;
            DtpSecondDriver.ItemsSource = VoditelList;
            DtpThirdDriver.ItemsSource = VoditelList;
            DtpFourthDriver.ItemsSource = VoditelList;
            DtpFirstCar.ItemsSource = CarList;
            DtpSecondCar.ItemsSource = CarList;
            DtpThirdCar.ItemsSource = CarList;
            DtpFourthCar.ItemsSource = CarList;
        }

     

        private void BtnAddDtp_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (TboxAdressInfo.Text != null && TboxInfoOdjects.Text != null && TboxInfoZhertvi.Text != null&& DateDtp.Date!=null)
                {
                connection.Open();
                string Thirdquery = String.Format("INSERT INTO [Gai-Dtp] (Classification, Adress,InfoObjects,KolvoZhertv,Decription,DateTime,Photo,PhotoPlan) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", DtpClassification.Items[DtpClassification.SelectedIndex], TboxAdressInfo.Text, TboxInfoOdjects.Text,Convert.ToInt32(TboxInfoZhertvi.Text), TboxComment.Text,DateDtp.Date, null, null);
                SqlCommand Thirdcmd = new SqlCommand(Thirdquery, connection);
                Thirdcmd.ExecuteNonQuery();


                int DtpCod = 0;
                string Secondquery = String.Format("SELECT Max ([Id]) From [Gai-Dtp]");
                SqlCommand Secondcmd = new SqlCommand(Secondquery, connection);
                SqlDataReader rd = Secondcmd.ExecuteReader();
                while (rd.Read())
                {
                    DtpCod = rd.GetInt32(0);

                }
                rd.Close();

                
                if (DtpFirstDriver.SelectedItem != null)
                {
                    if (DtpFirstCar.SelectedItem != null) 
                    { 
                    Thirdquery = String.Format("INSERT INTO [Gai-DtpYchastnik] (CodDtp, GodDriver,CodCar,Photo) VALUES('{0}', '{1}', '{2}', '{3}')",DtpCod, DtpFirstDriver.SelectedIndex + 5, DtpFirstCar.SelectedIndex+1, null);
                    Thirdcmd = new SqlCommand(Thirdquery, connection);
                    Thirdcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        DisplayAlert("Ошибка", "Выберите автомобиль первого участника ДТП", "ок");
                    }
                }


                if (DtpSecondDriver.SelectedItem != null)
                {
                    if (DtpSecondCar.SelectedItem != null)
                    {
                        Thirdquery = String.Format("INSERT INTO [Gai-DtpYchastnik] (CodDtp, GodDriver,CodCar,Photo) VALUES('{0}', '{1}', '{2}', '{3}')", DtpCod, DtpSecondDriver.SelectedIndex + 5, DtpSecondCar.SelectedIndex + 1, null);
                        Thirdcmd = new SqlCommand(Thirdquery, connection);
                        Thirdcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        DisplayAlert("Ошибка", "Выберите автомобиль втоого участника ДТП", "ок");
                    }
                }


                if (DtpThirdDriver.SelectedItem != null)
                {
                    if (DtpThirdCar.SelectedItem != null)
                    {
                        Thirdquery = String.Format("INSERT INTO [Gai-DtpYchastnik] (CodDtp, GodDriver,CodCar,Photo) VALUES('{0}', '{1}', '{2}', '{3}')", DtpCod, DtpThirdDriver.SelectedIndex + 5, DtpThirdCar.SelectedIndex + 1, null);
                        Thirdcmd = new SqlCommand(Thirdquery, connection);
                        Thirdcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        DisplayAlert("Ошибка", "Выберите автомобиль третьего участника ДТП", "ок");
                    }
                }

                if (DtpFourthDriver.SelectedItem != null)
                {
                    if (DtpFourthCar.SelectedItem != null)
                    {
                        Thirdquery = String.Format("INSERT INTO [Gai-DtpYchastnik] (CodDtp, GodDriver,CodCar,Photo) VALUES('{0}', '{1}', '{2}', '{3}')", DtpCod, DtpFourthDriver.SelectedIndex + 5, DtpFourthCar.SelectedIndex + 1, null);
                        Thirdcmd = new SqlCommand(Thirdquery, connection);
                        Thirdcmd.ExecuteNonQuery();
                    }
                    else
                    {
                        DisplayAlert("Ошибка", "Выберите автомобиль четвёртого участника ДТП", "ок");
                    }
                }
                    DisplayAlert("Успех", "Дтп добавлено", "Ок");
                    connection.Close();
                }
                else
                {
                    DisplayAlert("Ошибка", "Заполните все поля и выберите дату", "Ок");
                }
            }
            catch
            {
                DisplayAlert("Ошибка!", "Ошибка", "ок");
            }
            
        }
        private void BtnAddImage_Click(object sender, EventArgs e)
        {
           
        }

       
    }
}