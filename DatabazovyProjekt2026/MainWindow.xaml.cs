using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace DatabazovyProjekt2026
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Tank> Tanky { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Tanky = new ObservableCollection<Tank>();

            dgTanky.ItemsSource = Tanky;
        }

        private void BtnPridat_Click(object sender, RoutedEventArgs e)
        {
            PridatTankWindow okno = new PridatTankWindow();

            if (okno.ShowDialog() == true)
            {
                Tanky.Add(okno.NovyTank);
            }
        
        }
    }
}