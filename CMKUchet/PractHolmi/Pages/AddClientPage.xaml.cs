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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();
            if (App.Mode == 1)
            {
                client = new Models.Client();
                //BtnDelete.IsEnabled = false;
                Title = "Добавить агента";
            }
            if (App.Mode == 2 && App.currentClient != null)
            {
                Title = "Редактировать агента";
                client = App.DB.Client.FirstOrDefault(x => x.id == App.currentClient.id);
            }
            DataContext = client;
        }
        private Models.Client client;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (App.Mode == 1)
            {
                try
                {
                    App.DB.Client.Add(client);
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
