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
using System.Windows.Shapes;

namespace SachkoKursovaya
{
    /// <summary>
    /// Логика взаимодействия для Owner.xaml
    /// </summary>
    public partial class Owner : Window
    {
        public Owner()
        {
            InitializeComponent();
            Update();
            NameText.Text = "Здраствуйте, " + App.name;

            List<Owners> PurchasersLoginList = App.db.Owners.ToList();
            var SecondLoginList = PurchasersLoginList.Select(n => n.Login).ToList();

            if (SecondLoginList.Contains(App.login))
            {
                Changes.Visibility = Visibility.Visible;
            }
        }

        public void Update()
        {
            List.ItemsSource = App.db.Apartments.ToList();
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
            var button = sender as Image;
            var body = button.DataContext as Apartments;

            App.ApartId = Convert.ToInt32(body.id);

            CheckAparts checkAparts = new CheckAparts();
            checkAparts.Show();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text == "")
            {
                Update();
            }
            if (Combo.Text == "Адрес")
            {
                string f = Search.Text;
                var listBook = App.db.Apartments.Where(Name => Name.Adres.Contains(f)).ToList();
                List.ItemsSource = listBook;
            }
            if (Combo.Text == "Стоимость меньше")
            {
                if (Search.Text != "")
                {
                    try
                    {
                        int f = Convert.ToInt32(Search.Text);
                        var listBook = App.db.Apartments.Where(m => m.Cost >= f).ToList();
                        List.ItemsSource = listBook;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Введите число");
                    }
                }
            }
            if (Combo.Text == "Стоимость больше")
            {
                if (Search.Text != "")
                {
                    try
                    {
                        int f = Convert.ToInt32(Search.Text);
                        var listBook = App.db.Apartments.Where(m => m.Cost <= f).ToList();
                        List.ItemsSource = listBook;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Введите число");
                    }
                }
            }
            if (Combo.Text == "Город")
            {
                string f = Search.Text;
                var listBook = App.db.Apartments.Where(date => date.City.Contains(f)).ToList();
                List.ItemsSource = listBook;
            }
            if (Combo.Text == "Этаж")
            {
                if (Search.Text != "")
                {
                    try
                    {
                        int f = Convert.ToInt32(Search.Text);
                        var listBook = App.db.Apartments.Where(m => m.Floor == f).ToList();
                        List.ItemsSource = listBook;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Введите число");
                    }
                }
            }
            if (Combo.Text == "Метров до метро")
            {
                if (Search.Text != "")
                {
                    try
                    {
                        int f = Convert.ToInt32(Search.Text);
                        var listBook = App.db.Apartments.Where(m => m.Floor == f).ToList();
                        List.ItemsSource = listBook;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Введите число");
                    }
                }
            }
        }
    }
}
