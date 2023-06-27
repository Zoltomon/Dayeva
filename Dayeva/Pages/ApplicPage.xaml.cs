using Dayeva.Classes;
using Dayeva.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Dayeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicPage.xaml
    /// </summary>
    public partial class ApplicPage : Page
    {
        public ApplicPage()
        {
            InitializeComponent();
            DataGridStatus.ItemsSource = ConnectClass.connect.ProductAuctions.Where(x=>x.StatusId == 2).Include(x=>x.Status).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.controlFrame.GoBack();
        }


        private void BtnEditStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRow = (ProductAuction)DataGridStatus.SelectedItem;
                selectedRow.StatusId = 1;
                ConnectClass.connect.SaveChanges();
                DataGridStatus.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
