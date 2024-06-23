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
    /// Логика взаимодействия для Edit3.xaml
    /// </summary>
    public partial class Edit3 : Window
    {
        public Registration currectInfo = new Registration();
        MedTest_Entities db = new MedTest_Entities();
        public Edit3(Model.Registration selectInfo)
        {
            currectInfo = selectInfo;
            InitializeComponent();
            DataContext = currectInfo;
            FIOTxb.Text = currectInfo.FIO;
            StatusTxb.Text = currectInfo.Status;
            DoctorTxb.Text = currectInfo.Doctor;
            SpecDocTxb.Text = currectInfo.SpecDoc;
            RoomTxb.Text = Convert.ToString(currectInfo.Room);
            TypeOFTargetTxb.Text = currectInfo.TypeOfTarget;
            Date_of_regCal.Text = Convert.ToString(currectInfo.DateReg);

        }

        private void UpdateBtn(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            //MedTest_Entities.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно изменены");
            Close();
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
