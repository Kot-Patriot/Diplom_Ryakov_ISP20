using Avtorizaciya;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
using Word = Microsoft.Office.Interop.Word;

namespace Приложушечка
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        MedTest_Entities db = new MedTest_Entities();
        public Window2()
        {
            InitializeComponent();
            if (MainWindow.Globals.Role == 1)
            {
                Add1.Visibility = Visibility.Visible;
                Edit1.Visibility = Visibility.Visible;
                Rem1.Visibility = Visibility.Visible;
            }
            else
            {
                Add1.Visibility = Visibility.Collapsed;
                Edit1.Visibility = Visibility.Collapsed;
                Rem1.Visibility = Visibility.Collapsed;
            }
        }

        public void UpdateTable()
        {
            UsersGrid.ItemsSource = db.Doctors.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
            this.Close();
        }

        private void prikazy_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
            this.Close();
        }

        private void prikazy1_Click(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            win4.Show();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.Doctors.ToList();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddUser win8 = new AddUser();
            win8.Show();
            this.Close();
        }

        private void Add_Btn_Click11(object sender, RoutedEventArgs e)
        {
            if (UsersGrid.SelectedItem != null)
            {
                Edit2 edit= new Edit2(UsersGrid.SelectedItem as Doctors);
                edit.ShowDialog();
                AppData.db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Выбирете пользователя");
            }
            MedTest_Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить врача?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrectDoc1 = UsersGrid.SelectedItem as Doctors;
                AppData.db.Doctors.Remove(CurrectDoc1);
                AppData.db.SaveChanges();

                UsersGrid.ItemsSource = AppData.db.Doctors.ToList();
                MessageBox.Show("Успешно");
            }
        }

        private void HyHitler(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Export_Clik1(object sender, RoutedEventArgs e)
        {
            var allRec1 = MedTest_Entities.GetContext().Doctors.ToList();
            var allus = MedTest_Entities.GetContext().Doctors.ToList();

            var appl1 = new Word.Application();

            Word.Document document = appl1.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Отчёт о пользователях";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRec1.Count() + 1, 4);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "ID";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "ФИО";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Спецификация";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Отдел";
            //cellRange = paymentsTable.Cell(1, 5).Range;
            //cellRange.Text = "День рождения";


            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRec1.Count(); i++)
            {
                var currentCategory = allRec1[i];
                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = Convert.ToString(currentCategory.ID);
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = Convert.ToString(currentCategory.FIO);

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = Convert.ToString(currentCategory.Specification);

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = Convert.ToString(currentCategory.Otdel);

                //cellRange = paymentsTable.Cell(i + 2, 5).Range;
                //cellRange.Text = Convert.ToString(currentCategory.Birthday);

            }

            appl1.Visible = true;
        }
    }
}
