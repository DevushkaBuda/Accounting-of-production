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
    /// Логика взаимодействия для AddNomenclaturePage.xaml
    /// </summary>
    public partial class AddNomenclaturePage : Page
    {
        public AddNomenclaturePage()
        {
            InitializeComponent();
            if (App.Mode == 1)
            {
                nomenclature = new Models.Nomenclature();
                BtnDel.IsEnabled = false;
                Title = "Добавить агента";
            }
            if (App.Mode == 2 && App.currentNomenclature != null)
            {
                Title = "Редактировать агента";
                nomenclature = App.DB.Nomenclature.FirstOrDefault(x => x.id == App.currentNomenclature.id);
            }
            DataContext = nomenclature;
            VidprodCB.ItemsSource = App.DB.Nomenclature.ToList();
            VidproizvCB.ItemsSource = App.DB.Nomenclature.ToList();
            NameCB.ItemsSource = App.DB.Nomenclature.ToList();
        }
        private Models.Nomenclature nomenclature;
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (App.Mode == 1)
            {
               try
                {
                    App.DB.Nomenclature.Add(nomenclature);
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

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить запись ? ", "Внимание!", MessageBoxButton.YesNo,
               MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                App.DB.Nomenclature.Remove(App.currentNomenclature);
                App.DB.SaveChanges();
                MessageBox.Show("Данные удалены");
                NavigationService.GoBack();
            }
        }
    }
}
