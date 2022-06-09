using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SachkoKursovaya
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AgenstvoEntities1 db = new AgenstvoEntities1();
        public static string name = "";
        public static string login = "";
        public static int userId = 0;
    }
}