using Microsoft.SqlServer.Management.Smo;
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
    /// Логика взаимодействия для AddReg.xaml
    /// </summary>
    public partial class AddReg : Window
    {
        public AddReg()
        {
            InitializeComponent();

            FIOCmb.ItemsSource = AppData.db.Information.ToList();
            StatusCmb.ItemsSource = AppData.db.Information.ToList();
            DocCmb.ItemsSource = AppData.db.Doctors.ToList();
            SpecDocCmb.ItemsSource = AppData.db.Doctors.ToList();

        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (KabTxb.Text == "")
                sb.AppendLine("Кабинет пусто");
            if (TypeOfTargetTxb.Text == "")
                sb.AppendLine("Тип обращения пусто");
            if (SpecDocCmb.SelectedValue == null)
                sb.AppendLine("Специальность пусто");
            if (DocCmb.SelectedValue == null)
                sb.AppendLine("Доктор пусто");
            if (FIOCmb.SelectedValue == null)
                sb.AppendLine("ФИО пусто");
            if (StatusCmb.SelectedValue == null)
                sb.AppendLine("Статус пусто");
            if (Date_of_regCal.Text == "")
                sb.AppendLine("Дата пусто");

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                return;
            }

            try
            {
                Registration regisration = new Registration();
                var curFIO = FIOCmb.SelectedValue as Model.Information;
                regisration.FIO = curFIO.FIO;

                var curStatus = StatusCmb.SelectedItem as Model.Information;
                regisration.Status = curStatus.Status;

                var curDoc = DocCmb.SelectedItem as Doctors;
                regisration.Doctor = curDoc.FIO;

                var curSpecDoc = SpecDocCmb.SelectedItem as Doctors;
                regisration.SpecDoc = curSpecDoc.Specification;

                regisration.Room = KabTxb.Text;
                regisration.TypeOfTarget = TypeOfTargetTxb.Text;

                regisration.DateReg = Date_of_regCal.SelectedDate.Value;

                AppData.db.Registration.Add(regisration);
                AppData.db.SaveChanges();
                MessageBox.Show("Запись запланирована");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }
        }

        private void GoBa_Btn_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
            this.Close();
        }
    }
}
