using Microsoft.Office.Interop.Word;
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
    /// Логика взаимодействия для Edit4.xaml
    /// </summary>
    public partial class Edit4 : System.Windows.Window
    {
        public Raspis currectInfo = new Raspis();
        MedTest_Entities db = new MedTest_Entities();
        public Edit4(Model.Raspis selectInfo)
        {
            currectInfo = selectInfo;
            InitializeComponent();
            DataContext = currectInfo;
            DoctorTxb.Text = currectInfo.FIODoc;
            SpecDocTxb.Text = currectInfo.SpecDoc;
            RoomTxb.Text = currectInfo.Room;
            Date_of_beginCal.Text = Convert.ToString(currectInfo.BEginOf);
            Date_of_endCal.Text = Convert.ToString(currectInfo.EndOF);
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
