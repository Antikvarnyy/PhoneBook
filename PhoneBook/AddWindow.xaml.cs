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

namespace PhoneBook
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddContactClick(object sender, RoutedEventArgs e)
        {
            foreach(char a in NumBox.Text)
            {
                if(a<'0' || a > '9')
                {
                    MessageBox.Show("Number of new contact may contain only digits!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    NumBox.Text = "";
                    return;
                }

            }
            if(NameBox.Text.Length > 0 && NumBox.Text.Length == 0)
            {
                MessageBox.Show("You have to enter number of new contact!", "Info",MessageBoxButton.OK, MessageBoxImage.Information);
            }else if(NameBox.Text.Length == 0 && NumBox.Text.Length > 0)
            {
                MessageBox.Show("You have to enter name of new contact!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Data.NameValue = NameBox.Text;
                Data.NumValue = NumBox.Text;
                Close();
            }
        }
    }
}
