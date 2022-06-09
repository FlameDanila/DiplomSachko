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
    /// Логика взаимодействия для ChangesWindow.xaml
    /// </summary>
    public partial class ChangesWindow : Window
    {
        public ChangesWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            DataTable data = Select($"Select * from apartments where ownerId = '{App.userId}'");

            List<string> adres = new List<string>();
            List<string> roomsCount = new List<string>();
            List<string> Cost = new List<string>();
            List<string> City = new List<string>();
            List<string> LivingSpace = new List<string>();
            List<string> Floor = new List<string>();
            List<string> ApartmentsPhoto = new List<string>();
            List<string> OwnerId = new List<string>();
            List<int> idApartment = new List<int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                adres.Add(data.Rows[i][0].ToString());
                roomsCount.Add(data.Rows[i][0].ToString());
                Cost.Add(data.Rows[i][0].ToString());
                City.Add(data.Rows[i][0].ToString());
                LivingSpace.Add(data.Rows[i][0].ToString());
                ApartmentsPhoto.Add(data.Rows[i][0].ToString());
                Floor.Add(data.Rows[i][0].ToString());
                OwnerId.Add(data.Rows[i][0].ToString());
                idApartment.Add(Convert.ToInt32(data.Rows[i][0].ToString()));
            }

            int top = 20;
            int bottom = 2;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                MessageBox.Show("1");
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Height = 50;
                stackPanel.Name = "s" + idApartment[i];
                stackPanel.PreviewMouseRightButtonDown += Dell_Click;

                TextBlock adresText = new TextBlock();
                adresText.Text = adres[i];
                adresText.FontSize = 30;
                adresText.HorizontalAlignment = HorizontalAlignment.Left;
                adresText.VerticalAlignment = VerticalAlignment.Top;
                adresText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock RoomsCountText = new TextBlock();
                RoomsCountText.Text = roomsCount[i];
                RoomsCountText.FontSize = 30;
                RoomsCountText.HorizontalAlignment = HorizontalAlignment.Left;
                RoomsCountText.VerticalAlignment = VerticalAlignment.Top;
                RoomsCountText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock CostText = new TextBlock();
                CostText.Text = Cost[i];
                CostText.FontSize = 30;
                CostText.HorizontalAlignment = HorizontalAlignment.Left;
                CostText.VerticalAlignment = VerticalAlignment.Top;
                CostText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock CityText = new TextBlock();
                CityText.Text = City[i];
                CityText.FontSize = 30;
                CityText.HorizontalAlignment = HorizontalAlignment.Left;
                CityText.VerticalAlignment = VerticalAlignment.Top;
                CityText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock LivingSpaceText = new TextBlock();
                LivingSpaceText.Text = LivingSpace[i];
                LivingSpaceText.FontSize = 30;
                LivingSpaceText.HorizontalAlignment = HorizontalAlignment.Left;
                LivingSpaceText.VerticalAlignment = VerticalAlignment.Top;
                LivingSpaceText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock FloorText = new TextBlock();
                FloorText.Text = Floor[i];
                FloorText.FontSize = 30;
                FloorText.HorizontalAlignment = HorizontalAlignment.Left;
                FloorText.VerticalAlignment = VerticalAlignment.Top;
                FloorText.Margin = new Thickness(top, bottom, 0, 0);

                Image image = new Image();
                image.Width = 300;
                image.Height = 450;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.VerticalAlignment = VerticalAlignment.Top;
                image.Stretch = Stretch.Fill;
                image.Margin = new Thickness(top, bottom, 0, 0);

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(ApartmentsPhoto[i], UriKind.Relative);
                logo.EndInit();

                image.Source = logo;

                stackPanel.Children.Add(adresText);
                stackPanel.Children.Add(FloorText);
                stackPanel.Children.Add(LivingSpaceText);
                stackPanel.Children.Add(CityText);
                stackPanel.Children.Add(RoomsCountText);
                stackPanel.Children.Add(CostText);
                stackPanel.Children.Add(image);

                grid.Children.Add(stackPanel);
            }
        }

        private void Dell_Click(object sender, MouseButtonEventArgs e)
        {
            var name = sender as StackPanel;

            Apartments apartments = new Apartments();
            apartments.id = Convert.ToInt32(name.Name.Replace("s", ""));

            App.db.Apartments.Remove(apartments);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Owner window = new Owner();
            window.Show();
            Close();
        }

        private void Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppendApparts append = new AppendApparts();
            append.Show();
            Close();
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
    }
}
