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
    /// Логика взаимодействия для ApppendApparts.xaml
    /// </summary>
    public partial class AppendApparts : Window
    {
        public AppendApparts()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Apartments apartments = new Apartments();
            if (RoomsBox.Text == "" || TotakSpaceBox.Text == "" || LivingSpaceBox.Text == "" || AdresBox.Text == "" || FloorBox.Text == "" || Metro.Text == "" || CostBox.Text == "" || CityBox.Text == "")
            { MessageBox.Show("У вас остались незаполненые поля"); }
            else
            {
                apartments.RoomsCount = Convert.ToInt32(RoomsBox.Text);
                apartments.TotalSpace = Convert.ToInt32(TotakSpaceBox);
                apartments.LivingSpace = Convert.ToInt32(LivingSpaceBox.Text);
                apartments.Adres = AdresBox.Text;
                apartments.Floor = Convert.ToInt32(FloorBox.Text);
                apartments.Metro = Convert.ToInt32(Metro.Text);
                apartments.Cost = Convert.ToInt32(CostBox.Text);

                App.db.Apartments.Add(apartments);
                App.db.SaveChanges();
                MessageBox.Show("Добавлено!");
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChangesWindow changesWindow = new ChangesWindow();
            changesWindow.Show();
            Close();
        }
    }
}
