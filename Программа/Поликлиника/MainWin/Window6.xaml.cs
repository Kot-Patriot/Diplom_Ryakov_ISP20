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
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        MedTest_Entities db = new MedTest_Entities();
        public Window6()
        {
            InitializeComponent();
            if (MainWindow.Globals.Role == 1) 
            {
                User_Pole.Text = "Администратор";
            }
            else
            {
                User_Pole.Text = "Пользователь";
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

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void otchety_Click(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            win4.Show();
            this.Close();
        }

        private void raspysanie_Click(object sender, RoutedEventArgs e)
        {
            Window5 win5 = new Window5();
            win5.Show();
            this.Close();
        }
    }
}
