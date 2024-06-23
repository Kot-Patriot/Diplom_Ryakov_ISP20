using Avtorizaciya;
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
using Приложушечка.Model;

namespace Приложушечка
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        MedTest_Entities db = new MedTest_Entities();
        public Window5()
        {
            InitializeComponent();

            if (MainWindow.Globals.Role == 1)
            {
                AddBtn.Visibility = Visibility.Visible;
                EditBtn.Visibility = Visibility.Visible;
                RemoveBtn.Visibility = Visibility.Visible;
            }
            else
            {
                AddBtn.Visibility = Visibility.Collapsed;
                EditBtn.Visibility = Visibility.Collapsed;
                RemoveBtn.Visibility = Visibility.Collapsed;
            }
        }

        private void glavnaya_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }

        private void sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            win2.Show();
            this.Close();
        }

        private void prikazy_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
            this.Close();
        }

        private void otchety_Click(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            win4.Show();
            this.Close();
        }

        private void raspisanye_Click(object sender, RoutedEventArgs e)
        {

        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Window6 win6 = new Window6();
            win6.Show();
            this.Close();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddRas ras = new AddRas();
            ras.Show();
            this.Close();
        }

        private void Edit_btn_click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                Edit4 edit = new Edit4(UsersGrid.SelectedValue as Raspis);
                edit.ShowDialog();
                //AppData.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выбирете пользователя");
            }
            MedTest_Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrectPac = UsersGrid.SelectedItem as Raspis;
                AppData.db.Raspis.Remove(CurrectPac);
                AppData.db.SaveChanges();

                UsersGrid.ItemsSource = AppData.db.Raspis.ToList();
                MessageBox.Show("Успешно");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.Raspis.ToList();
        }
    }
}
