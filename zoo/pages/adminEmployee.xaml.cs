using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для adminEmployee.xaml
    /// </summary>
    public partial class adminEmployee : Page
    {
        private employee d;
        public adminEmployee()
        {
            InitializeComponent();
            emp.ItemsSource = dbCon.entObj.employee.ToList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(emp.SelectedItem)["id"].GetValue(emp.SelectedItem);
            d = dbCon.entObj.employee.FirstOrDefault(x => x.id == (int)id);
            MessageBoxResult result = MessageBox.Show("Вы уверены?");
            if (result == MessageBoxResult.OK)
            {
                dbCon.entObj.employee.Remove(d);
                dbCon.entObj.SaveChanges();
                emp.ItemsSource = dbCon.entObj.employee.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new addEmp());
        }
    }
}
