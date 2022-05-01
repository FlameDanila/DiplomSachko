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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (Error.Visibility == Visibility.Visible)
            { MessageBox.Show("Этот логин уже занят, придумайте другой"); }
            else
            {
                if (FirstNameBox.Text == "" || LastNameBox.Text == "" || MiddleNameBox.Text == "" || PhoneBox.Text == "" || PasswordBox.Text == "" || LoginBox.Text == "" || PasportBox.Text == "")
                { MessageBox.Show("У вас остались незаполненые поля"); }
                else
                {
                    if (ComboBoxUser.Text == "Покупатель")
                    {
                        Purchasers purchasers = new Purchasers()
                        {
                            FirstName = FirstNameBox.Text,
                            LastName = LastNameBox.Text,
                            MiddleName = MiddleNameBox.Text,
                            Phone = PhoneBox.Text,
                            Passport = PasportBox.Text,
                            Login = LoginBox.Text,
                            Password = PasswordBox.Text,
                            Gender = FloorCombo.Text
                        };

                        App.db.Purchasers.Add(purchasers);
                        App.db.SaveChanges();
                        MessageBox.Show("Пользователь " + FirstNameBox.Text + " добавлен");
                    }
                    else
                    {
                        Purchasers purchasers = new Purchasers()
                        {
                            FirstName = FirstNameBox.Text,
                            LastName = LastNameBox.Text,
                            MiddleName = MiddleNameBox.Text,
                            Phone = PhoneBox.Text,
                            Passport = PasportBox.Text,
                            Login = LoginBox.Text,
                            Password = PasswordBox.Text,
                            Gender = FloorCombo.Text
                        };

                        App.db.Purchasers.Add(purchasers);
                        App.db.SaveChanges();
                        MessageBox.Show("Пользователь " + FirstNameBox.Text + " добавлен");
                    }
                    List<Owners> OwnersLoginList = App.db.Owners.ToList();
                    List<Purchasers> PurchasersLoginList = App.db.Purchasers.ToList();

                    var LoginList = OwnersLoginList.Select(n => n.Login).ToList();
                    LoginList.AddRange(PurchasersLoginList.Select(n => n.Login).ToList());

                    if (LoginList.Contains(LoginBox.Text))
                    {
                        Error.Visibility = Visibility.Visible;
                    }
                    else { Error.Visibility = Visibility.Hidden; }
                }
            }
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Owners> OwnersLoginList = App.db.Owners.ToList();
            List<Purchasers> PurchasersLoginList = App.db.Purchasers.ToList();

            var LoginList = OwnersLoginList.Select(n => n.Login).ToList();
            LoginList.AddRange(PurchasersLoginList.Select(n => n.Login).ToList());

            if (LoginList.Contains(LoginBox.Text))
            {
                Error.Visibility = Visibility.Visible;
            }
            else { Error.Visibility = Visibility.Hidden; }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
