using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для diseases.xaml
    /// </summary>
    public partial class diseases : Page
    {
        public static animal d;
        public diseases(object item)
        {
            InitializeComponent();
            DataContext = item;
            int id = Convert.ToInt32(TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext));
            dis.ItemsSource = dbCon.entObj.diseases.Where(x => x.idAnimal == (int)id).ToList();
            d = dbCon.entObj.animal.FirstOrDefault(x => x.id == (int)id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new addDis(d));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
