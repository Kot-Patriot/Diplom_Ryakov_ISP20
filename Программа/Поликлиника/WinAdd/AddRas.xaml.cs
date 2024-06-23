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
    /// Логика взаимодействия для AddRas.xaml
    /// </summary>
    public partial class AddRas : Window
    {
        public AddRas()
        {
            InitializeComponent();

            DocCmb.ItemsSource = AppData.db.Doctors.ToList();
            SpecDocCmb.ItemsSource = AppData.db.Doctors.ToList();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            if (DocCmb.SelectedValue == null)
                sb.AppendLine("Доктор пусто");
            if (KabTxb.Text == "")
                sb.AppendLine("Кабинет пусто");
            if (SpecDocCmb.SelectedValue == null)
                sb.AppendLine("Специальность пусто");
            if (Date_of_beginCal.Text == "")
                sb.AppendLine("Начало пусто");
            if (Date_of_endCal.Text == "")
                sb.AppendLine("Конец пусто");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                return;
            }

            Raspis raspis = new Raspis();

            try
            {
                var curDoc = DocCmb.SelectedItem as Doctors;
                raspis.FIODoc = curDoc.FIO;

                var curSpecDoc = SpecDocCmb.SelectedItem as Doctors;
                raspis.SpecDoc = curSpecDoc.Specification;

                raspis.Room = KabTxb.Text;

                raspis.BEginOf = Date_of_beginCal.SelectedDate.Value;
                raspis.EndOF = Date_of_endCal.SelectedDate.Value;

                AppData.db.Raspis.Add(raspis);
                AppData.db.SaveChanges();
                MessageBox.Show("Расписание запланировано");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }

            
        }

        private void GoBa_Btn_Click(object sender, RoutedEventArgs e)
        {
            Window5 win5 = new Window5();
            win5.Show();
            this.Close();
        }
    }
}
