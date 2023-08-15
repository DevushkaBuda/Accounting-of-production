using ProkatHolm.Classes;
using ProkatHolm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
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
    /// Логика взаимодействия для AddProcessPage.xaml
    /// </summary>
    public partial class AddProcessPage : Page
    {
        public AddProcessPage()
        {
            InitializeComponent();
            if (App.Mode == 1)
            {
                process = new Models.Process();
                BtnDel.IsEnabled = false;
                Title = "Добавить товар";
            }
            if (App.Mode == 2 && App.currentOrder != null)
            {
                Title = "Редактировать товар";
                order = App.DB.Order.FirstOrDefault(x => x.id == App.currentOrder.id);
            }
            DataContext = process;
            DataContext = order;
            
            NameCB.ItemsSource = App.DB.Order.ToList();
            ShopCB.ItemsSource = App.DB.Shop.ToList();
        }
        private Models.Process process;
        private Models.Order order;

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (App.Mode == 2)
            {
                try
                {

                    App.IdSh = App.DB.Shop.FirstOrDefault(x => x.name == ShopCB.Text).id;
                    (App.IdSchet = DateTime.Parse(DClosing.Text).DayOfYear - DateTime.Parse(App.IdDateOp.ToString()).DayOfYear).ToString();
                    App.IdDateOp = DateTime.Now.Date;
                    Process process = new Process

                    {
                        date_creation = App.IdDateOp,
                        time_creation = DateTime.Now.TimeOfDay,
                        idShop = App.IdSh,
                        idOrder = App.currentOrder.id,
                        Process_time = App.IdSchet,

                    };

                    App.DB.Process.Add(process);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

            }
            if (App.Mode == 1)
            {
                try
                {
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить запись ? ", "Внимание!", MessageBoxButton.YesNo,
               MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                App.DB.Process.Remove(App.currentProcess);
                App.DB.SaveChanges();
                MessageBox.Show("Данные удалены");
                NavigationService.GoBack();
            }
        }

        private void DOpen_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnTime_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DClosing_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
