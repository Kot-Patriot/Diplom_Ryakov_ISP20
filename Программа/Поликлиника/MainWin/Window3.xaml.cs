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
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;
using Avtorizaciya;

namespace Приложушечка
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : System.Windows.Window
    {
        MedTest_Entities db = new MedTest_Entities();
        public Window3()
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

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Window6 win6 = new Window6();
            win6.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.Registration.ToList();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var allZep = MedTest_Entities.GetContext().Registration.ToList();
            var allpac = MedTest_Entities.GetContext().Registration.ToList();

            var appl = new Word.Application();

            Word.Document document = appl.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчёт о записях клиентов к врачам";
            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allZep.Count() + 1, 8);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "ID";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "ФИО пациента";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Статус пациента";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Дата ФИО врача";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Тип врача";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Кабинет";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Тип обращения";
            cellRange = paymentsTable.Cell(1, 8).Range;
            cellRange.Text = "Дата приёма";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allZep.Count(); i++)
            {
                var currentCategory = allZep[i];
                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = Convert.ToString(currentCategory.ID);
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = Convert.ToString(currentCategory.FIO);

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = Convert.ToString(currentCategory.Status);

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = Convert.ToString(currentCategory.Doctor);

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = Convert.ToString(currentCategory.SpecDoc);

                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = Convert.ToString(currentCategory.Room);

                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = Convert.ToString(currentCategory.TypeOfTarget);

                cellRange = paymentsTable.Cell(i + 2, 8).Range;
                cellRange.Text = Convert.ToString(currentCategory.DateReg.ToString("dd.MM.yyyy"));
            }

            appl.Visible = true;
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddReg win8 = new AddReg();
            win8.Show();
            this.Close();
        }

        private void Edit_btn_click(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                Edit3 edit = new Edit3(UsersGrid.SelectedValue as Registration);
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
                var CurrectPac = UsersGrid.SelectedItem as Registration;
                AppData.db.Registration.Remove(CurrectPac);
                AppData.db.SaveChanges();

                UsersGrid.ItemsSource = AppData.db.Registration.ToList();
                MessageBox.Show("Успешно");
            }
        }
    }
}
