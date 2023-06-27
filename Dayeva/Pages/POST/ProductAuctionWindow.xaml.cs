using Dayeva.Classes;
using Dayeva.Models;
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

namespace Dayeva.Pages.POST
{
    /// <summary>
    /// Логика взаимодействия для ProductAuctionWindow.xaml
    /// </summary>
    public partial class ProductAuctionWindow : Window
    {
        private PersonalDatum _personalData;
        public ProductAuctionWindow(PersonalDatum personalData)
        {
            InitializeComponent();
            _personalData = personalData;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductAuction newProduct = new ProductAuction()
                {
                    Name = TxbName.Text,
                    PriceStart = TxbStartPrice.Text,
                    PriceEnd = TxbStartPrice.Text,
                    StatusId = 2,
                    PersonalData = _personalData

                };
                ConnectClass.connect.ProductAuctions.Add(newProduct);
                ConnectClass.connect.SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
