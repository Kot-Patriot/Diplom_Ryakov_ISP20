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
    /// Логика взаимодействия для Edit1.xaml
    /// </summary>
    public partial class Edit1 : Window
    {
        public Information currectInfo = new Information();
        MedTest_Entities db = new MedTest_Entities();
        public Edit1(Information selectInfo)
        {
            currectInfo= selectInfo;
            InitializeComponent();
            DataContext = currectInfo;
            FIOTxb.Text = currectInfo.FIO;
            Number_of_baseTxb.Text = Convert.ToString(currectInfo.Gender);
            DataReciveCal.Text = Convert.ToString(currectInfo.DateRecive);
            A_brief_historyTxb.Text = currectInfo.History;
            StatusTxb.Text = currectInfo.Status;
            Date_of_birthCal.Text = Convert.ToString(currectInfo.Birthday);
        }

        private void UpdateBtn1(object sender, RoutedEventArgs e)
        {
            //db.SaveChanges();
            //MedTestEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно изменены");
            Close();
        }

        private void CancelBtn1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
