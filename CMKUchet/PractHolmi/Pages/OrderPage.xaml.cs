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
    public partial class OrderPage : System.Windows.Controls.Page
    {
        public OrderPage()
        {
            InitializeComponent();
            if (App.Mode == 1)
            {
                order = new Models.Order();
                //BtnDelete.IsEnabled = false;
                Title = "Добавить товар";
            }
            if (App.Mode == 2 && App.currentOrder != null)
            {
                Title = "Редактировать товар";
                order = App.DB.Order.FirstOrDefault(x => x.id == App.currentOrder.id);
            }
            DataContext = order;
            DGrid.ItemsSource = CMKUchetEntities.GetContext().Order.ToList();
        

            var allTypes = CMKUchetEntities.GetContext().Status.ToList();
            allTypes.Insert(0, new Status { name = "Все статусы" });

            var Filt = new List<string>() { "Все статусы" };
            Filt.AddRange(CMKUchetEntities.GetContext().Status.Select(c => c.name).ToList());
            FiltComboBox.ItemsSource = Filt;
            FiltComboBox.SelectedIndex = 0;

            SortComboBox.Items.Add("Без сортировки");
            SortComboBox.Items.Add("ФИО клиента (по возрастанию)");
            SortComboBox.Items.Add("ФИО клиента (по убыванию)");
            SortComboBox.SelectedIndex = 0;

            orders = new List<Order>();
        }
        List<Order> orders;
        private Models.Order order;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.Mode = 1;
            Manager.MainFrame.Navigate(new AddOrderPage());
        }

        private void DGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CMKUchetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGrid.ItemsSource = CMKUchetEntities.GetContext().Order.Where(x => x.idClient == App.currentUser.id).ToList();
            Update(SortComboBox.Text, FiltComboBox.Text, SearchBox.Text);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var productsForRemoving = DGrid.SelectedItems.Cast<Order>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {productsForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CMKUchetEntities.GetContext().Order.RemoveRange(productsForRemoving);
                    CMKUchetEntities.GetContext().SaveChanges();
                    DGrid.ItemsSource = CMKUchetEntities.GetContext().Order.ToList();
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
            var data = CMKUchetEntities.GetContext().Order.ToList();

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
            {
                data = data.Where(p => p.name.ToLower().Contains(search.ToLower())).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filt) && !string.IsNullOrEmpty(filt))
            {
                if (filt != "Все статусы")
                {
                    data = data.Where(c => c.Status.name == filt).ToList();
                }
            }
            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrWhiteSpace(sort))
            {
                if (sort == "Без сортировки")
                {
                    data = data.OrderBy(c => c.id).ToList();
                }
                if (sort == "ФИО клиента (по возрастанию)")
                {
                    data = data.OrderBy(c => c.Client.Fullname).ToList();
                }
                if (sort == "ФИО клиента (по убыванию)")
                {
                    data = data.OrderByDescending(c => c.Client.Fullname).ToList();
                }
            }

            DGrid.ItemsSource = data.Where(x => x.idClient == App.currentUser.id).ToList();
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
            App.currentOrder = (Models.Order)DGrid.SelectedItem;
            Manager.MainFrame.Navigate(new AddOrderPage()); 
        }

        private void DGrid_SelectionChanged()
        {

        }

        private void BtnOthcet_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
