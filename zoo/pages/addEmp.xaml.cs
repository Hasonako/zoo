using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для addEmp.xaml
    /// </summary>
    public partial class addEmp : Page
    {
        public addEmp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime Date = Convert.ToDateTime(txbBirt.Text);
                imp.employee empObj = new imp.employee()
                {
                    name = txbName.Text,
                    birthday = Date,
                    sex = txbSex.Text,
                    phone_number = txbNum.Text,
                    title = txbTitle.Text
                };
                imp.dbCon.entObj.employee.Add(empObj);
                imp.dbCon.entObj.SaveChanges();
                MessageBox.Show(
                    "Сотрудник '" + empObj.name + "' добавлен",
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
    }
}
