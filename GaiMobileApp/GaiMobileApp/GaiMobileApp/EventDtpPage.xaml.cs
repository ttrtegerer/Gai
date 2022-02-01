using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GaiMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDtpPage : ContentPage
    {
        string connectionString = @"Data Source=stud-mssql.sttec.yar.ru,38325;Database=user79_db;" + "User ID=user79_db;Password=user79;Connect Timeout=30;" + "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" + "MultiSubnetFailover=False";
        SqlConnection connection;
        protected internal ObservableCollection<EventDtp> EventsDtp { get; set; }
        public EventDtpPage()
        {
            InitializeComponent();
            Random rnd = new Random();
            connection = new SqlConnection(connectionString);
            string query = String.Format("SELECT * from [Gai-Dtp] ");
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            EventsDtp = new ObservableCollection<EventDtp> { };
            while (rd.Read())
            {
                var Events = new EventDtp
                {
                    Date = rd.GetString(6),
                    KolvoZhertv = rd.GetInt32(4),
                    Classification = rd.GetString(1),
                    KolvoYthastnikov = rnd.Next(1, 4)

                };
                EventsDtp.Add(Events);
            }
            rd.Close();
            LvEventsDtp.BindingContext = EventsDtp;
            connection.Close();
        }
    }
}