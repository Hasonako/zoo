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
    /// Логика взаимодействия для adminAnimals.xaml
    /// </summary>
    public partial class adminAnimals : Page
    {
        public adminAnimals()
        {
            InitializeComponent();
            animals.ItemsSource = dbCon.entObj.animal.ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = animals.SelectedItem;
            this.NavigationService.Navigate(new diseases(item));
        }

        private void btnEdit_Click_1(object sender, RoutedEventArgs e)
        {
            var item = animals.SelectedItem;
            this.NavigationService.Navigate(new Vaccination(item));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
