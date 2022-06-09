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

            List<Apartments> apartments = App.db.Apartments.Where(n => n.OwnerId == App.userId).ToList();
            int list = 0;
            foreach (var i in apartments)
            {
                list = Convert.ToInt32(i.Cost);
            }

            textAgent.Text = "Итоговая сумма, вместе с комиссией риелтора: " + list * 1.005;
        }
        public void Update()
        {
            List.ItemsSource = App.db.Apartments.Where(n => n.id == App.userId).ToList();
        }
        public void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppendApparts append = new AppendApparts();
            append.Show();
            Close();
        }
    }
}
