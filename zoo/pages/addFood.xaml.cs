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
    /// Логика взаимодействия для addFood.xaml
    /// </summary>
    public partial class addFood : Page
    {
        public addFood()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                imp.food foodObj = new imp.food()
                {
                    name = txbName.Text,
                    type = txbType.Text,
                    quantity = Convert.ToInt32(txbQuant.Text)
                };
                imp.dbCon.entObj.food.Add(foodObj);
                imp.dbCon.entObj.SaveChanges();
                MessageBox.Show(
                    "Поставщик '" + foodObj.name + "' добавлен",
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
