using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using List3.Classes;
using Microsoft.Win32;

namespace List3
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _filePath, _filePathDecrypt;
        // initial permutation

        public MainWindow()
        {
            InitializeComponent();
            Key.Text = "3B3898371520F75E";
            KeyDecrypt.Text = "3B3898371520F75E";
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog {Filter = "BIN Files (*.bin)|*.bin"};

            var result = dialog.ShowDialog();

            if (!result.HasValue || !result.Value) return;

            FilePath.Text = dialog.FileName;
            _filePath = dialog.FileName;
        }

        private void OpenFileDecrypt(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "BIN Files (*.bin)|*.bin" };

            var result = dialog.ShowDialog();

            if (!result.HasValue || !result.Value) return;

            FilePathDecrypt.Text = dialog.FileName;
            _filePathDecrypt = dialog.FileName;
        }

        private void GenerateCodeOnClick(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            var buffer = new byte[8];
            random.NextBytes(buffer);
            var result = string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());

            Key.Text = result;
            KeyDecrypt.Text = result;
        }

        private void OnEncryptClick(object sender, RoutedEventArgs e)
        {
            if (!IsHex(Key.Text) || Key.Text == "")
            {
                MessageBox.Show("To nie jest wartość 16-stkowa!", "Błąd", MessageBoxButton.OK);
                return;
            }

            var des = new DES(_filePath, Key.Text);
            des.Encode();

            MessageBox.Show("Szyfrowanie zakończone powodzeniem", "Sukces", MessageBoxButton.OK);
        }

        private bool IsHex(IEnumerable<char> chars)
        {
            bool isHex;
            foreach (var c in chars)
            {
                isHex = c >= '0' && c <= '9' ||
                        c >= 'a' && c <= 'f' ||
                        c >= 'A' && c <= 'F';

                if (!isHex)
                    return false;
            }
            return true;
        }

        private void OnDecryptClick(object sender, RoutedEventArgs e)
        {
           var des = new DES(_filePathDecrypt, KeyDecrypt.Text);
            des.Decode();

            MessageBox.Show("Deszyfrowanie zakończone powodzeniem", "Sukces", MessageBoxButton.OK);
        }

        
    }
}