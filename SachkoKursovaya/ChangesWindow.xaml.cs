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
            grid.Children.Clear();

            DataTable data = Select($"select * from Apartments where OwnerId = '{App.userId}'");

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
                idApartment.Add(Convert.ToInt32(data.Rows[i][0].ToString()));
                roomsCount.Add(data.Rows[i][1].ToString());
                adres.Add(data.Rows[i][2].ToString());
                Cost.Add(data.Rows[i][3].ToString());
                City.Add(data.Rows[i][4].ToString());
                LivingSpace.Add(data.Rows[i][5].ToString());
                Floor.Add(data.Rows[i][6].ToString());
                ApartmentsPhoto.Add(data.Rows[i][7].ToString());
                OwnerId.Add(data.Rows[i][8].ToString());
            }

            int top = 20;
            int bottom = 2;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                StackPanel imageStack = new StackPanel();
                imageStack.Orientation = Orientation.Horizontal;
                imageStack.Height = 400;
                imageStack.Name = "s" + idApartment[i];
                imageStack.PreviewMouseRightButtonDown += Dell_Click;
                imageStack.MouseEnter += ImageStack_GotFocus;
                imageStack.MouseLeave += ImageStack_LostFocus;

                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;

                TextBlock adresText = new TextBlock();
                adresText.Text = "Адрес: " + adres[i];
                adresText.FontSize = 40;
                adresText.HorizontalAlignment = HorizontalAlignment.Left;
                adresText.VerticalAlignment = VerticalAlignment.Top;
                adresText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock RoomsCountText = new TextBlock();
                RoomsCountText.Text = "Колличество комнат: " + roomsCount[i];
                RoomsCountText.FontSize = 40;
                RoomsCountText.HorizontalAlignment = HorizontalAlignment.Left;
                RoomsCountText.VerticalAlignment = VerticalAlignment.Top;
                RoomsCountText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock CostText = new TextBlock();
                CostText.Text = "Стоимость: " + Cost[i];
                CostText.FontSize = 40;
                CostText.HorizontalAlignment = HorizontalAlignment.Left;
                CostText.VerticalAlignment = VerticalAlignment.Top;
                CostText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock CityText = new TextBlock();
                CityText.Text = "Город: " + City[i];
                CityText.FontSize = 40;
                CityText.HorizontalAlignment = HorizontalAlignment.Left;
                CityText.VerticalAlignment = VerticalAlignment.Top;
                CityText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock LivingSpaceText = new TextBlock();
                LivingSpaceText.Text = "Площадь квартиры: " + LivingSpace[i];
                LivingSpaceText.FontSize = 40;
                LivingSpaceText.HorizontalAlignment = HorizontalAlignment.Left;
                LivingSpaceText.VerticalAlignment = VerticalAlignment.Top;
                LivingSpaceText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock FloorText = new TextBlock();
                FloorText.Text = "Этаж: " + Floor[i];
                FloorText.FontSize = 40;
                FloorText.HorizontalAlignment = HorizontalAlignment.Left;
                FloorText.VerticalAlignment = VerticalAlignment.Top;
                FloorText.Margin = new Thickness(top, bottom, 0, 0);

                Image image = new Image();
                image.Width = 300;
                image.Height = 300;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.VerticalAlignment = VerticalAlignment.Top;
                image.Stretch = Stretch.Fill;
                image.Margin = new Thickness(top + 100, bottom + 20, 0, 0);

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();

                string route = ApartmentsPhoto[i].Replace("\\", "/");
                if (route.Split('/').Count() > 2)
                {
                    logo.UriSource = new Uri(ApartmentsPhoto[i], UriKind.Absolute);
                    logo.EndInit();
                }
                image.Source = logo;
                if (image.Source == null)
                {
                    image.ToolTip = "Изображение не доступно";
                }

                stackPanel.Children.Add(adresText);
                stackPanel.Children.Add(FloorText);
                stackPanel.Children.Add(LivingSpaceText);
                stackPanel.Children.Add(CityText);
                stackPanel.Children.Add(RoomsCountText);
                stackPanel.Children.Add(CostText);

                imageStack.Children.Add(stackPanel);
                imageStack.Children.Add(image);

                grid.Children.Add(imageStack);
            }
        }

        private void ImageStack_LostFocus(object sender, RoutedEventArgs e)
        {
            var name = sender as StackPanel;
            name.Background = null;
        }

        private void ImageStack_GotFocus(object sender, RoutedEventArgs e)
        {
            var name = sender as StackPanel;
            name.Background = Brushes.AliceBlue;
        }

        private void Dell_Click(object sender, MouseButtonEventArgs e)
        {
            var name = sender as StackPanel;

            Apartments apartments = new Apartments();
            apartments.id = Convert.ToInt32(name.Name.Replace("s", ""));

            if (MessageBox.Show("Вы точно хотите удалить недвижимость из списка?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No) { }
            else
            {
                Select($"DELETE from Agenstvo.dbo.Apartments where id = '{apartments.id}'");
            }
            Update();
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
