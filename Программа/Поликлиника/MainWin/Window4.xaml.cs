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

namespace Приложушечка
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
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

        private void raspisanye_Click(object sender, RoutedEventArgs e)
        {
            Window5 win5 = new Window5();
            win5.Show();
            this.Close();
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Window6 win6 = new Window6();
            win6.Show();
            this.Close();
        }
    }
}
