using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace SWENG
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        #region KeyDowns
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }
        #endregion

        #region Button_Clicks
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            String[] adat = System.IO.File.ReadAllLines(@"..\..\..\db1.txt");

            for (int i = 0; i < adat.Length - 3; i++)
            {
                if (IDTextBox.Text == adat[i + 1] && BankAccountNumberTextBox.Text == adat[i + 2] && Encrypt(PasswordTextBox.Text) == adat[i + 3])
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\..\db2.txt", true))
                    {
                        file.WriteLine(adat[i]);
                    }
                    MainWindow window = new MainWindow();
                    window.Show();
                    this.Close();
                    break;
                }
            }

        }
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow window = new SignUpWindow();
            window.Show();
            this.Close();

        }

        #endregion

        #region Encoding
        static string Key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";

        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
        #endregion

        #region Textboxes
        private void IDTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            IDTextBox.Foreground = Brushes.Black;
            if (IDTextBox.Text.Equals("Identifier"))
            {
                IDTextBox.Text = "";
            }
        }
        private void IDTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (IDTextBox.Text.Equals(""))
            {
                IDTextBox.Foreground = Brushes.LightGray;
                IDTextBox.Text = "Identifier";
            }
        }

        private void BankAccountNumberTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            BankAccountNumberTextBox.Foreground = Brushes.Black;
            if (BankAccountNumberTextBox.Text.Equals("Bank Account Number"))
            {
                BankAccountNumberTextBox.Text = "";
            }
        }
        private void BankAccountNumberTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (BankAccountNumberTextBox.Text.Equals(""))
            {
                BankAccountNumberTextBox.Foreground = Brushes.LightGray;
                BankAccountNumberTextBox.Text = "Bank Account Number";
            }
        }

        private void PasswordTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            PasswordTextBox.Foreground = Brushes.Black;
            if (PasswordTextBox.Text.Equals("Password"))
            {
                PasswordTextBox.Text = "";
            }
        }
        private void PasswordTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PasswordTextBox.Text.Equals(""))
            {
                PasswordTextBox.Foreground = Brushes.LightGray;
                PasswordTextBox.Text = "Password";
            }
        }
        #endregion
    }
}
