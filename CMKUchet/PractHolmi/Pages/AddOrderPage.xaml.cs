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
using System.Data.Entity.Validation;
using System.Diagnostics;
namespace ProkatHolm.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private Order _currentOrder = new Order();

        public AddOrderPage()
        {
            InitializeComponent();
            if (App.Mode == 1)
            {
                order = new Models.Order();
                Title = "Добавить заказ";
            }
            if (App.Mode == 2 && App.currentOrder != null)
            {
                Title = "Редактировать заказ";
                order = App.DB.Order.FirstOrDefault(x => x.id == App.currentOrder.id);
            }
            DataContext = order;
            StatusCB.ItemsSource = App.DB.Status.ToList();
            ClientCB.ItemsSource = App.DB.Client.ToList();
            NameCB.ItemsSource = App.DB.Nomenclature.ToList();
          
            VidprodCB.ItemsSource = App.DB.Nomenclature.ToList();
            VidproizvCB.ItemsSource = App.DB.Nomenclature.ToList();
            CentCB.ItemsSource = App.DB.Order.ToList();
        }
        private Models.Order order;
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (App.Mode == 1)
            {
                try
                {
                    App.DB.Order.Add(order);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());


                }

            }
            if (App.Mode == 2)
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            App.Mode = 1;
            NavigationService.Navigate(new AddClientPage());
        }
    }
}
