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

namespace zoo.pages
{
    /// <summary>
    /// Логика взаимодействия для addVac.xaml
    /// </summary>
    public partial class addVac : Page
    {
        public addVac(object d)
        {
            InitializeComponent();
            DataContext = d;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime Date = Convert.ToDateTime(txbDate.Text);
                imp.vaccination vacObj = new imp.vaccination()
                {
                    idAnimal = (int)TypeDescriptor.GetProperties(DataContext)["id"].GetValue(DataContext),
                    name = txbName.Text,
                    date = Date
                };
                imp.dbCon.entObj.vaccination.Add(vacObj);
                imp.dbCon.entObj.SaveChanges();
                MessageBox.Show(
                    "Вакцинация " + vacObj.name + ", успешно добавлена",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
                this.NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Критическая ошибка" + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                    );
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
