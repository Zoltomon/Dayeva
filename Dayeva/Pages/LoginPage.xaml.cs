using Dayeva.Classes;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = ConnectClass.connect.PersonalData.Include(x=>x.User.Role).Include(x=>x.User).FirstOrDefault(x=>x.User.Login == TxbLog.Text && x.User.Password == TxbPass.Text);
                if (data != null)
                {
                    switch (data.User.RoleId) {
                        case 1:
                            Navigation.controlFrame.Navigate(new MainPage(data.User.RoleId));
                            break;
                        case 2:
                            Navigation.controlFrame.Navigate(new MainPage(data.User.RoleId));
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Нет такого аккаунта");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Navigation.controlFrame.Navigate(new RegPage());
        }
    }
}
