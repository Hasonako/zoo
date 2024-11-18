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
using zoo.imp;

namespace zoo.pages
{
    /// <summary>
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        private string rol;
        public login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbCon.entObj = new zooEntities1();

            var user = dbCon.entObj.roles.FirstOrDefault(x => x.pass == pass.Password && x.login == log.Text);
            if (user == null) wrong.Content = "Вы ввели неверный логин или пароль";
            else rol = user.role;

            if (rol == "admin") this.NavigationService.Navigate(new adminPage());
            else if (rol == "ветврач") this.NavigationService.Navigate(new adminAnimals());
            else if (rol == "уборщик" ||  rol == "дрессировщик") this.NavigationService.Navigate(new timatable());
            else if (rol == "строитель") this.NavigationService.Navigate(new warmCells());
            else wrong.Content = "Неверный логин или пароль";
        }
    }
}
