﻿using ProkatHolm.Classes;
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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date = new DateTime(0, 0);

        public ManagerPage()
        {
            InitializeComponent();

            UserTB.Text = CMKUchetEntities.CurrentAuth.name;
            RoleTB.Text = "(" + CMKUchetEntities.CurrentAuth.Role.name + ")";

            

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            date = date.AddSeconds(1);
            TimeTB.Text = date.ToString("HH:mm:ss");

            if (TimeTB.Text == "00:05:00")
            {
                MessageBox.Show("Время сеанса подходит к концу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TimeTB.Text == "00:10:00")
            {
                timer.Stop();
                App.IsGone = true;
                Manager.MainFrame.Navigate(new LoginPage());
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new LoginPage());
        }

        private void BtnPlaceAnOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OrderPage());
        }

        private void BtnAcceptProducts_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NomenclaturePage());
        }

        private void BtnPlaceAnOrder2_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrderPage());
        }
    }
}
