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

namespace SWENG
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();

            String[] data = System.IO.File.ReadAllLines(@"..\..\..\db1.txt");
            String[] name = System.IO.File.ReadAllLines(@"..\..\..\db2.txt");
            String[] transfer = System.IO.File.ReadAllLines(@"..\..\..\db4.txt");

            for (int i = 0; i < name.Length; i++)
            {
                Welcomelabel.Content = "Welcome in our software " + name[i];
            }
            Cardlabel.Content = "Your data";

            for (int i = 0; i < data.Length - 2; i++)
            {
                if (data[i].Equals(MainWindow.Main_Window.Namelabel.Content))
                {
                    IDlabel.Content = data[i + 1];
                    BankAccountNumberlabel.Content = data[i + 2];
                }
            }
            for (int i = 0; i < transfer.Length - 4; i++)
            {
                if (IDlabel.Content.Equals(transfer[i]) && BankAccountNumberlabel.Content.Equals(transfer[i + 1]))
                {
                    TransferslistBox.Items.Add(transfer[i] + "\n" + transfer[i + 1] + "\n" + transfer[i + 2] + "\n" + transfer[i + 3] + "\n" + transfer[i + 4] + "\n");
                }
            }
        }
    }
}
