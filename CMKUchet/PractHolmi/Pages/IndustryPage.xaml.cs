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
using System.Windows.Threading;

namespace ProkatHolm.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class IndustryPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date = new DateTime(0, 0);

        public IndustryPage()
        {
            InitializeComponent();

          

        }

            


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoginPage());
        }

        private void BtnHistory_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HistoryAuth());
        }

        private void BtnShop_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ADMINNomenclaturePage());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Processing_Charts());
        }

        private void BtnProcessOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProcessPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnSklad_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Skald());
        }
    }
}
