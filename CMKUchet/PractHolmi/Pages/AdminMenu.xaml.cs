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
using System.Windows.Shapes;

namespace otdel_kadrov
{
    /// <summary>
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        Database1Entities db = new Database1Entities();
        public AdminMenu()
        {
            InitializeComponent();
            dgWorker.ItemsSource = db.Worker.ToList();
            dgStudents.ItemsSource = db.Students.ToList();
            dgNewWorkers.ItemsSource = db.NewWorkers.ToList();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.ItemsSource = db.Answer.ToList();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex > -1)
            {
                int id = Convert.ToInt32(cb.Tag);
                if (db.NewWorkers.Where(x => x.ID == id).Count() > 0)
                {
                    NewWorkers nW = db.NewWorkers.Where(x => x.ID == id).FirstOrDefault();
                    nW.Answer_id = Convert.ToInt32(cb.SelectedValue);
                    db.SaveChanges();
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                MainWindow mW = new MainWindow();
                mW.Show();
                Close();
            }
        }
    }
}
