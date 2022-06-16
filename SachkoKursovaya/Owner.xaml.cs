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
    /// Логика взаимодействия для Owner.xaml
    /// </summary>
    public partial class Owner : Window
    {
        public string sort = "";
        public int arrow = 0;
        public string find = "";
        public Owner()
        {
            InitializeComponent();

            string[] name = App.name.Split(' ');
            NameText.Text = "Здраствуйте, " + name[1];

            List<Owners> OwnersLoginList = App.db.Owners.ToList();

            var LoginList = OwnersLoginList.Select(n => n.Login).ToList();

            if (LoginList.Contains(App.login))
            {
                Changes.Visibility = Visibility.Visible;
            }
            Update();
        }

        public void Update()
        {
            grid.Children.Clear();

            DataTable data = new DataTable();

            if (sort != "")
            {
                if (find == "")
                {
                    if (arrow == 0)
                    {
                        data = Select($"Select * from Apartments order by {sort}");
                    }
                    else
                    {
                        data = Select($"Select * from Apartments order by {sort} DESC");
                    }
                }
                else
                {
                    if (arrow == 0)
                    {
                        data = Select($"Select * from Apartments where city like '%{find}%' order by {sort}");
                    }
                    else
                    {
                        data = Select($"Select * from Apartments where city like '%{find}%' order by {sort} desc");
                    }
                }
            }
            else
            {
                if (find == "")
                {
                    data = Select("Select * from Apartments");
                }
                else
                {
                    data = Select($"Select * from Apartments where city like '%{find}%'");
                }
            }

            List<string> adres = new List<string>();
            List<string> roomsCount = new List<string>();
            List<string> Cost = new List<string>();
            List<string> City = new List<string>();
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
                Floor.Add(data.Rows[i][6].ToString());
                ApartmentsPhoto.Add(data.Rows[i][7].ToString());
                OwnerId.Add(data.Rows[i][8].ToString());
            }

            int top = 20;
            int bottom = 2;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.MouseLeftButtonDown += StackPanel_MouseLeftButtonDown;
                stackPanel.Name = "s" + idApartment[i];

                TextBlock adresText = new TextBlock();
                adresText.Text = adres[i];
                adresText.FontSize = 35;
                adresText.Width = 220;
                adresText.TextAlignment = TextAlignment.Center;
                adresText.HorizontalAlignment = HorizontalAlignment.Left;
                adresText.VerticalAlignment = VerticalAlignment.Top;
                adresText.Margin = new Thickness(top-10, bottom, 0, 0);

                TextBlock CostText = new TextBlock();
                CostText.Text = Cost[i] + "₽";
                CostText.FontSize = 40;
                CostText.Width = 200;
                CostText.TextAlignment= TextAlignment.Center;
                CostText.HorizontalAlignment = HorizontalAlignment.Left;
                CostText.VerticalAlignment = VerticalAlignment.Top;
                CostText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock CityText = new TextBlock();
                CityText.Text = City[i];
                CityText.FontSize = 40;
                CityText.Width = 200;
                CityText.TextAlignment = TextAlignment.Center;
                CityText.HorizontalAlignment = HorizontalAlignment.Left;
                CityText.VerticalAlignment = VerticalAlignment.Top;
                CityText.Margin = new Thickness(top, bottom, 0, 0);

                TextBlock FloorText = new TextBlock();
                FloorText.Text = Floor[i];
                FloorText.FontSize = 40;
                FloorText.Width = 50;
                FloorText.TextAlignment = TextAlignment.Left;
                FloorText.HorizontalAlignment = HorizontalAlignment.Left;
                FloorText.VerticalAlignment = VerticalAlignment.Top;
                FloorText.Margin = new Thickness(top, bottom, 0, 0);

                Image image = new Image();
                image.Width = 200;
                image.Height = 200;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.VerticalAlignment = VerticalAlignment.Top;
                image.Stretch = Stretch.Fill;
                image.Margin = new Thickness(top + 50, bottom + 20, 0, 0);

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
                stackPanel.Children.Add(CostText);
                stackPanel.Children.Add(CityText);
                stackPanel.Children.Add(FloorText);
                stackPanel.Children.Add(image);

                grid.Children.Add(stackPanel);
            }
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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        private void Changes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChangesWindow changesWindow = new ChangesWindow();
            changesWindow.Show();
            Close();
        }


        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var name = sender as StackPanel;

            App.appId = Convert.ToInt32(name.Name.Replace("s",""));

            CheckAparts checkAparts = new CheckAparts();
            checkAparts.Show();
        }
        private void Name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Adres.Text = "Адрес";
            Floor.Text = "Этаж";
            Cost.Text = "Стоимость";
            City.Text = "Город";

            var name = sender as TextBlock;
            sort = name.Name;

            if (arrow == 0)
            {
                name.Text += "⌄";
                arrow = 1;
            }
            else
            {
                name.Text += "⌃";
                arrow = 0;
            }
            Update();
        }

        private void city_TextChanged(object sender, TextChangedEventArgs e)
        {
            find = cityText.Text;
            Update();
        }
    }
}
