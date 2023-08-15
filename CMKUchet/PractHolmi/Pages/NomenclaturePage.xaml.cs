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

namespace ProkatHolm.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class NomenclaturePage : Page
    {
        public NomenclaturePage()
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
        }

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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                dialog.PrintVisual(DGrid, "Печать отчета");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Печать отчета", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
    }
}
