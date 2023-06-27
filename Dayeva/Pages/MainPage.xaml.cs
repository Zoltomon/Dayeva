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
using Dayeva.Classes;
using System.Windows.Shapes;
using Dayeva.Pages.POST;
using Microsoft.EntityFrameworkCore;
using Dayeva.Models;

namespace Dayeva.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private int _role;
        public MainPage(int role)
        {
            InitializeComponent();
            _role = role;
            if(role == 1)
            {
                DataGridButton.Visibility = Visibility.Visible;
                BtnApplic.Visibility = Visibility.Visible;
                BtnPostProduct.Visibility = Visibility.Visible;
            }
            if(role == 2)
            {
                DataGridButton.Visibility = Visibility.Collapsed;
                BtnApplic.Visibility = Visibility.Collapsed;
                BtnPostProduct.Visibility = Visibility.Visible;
            }
            try
            {
                DataGridProduct.ItemsSource = ConnectClass.connect.ProductAuctions.Where(x=>x.StatusId == 1).Include(x => x.Status).Include(x => x.PersonalData).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var productAuction = button.DataContext as ProductAuction;
                var priceEndTextBox = button.FindName("TxbPriceEnd") as TextBox;
                productAuction.PriceEnd = priceEndTextBox.Text;
                ConnectClass.connect.SaveChanges();
                Navigation.controlFrame.Navigate(new MainPage(_role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                var productAuction = button.DataContext as ProductAuction;
                ConnectClass.connect.ProductAuctions.Remove(productAuction);
                ConnectClass.connect.SaveChanges();
                Navigation.controlFrame.Navigate(new MainPage(_role));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.controlFrame.Navigate(new LoginPage());
        }

        private void BtnPostProduct_Click(object sender, RoutedEventArgs e)
        {
            var personal = ConnectClass.connect.PersonalData.FirstOrDefault();
            ProductAuctionWindow newWindow = new ProductAuctionWindow(personal);
            newWindow.ShowDialog();
        }

        private void BtnApplic_Click(object sender, RoutedEventArgs e)
        {
            Navigation.controlFrame.Navigate(new ApplicPage());
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridProduct.ItemsSource = ConnectClass.connect.ProductAuctions.Include(x => x.Status).Include(x => x.PersonalData).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
