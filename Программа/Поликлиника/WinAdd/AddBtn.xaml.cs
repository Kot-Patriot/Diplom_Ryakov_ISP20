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
    /// Логика взаимодействия для AddBtn.xaml
    /// </summary>
    public partial class AddBtn : Window
    {
        public AddBtn()
        {
            InitializeComponent();

            StatusCmb.ItemsSource = AppData.db.Information.ToList();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (FIOTxb.Text == "")
                sb.AppendLine("ФИО пусто");
            if (GenderTxb.Text == "")
                sb.AppendLine("Пол пусто");
            if (DataReciveCal.Text == "")
                sb.AppendLine("Дата поступления пусто");
            if (A_brief_historyTxb.Text == "")
                sb.AppendLine("Краткая история пусто");
            if (StatusCmb.SelectedValue == null)
                sb.AppendLine("Статус пусто");
            if (Date_of_birthCal.Text == "")
                sb.AppendLine("Дата рождения пусто");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                return;
            }

            Information information = new Information();

            try
            {
                information.FIO = FIOTxb.Text;
                information.Gender = GenderTxb.TabIndex;
                information.DateRecive = DataReciveCal.SelectedDate.Value;
                information.History = A_brief_historyTxb.Text;
                var currectStatus = StatusCmb.SelectedItem as Information;
                information.Status = currectStatus.Status;
                information.Birthday = Date_of_birthCal.SelectedDate.Value;

                AppData.db.Information.Add(information);
                AppData.db.SaveChanges();
                MessageBox.Show("Пациент был добавлен в базу");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
            

        }

        private void GoBa_Btn_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }
    }
}
