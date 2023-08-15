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

namespace ProkatHolm.Pages
{
    /// <summary>
    /// Логика взаимодействия для HistoryAuth.xaml
    /// </summary>
    public partial class HistoryAuth : Page
    {
        public HistoryAuth()
        {
            InitializeComponent();
            List<string> filt = new List<string>(CMKUchetEntities.GetContext().User.Select(x => x.login).ToList());
            FiltComboBox.ItemsSource = filt;
            FiltComboBox.SelectedIndex = 0;
        }

        private void GetData(string sort = "", string filter = "")
        {
            var data = App.DB.AuthHistory.ToList();
            if (filter != "Все типы")
            {
                data = data.Where(c => c.User.login ==
               filter).ToList();
            }
            if (SortComboBox.SelectedIndex == 0)
                data = data.OrderBy(x => x.DateTime).ToList();
            if (SortComboBox.SelectedIndex == 1)
                data = data.OrderByDescending(x => x.DateTime).ToList();
            DGrid.ItemsSource = data;

        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(
           ((ComboBoxItem)SortComboBox.SelectedItem).Content.ToString(),
           FiltComboBox.Text);
        }

        private void FiltComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetData(
           SortComboBox.Text,
          (FiltComboBox.SelectedItem).ToString());
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void DGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CMKUchetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGrid.ItemsSource = CMKUchetEntities.GetContext().AuthHistory.ToList();
        }
    }
}
