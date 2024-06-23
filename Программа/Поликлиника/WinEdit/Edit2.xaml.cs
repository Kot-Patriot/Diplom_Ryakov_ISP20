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
    /// Логика взаимодействия для Edit2.xaml
    /// </summary>
    public partial class Edit2 : Window
    {
        public Doctors currectUser = new Doctors();
        MedTest_Entities db = new MedTest_Entities();
        public Edit2(Doctors selectedUser)
        {
            currectUser = selectedUser;
            InitializeComponent();
            DataContext = currectUser;
            FioTxb.Text = currectUser.FIO;
            SpecTxb.Text = currectUser.Specification;
            OtdelTxb.Text = currectUser.Otdel;
            DateTxb.Text = Convert.ToString(currectUser.Birthday);

        }
        private void Update_Btn(object sender, RoutedEventArgs e)
        {
            //db.SaveChanges();
            //MedTestEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно изменены");
            Close();
        }
        private void Cancel_Btn(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
