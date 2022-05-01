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
            List.ItemsSource = App.db.Apartments.Where(n => n.id == App.ApartId).ToList();
        }
        public void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
