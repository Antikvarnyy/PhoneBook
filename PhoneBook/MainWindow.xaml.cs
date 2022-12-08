using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PhoneBook
{
    public partial class MainWindow : Window
    {
        int f = 0;
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>()
            {
                new Contact{ImagePath="Recources/unknown.png", Name="Andreyey Masalov",Num="0959874404"},
                new Contact{ImagePath="Recources/unknown.png", Name="Alexey Vlasenko",Num="0508004570"},
                new Contact{ImagePath="Recources/unknown.png", Name="Vito Skaletto",Num="0661155368"},
                new Contact{ImagePath="Recources/unknown.png", Name="Lina Moroz",Num="0604942911"},
                new Contact{ImagePath="Recources/unknown.png", Name="Andzhey Sapkovskiy",Num="0956842344"},
                new Contact{ImagePath="Recources/unknown.png", Name="Irina Oberemok",Num="0956573997"},
                new Contact{ImagePath="Recources/unknown.png", Name="Tamara Lyashko",Num="0501446675"},
                new Contact{ImagePath="Recources/unknown.png", Name="Yurik Parshev",Num="0998691454"},
                new Contact{ImagePath="Recources/unknown.png", Name="Yura Karas`",Num="0905742273"},
                new Contact{ImagePath="Recources/unknown.png", Name="Alexey Shevtsov",Num="0608480193"},
                new Contact{ImagePath="Recources/unknown.png", Name="Natasha Romanov",Num="0665395164"},
                new Contact{ImagePath="Recources/unknown.png", Name="Bruss Banner",Num="0504879913"},
                new Contact{ImagePath="Recources/unknown.png", Name="Danil Zaichenko",Num="0682760368"},
                new Contact{ImagePath="Recources/unknown.png", Name="Yuriy Kisil",Num="0952283575"},
                new Contact{ImagePath="Recources/unknown.png", Name="Zhenya Dvorechenets",Num="0507263556"},
                new Contact{ImagePath="Recources/unknown.png", Name="Slim Shady",Num="0952995393"},
            };
            ContactList.ItemsSource = Contacts;
        }
        public class Contact
        {

            public string Name { get; set; }
            public string ImagePath { get; set; }
            public string Num { get; set; }
        }

        private void SearchClick(object sender, MouseButtonEventArgs e)
        {
            if (f == 0)
            {
                f++;
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black;
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            Hide();
            addWindow.ShowDialog();
            while(Data.NameValue == "") { }
            Contacts.Add(new Contact { ImagePath = "Recources/unknown.png", Name = Data.NameValue, Num = Data.NumValue });
            Data.NameValue = "";
            Data.NumValue = "";
            Show();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            if (ContactList.SelectedItem as Contact == null)
            {
                MessageBox.Show("Select contact first", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Hide();
            int i = ContactList.SelectedIndex;
            Contact c = ContactList.SelectedItem as Contact;            
            Data.NameValue = c.Name;
            Data.NumValue = c.Num;
            editWindow.ShowDialog();
            while(Data.NumValue == c.Num && Data.NameValue == c.Name) { }
            if (Data.NumValue == "")
            {
                Show();
                return;
            }
            Contacts.RemoveAt(i);
            Contacts.Insert(i,new Contact { ImagePath = "Recources/unknown.png", Name = Data.NameValue, Num = Data.NumValue });
            Show();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (ContactList.SelectedItem as Contact == null)
            {
                MessageBox.Show("Select contact first", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            int i = ContactList.SelectedIndex;
            MessageBoxResult result = MessageBox.Show("Delete selected contact?","Question",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                return;
            Contacts.RemoveAt(i);
        }
    }
}
