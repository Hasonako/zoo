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
    /// Логика взаимодействия для warmCells.xaml
    /// </summary>
    public partial class warmCells : Page
    {
        public warmCells()
        {
            InitializeComponent();
            animals.ItemsSource = dbCon.entObj.animal.ToList();

            cmbType.ItemsSource = dbCon.entObj.animal.GroupBy(x => x.warmRoom).ToList();
            cmbType.SelectedValuePath = "warmRoom";
            cmbType.DisplayMemberPath = "warmRoom";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedGroup = Convert.ToString(cmbType.SelectedValue);
            animals.ItemsSource = imp.dbCon.entObj.animal.Where(x => x.warmRoom == SelectedGroup).ToList();
        }
    }
}
