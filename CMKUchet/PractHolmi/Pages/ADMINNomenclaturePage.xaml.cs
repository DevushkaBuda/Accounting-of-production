using ProkatHolm.Classes;
using ProkatHolm.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.IO;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace ProkatHolm.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class ADMINNomenclaturePage : System.Windows.Controls.Page
    {
        public ADMINNomenclaturePage()
        {
            InitializeComponent();

            DGrid.ItemsSource = CMKUchetEntities.GetContext().Nomenclature.ToList();

            var allTypes = CMKUchetEntities.GetContext().Nomenclature.ToList();
            allTypes.Insert(0, new Nomenclature { Process_type = "Все производство" });

            var Filt = new List<string>() { "Все производство" };
            Filt.AddRange(CMKUchetEntities.GetContext().Nomenclature.Select(c => c.Process_type).ToList());
            FiltComboBox.ItemsSource = Filt;
            FiltComboBox.SelectedIndex = 0;

            SortComboBox.Items.Add("Без сортировки");
            SortComboBox.Items.Add("Наименование (по возрастанию)");
            SortComboBox.Items.Add("Наименование (по убыванию)");
            SortComboBox.SelectedIndex = 0;

            nomenclatures = new List<Nomenclature>();
        }
        List<Nomenclature> nomenclatures;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.Mode = 1;
            Manager.MainFrame.Navigate(new AddNomenclaturePage());
        }

        private void DGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CMKUchetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGrid.ItemsSource = CMKUchetEntities.GetContext().Nomenclature.ToList();
            Update(SortComboBox.Text, FiltComboBox.Text, SearchBox.Text);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var productsForRemoving = DGrid.SelectedItems.Cast<Nomenclature>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productsForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CMKUchetEntities.GetContext().Nomenclature.RemoveRange(productsForRemoving);
                    CMKUchetEntities.GetContext().SaveChanges();
                    DGrid.ItemsSource = CMKUchetEntities.GetContext().Nomenclature.ToList();
                    MessageBox.Show("Данные удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Update(string sort = "", string filt = "", string search = "")
        {
            var data = CMKUchetEntities.GetContext().Nomenclature.ToList();

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                data = data.Where(p => p.name.ToLower().Contains(search.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filt) && !string.IsNullOrEmpty(filt))
            {
                if (filt != "Все производство")
                {
                    data = data.Where(c => c.Process_type == filt).ToList();
                }
            }
            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrWhiteSpace(sort))
            {
                if (sort == "Без сортировки")
                {
                    data = data.OrderBy(c => c.id).ToList();
                }
                if (sort == "Наименование (по возрастанию)")
                {
                    data = data.OrderBy(c => c.name).ToList();
                }
                if (sort == "Наименование (по убыванию)")
                {
                    data = data.OrderByDescending(c => c.name).ToList();
                }
            }

            DGrid.ItemsSource = data;
            nomenclatures = data;
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update((SortComboBox.SelectedItem as String).ToString(), FiltComboBox.Text, SearchBox.Text);
        }

        private void FiltComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update(SortComboBox.Text, (FiltComboBox.SelectedItem as String).ToString(), SearchBox.Text);
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            x.Text = "";
            Update(SortComboBox.Text, FiltComboBox.Text, SearchBox.Text);
            if (DGrid.Items.Count == 0)
            {
                x.Text = "По данному запросу ничего не найдено";
            }
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                x.Text = "";
                Update(SortComboBox.Text, FiltComboBox.Text, SearchBox.Text);
                if (DGrid.Items.Count == 0)
                {
                    x.Text = "По данному запросу ничего не найдено";
                }
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
            x.Text = "";
            Update(SortComboBox.Text, FiltComboBox.Text, SearchBox.Text);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void DGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            App.Mode = 2;
            App.currentNomenclature = (Models.Nomenclature)DGrid.SelectedItem;
            Manager.MainFrame.Navigate(new AddNomenclaturePage());
        }

        private void DGrid_SelectionChanged()
        {

        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {
            
                try
            {
                Word._Application wApp = new Word.Application();
                Word._Document wDoc = wApp.Documents.Add();
                wApp.Visible = true;
                wDoc.Activate();
                var ProductParagraph = wDoc.Content.Paragraphs.Add();
                //ProductParagraph.Range.Text = $"День недели:\t{dayOfTheWeek.Name}\n" + $"Статус:\t{shedule.Status}\n" + $"Время работы:\t{shedule.Duration}\n" + $"Цех:\t{shedule.Cabinet}\n";
                Word.Table wTable = wDoc.Tables.Add((Microsoft.Office.Interop.Word.Range)ProductParagraph.Range,
                nomenclatures.Count + 1, 4, Word.WdDefaultTableBehavior.wdWord9TableBehavior);
                wTable.Cell(1, 1).Range.Text = "Код Продукции";
                wTable.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wTable.Cell(1, 2).Range.Text = "Наименование";
                wTable.Cell(1, 2).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wTable.Cell(1, 3).Range.Text = "Вид продукции";
                wTable.Cell(1, 3).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                wTable.Cell(1, 4).Range.Text = "Вид производства";
                wTable.Cell(1, 4).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int countRow = 2;
                foreach (var item in nomenclatures)
                {
                    wTable.Cell(countRow, 1).Range.Text = item.id.ToString();
                    wTable.Cell(countRow, 1).Range.Paragraphs.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wTable.Cell(countRow, 2).Range.Text = item.name.ToString();
                    wTable.Cell(countRow, 2).Range.Paragraphs.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wTable.Cell(countRow, 3).Range.Text = item.product_type.ToString();
                    wTable.Cell(countRow, 3).Range.Paragraphs.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    wTable.Cell(countRow, 4).Range.Text = item.Process_type.ToString();
                    wTable.Cell(countRow, 4).Range.Paragraphs.Alignment =
                    Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    countRow++;
                }
                /*Word.Chart wChart;
                Word.InlineShape inlineShape;
                inlineShape = wDoc.InlineShapes.AddChart(Microsoft.Office.Core.XlChartType.xlColumnClustered, ProductParagraph.Range);
                wChart = inlineShape.Chart;

                dynamic chartWB = wChart.ChartData.Workbook;
                dynamic chartTable = chartWB.Sheets[1].ListObjects("Таблица1"); chartTable.DataBodyRange.ClearContents();
                dynamic chartRange = chartTable.Range.Resize[2, dayOfTheWeek.Schedule.Count + 1];
                chartTable.Resize(chartRange);
                int countCol = 2;
                foreach (var item in dayOfTheWeek.Schedule)
                {
                    chartRange.Cells[1, countCol] = item.Duration.ToString();
                    chartRange.Cells[2, countCol] = item.Id_Profile.ToString();
                    countCol++;
                }
                */
                wDoc.SaveAs2($@"{Environment.CurrentDirectory}\{DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss")}.docx");
            }

            catch
            {
                MessageBox.Show($"Ошибка");
            }
            var process = System.Diagnostics.Process.GetProcessesByName("Excel");
            foreach (var p in process)
            {
                if (!string.IsNullOrEmpty(p.ProcessName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }

            }
        }
    }
}
