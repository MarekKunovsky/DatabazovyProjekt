using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DatabazovyProjekt2026
{
    public partial class PridatTankWindow : Window
    {
        public Tank NovyTank { get; set; }

        public PridatTankWindow()
        {
            InitializeComponent();
        }

        // 🔒 povolí jen čísla
        private void OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnUlozit_Click(object sender, RoutedEventArgs e)
        {
            // VALIDACE
            if (string.IsNullOrWhiteSpace(tbNazev.Text))
            {
                MessageBox.Show("Zadej název!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbNarodnost.Text))
            {
                MessageBox.Show("Zadej národnost!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbRok.Text))
            {
                MessageBox.Show("Zadej rok!");
                return;
            }

            if (cbTyp.SelectedItem == null)
            {
                MessageBox.Show("Vyber typ!");
                return;
            }

            int rok = int.Parse(tbRok.Text);
            int pocet = int.Parse(tbPocet.Text);

            NovyTank = new Tank()
            {
                Nazev = tbNazev.Text,
                Narodnost = tbNarodnost.Text,
                RokVyroby = rok,
                Typ = (cbTyp.SelectedItem as ComboBoxItem).Content.ToString(),
                PocetKusu = pocet,
                JeFunkcni = chbFunkcni.IsChecked == true
            };

            DialogResult = true;
        }
    }
}