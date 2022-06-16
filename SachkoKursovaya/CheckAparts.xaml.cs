using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace SachkoKursovaya
{
    /// <summary>
    /// Логика взаимодействия для CheckAparts.xaml
    /// </summary>
    public partial class CheckAparts : Window
    {
        public CheckAparts()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            grid.Children.Clear();

            DataTable data = Select($"select * from Apartments where id = '{App.appId}'");

            List<string> adres = new List<string>();
            List<string> roomsCount = new List<string>();
            List<string> Cost = new List<string>();
            List<string> City = new List<string>();
            List<string> LivingSpace = new List<string>();
            List<string> Floor = new List<string>();
            List<string> ApartmentsPhoto = new List<string>();
            List<string> OwnerId = new List<string>();
            List<int> idApartment = new List<int>();

            idApartment.Add(Convert.ToInt32(data.Rows[0][0].ToString()));
            roomsCount.Add(data.Rows[0][1].ToString());
            adres.Add(data.Rows[0][2].ToString());
            Cost.Add(data.Rows[0][3].ToString());
            City.Add(data.Rows[0][4].ToString());
            LivingSpace.Add(data.Rows[0][5].ToString());
            Floor.Add(data.Rows[0][6].ToString());
            ApartmentsPhoto.Add(data.Rows[0][7].ToString());
            OwnerId.Add(data.Rows[0][8].ToString());

            DataTable userData = Select($"Select phone, name from owners where id = '{OwnerId[0]}'");

            int top = 20;
            int bottom = 2;

            StackPanel stackPanel = new StackPanel();

            TextBlock adresText = new TextBlock();
            adresText.Text = "Адрес: " + adres[0];
            adresText.FontSize = 30;
            adresText.HorizontalAlignment = HorizontalAlignment.Left;
            adresText.VerticalAlignment = VerticalAlignment.Top;
            adresText.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock RoomsCountText = new TextBlock();
            RoomsCountText.Text = "Колличество комнат: " + roomsCount[0];
            RoomsCountText.FontSize = 30;
            RoomsCountText.HorizontalAlignment = HorizontalAlignment.Left;
            RoomsCountText.VerticalAlignment = VerticalAlignment.Top;
            RoomsCountText.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock CostText = new TextBlock();
            CostText.Text = "Стоимость: " + Cost[0] + "₽";
            CostText.FontSize = 30;
            CostText.HorizontalAlignment = HorizontalAlignment.Left;
            CostText.VerticalAlignment = VerticalAlignment.Top;
            CostText.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock CityText = new TextBlock();
            CityText.Text = "Город: " + City[0];
            CityText.FontSize = 30;
            CityText.HorizontalAlignment = HorizontalAlignment.Left;
            CityText.VerticalAlignment = VerticalAlignment.Top;
            CityText.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock LivingSpaceText = new TextBlock();
            LivingSpaceText.Text = "Площадь квартиры: " + LivingSpace[0];
            LivingSpaceText.FontSize = 30;
            LivingSpaceText.HorizontalAlignment = HorizontalAlignment.Left;
            LivingSpaceText.VerticalAlignment = VerticalAlignment.Top;
            LivingSpaceText.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock FloorText = new TextBlock();
            FloorText.Text = "Этаж: " + Floor[0];
            FloorText.FontSize = 30;
            FloorText.HorizontalAlignment = HorizontalAlignment.Left;
            FloorText.VerticalAlignment = VerticalAlignment.Top;
            FloorText.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock phoneNumber = new TextBlock();
            phoneNumber.Text = "Номер телефона: " + userData.Rows[0][0].ToString();
            phoneNumber.FontSize = 30;
            phoneNumber.HorizontalAlignment = HorizontalAlignment.Left;
            phoneNumber.VerticalAlignment = VerticalAlignment.Top;
            phoneNumber.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock userName = new TextBlock();
            userName.Text = "ФИО: " + userData.Rows[0][1].ToString();
            userName.FontSize = 30;
            userName.HorizontalAlignment = HorizontalAlignment.Left;
            userName.VerticalAlignment = VerticalAlignment.Top;
            userName.Margin = new Thickness(top, bottom, 0, 0);

            TextBlock rieltorCost = new TextBlock();
            rieltorCost.TextWrapping = TextWrapping.Wrap;
            rieltorCost.Width = 540;
            rieltorCost.Text = "Стоимость вместе с услугами риелтора: " + (Convert.ToInt32(data.Rows[0][3]) * 1.002).ToString() + "₽";
            rieltorCost.FontSize = 30;
            rieltorCost.HorizontalAlignment = HorizontalAlignment.Left;
            rieltorCost.VerticalAlignment = VerticalAlignment.Top;
            rieltorCost.Margin = new Thickness(top, bottom, 0, 0);

            stackPanel.Children.Add(adresText);
            stackPanel.Children.Add(FloorText);
            stackPanel.Children.Add(LivingSpaceText);
            stackPanel.Children.Add(CityText);
            stackPanel.Children.Add(RoomsCountText);
            stackPanel.Children.Add(CostText);
            stackPanel.Children.Add(userName);
            stackPanel.Children.Add(phoneNumber);
            stackPanel.Children.Add(rieltorCost);

            grid.Children.Add(stackPanel);
            
        }
        public DataTable Select(string selectSQL)
        {
            DataTable data = new DataTable("dataBase");

            string path = "ConnectionString.txt";

            string text = File.ReadAllText(path);

            string[] vs = text.Split('"');

            SqlConnection sqlConnection = new SqlConnection($"server = {vs[1]};Trusted_connection={vs[3]};DataBase={vs[5]};User={vs[7]};PWD={vs[9]}");
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = selectSQL;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(data);

            return data;
        }
        public void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
