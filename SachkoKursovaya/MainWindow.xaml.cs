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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SachkoKursovaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Flag = 0;
        public int close = 0;
        public int Reg = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxUser.Text == "Владелец квартиры")
            {
                List<Owners> OwnersLoginList = App.db.Owners.ToList();
                
                var PasswordList = OwnersLoginList.Select(n => n.Password).ToList();
                var LoginList = OwnersLoginList.Select(n => n.Login).ToList();
                var NamesList = OwnersLoginList.Select(n => n.FirstName).ToList();
                var idList = OwnersLoginList.Select(n => n.ApartmentsId).ToList();

                for (int i = 0; i < OwnersLoginList.Count; i++)
                {
                    if (LoginBox.Text == LoginList[i])
                    {
                        if (PasswordBox.Text == PasswordList[i] || MyPasswordBox.Password == PasswordList[i])
                        {
                            App.name = NamesList[i];
                            App.login = LoginList[i];
                            App.ApartId = Convert.ToInt32(idList[i]);
                            MessageBox.Show("Авторизация прошла успешно");
                            Owner Owner = new Owner();
                            Owner.Show();
                            Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен неверно");

                            PasswordBox.Text = ""; MyPasswordBox.Password = "";
                            break;
                        }
                    }
                    else { }
                }
            }
            else 
            {
                List<Purchasers> PurchasersLoginList = App.db.Purchasers.ToList();

                var PasswordList = PurchasersLoginList.Select(n => n.Password).ToList();
                var LoginList = PurchasersLoginList.Select(n => n.Login).ToList();
                var NamesList = PurchasersLoginList.Select(n => n.FirstName).ToList();

                for (int i = 0; i < PurchasersLoginList.Count; i++)
                {
                    if (LoginBox.Text == LoginList[i])
                    {
                        if (PasswordBox.Text == PasswordList[i] || MyPasswordBox.Password == PasswordList[i])
                        {
                            App.name = NamesList[i];
                            App.login = LoginList[i];
                            MessageBox.Show("Авторизация прошла успешно");
                            Owner Owner = new Owner();
                            Owner.Show();
                            Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Пароль введен неверно");

                            PasswordBox.Text = ""; MyPasswordBox.Password = "";
                            break;
                        }
                    }
                    else { }
                }
            }
        }
        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            PasswordBox.Text = MyPasswordBox.Password;
            MyPasswordBox.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Visible;
        }

        private void UnshowPassword(object sender, RoutedEventArgs e)
        {
            MyPasswordBox.Password = PasswordBox.Text;
            PasswordBox.Visibility = Visibility.Hidden;
            MyPasswordBox.Visibility = Visibility.Visible;
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }
    }
}
