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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            //_NavigationFrame.Navigate(new MainPage());
        }

        private void SettingsMenu_Click(object sender, RoutedEventArgs e)
        {
            //_NavigationFrame.Navigate(new SettingsPage());
        }

        private void MissingMenu_Click(object sender, RoutedEventArgs e)
        {
            //_NavigationFrame.Navigate(new MissingPage());
        }

        private void WrongMenu_Click(object sender, RoutedEventArgs e)
        {
            //_NavigationFrame.Navigate(new WrongPage());
        }

        private void EcnMenu_Click(object sender, RoutedEventArgs e)
        {
            //_NavigationFrame.Navigate(new EcnPage());
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
    }
}
