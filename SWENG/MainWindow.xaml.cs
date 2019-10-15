using MahApps.Metro.Controls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWENG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static MainWindow Main_Window; 

        public MainWindow()
        {
            InitializeComponent();
            Main_Window = this;

            String[] data = System.IO.File.ReadAllLines(@"..\..\..\db1.txt");
            String[] name = System.IO.File.ReadAllLines(@"..\..\..\db2.txt");
            String[] transfers = System.IO.File.ReadAllLines(@"..\..\..\db4.txt");

            for (int i = 0; i < name.Length; i++)
            {
                Namelabel.Content = name[i];
                var yourtext = name[i];
                var firstcharofstring = System.Globalization.StringInfo.GetNextTextElement(yourtext, 0);
                ShortNamelabel.Content = firstcharofstring;
            }

        }

        #region Button_Clicks
        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new HomePage());
        }

        private void TransfersMenu_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new TransfersPage());
        }

        private void FamilyMenu_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new FamilyPage());
        }

        private void HistoryMenu_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new HistoryPage());
        }

        private void SettingsMenu_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new SettingsPage());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            System.IO.File.WriteAllText(@"..\..\..\db2.txt", String.Empty);

            LoginWindow window = new LoginWindow();
            window.Show();
            this.Close();
        }

        bool StateClosed = false;

        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (StateClosed)
            {
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
            }

            StateClosed = !StateClosed;
        }
        #endregion

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"..\..\..\db2.txt", String.Empty);
        }
    }
}
