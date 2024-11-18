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
    /// Логика взаимодействия для timatable.xaml
    /// </summary>
    public partial class timatable : Page
    {
        public timatable()
        {
            InitializeComponent();
            time.ItemsSource = dbCon.entObj.timetable.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
