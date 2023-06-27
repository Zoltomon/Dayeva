using Dayeva.Classes;
using Dayeva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TxbPass.Text != "" && TxbLog.Text != "")
                {
                    if (TxbPass.Text == TxbCopyPass.Text)
                    {
                        User newUser = new User()
                        {
                            Login = TxbLog.Text,
                            Password = TxbPass.Text,
                            RoleId = 2,
                        };
                        PersonalDatum personalDatum = new PersonalDatum()
                        {
                            Name = TxbName.Text,
                            Surname = TxbSur.Text,
                            Patronomic = TxbPatr.Text,
                            SeriesPassport = TxbSerPassport.Text,
                            NumberPassport = TxbNumPassport.Text,
                            User = newUser
                        };
                        ConnectClass.connect.PersonalData.Add(personalDatum);
                        ConnectClass.connect.SaveChanges();
                        MessageBox.Show("Сохранено!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите данные");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.controlFrame.GoBack();
        }
    }
}
