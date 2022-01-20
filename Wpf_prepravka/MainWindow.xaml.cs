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

namespace Prepravka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Box prepravka;

        public MainWindow()
        {
            InitializeComponent();
            prepravka = new Box(4, 5, prepravkaCan);
        }

        private void addNapoj(object sender, RoutedEventArgs e)
        {
            Napoj napoj;
            int[] souradnice = new int[2];
            double cena;
            try
            {
                cena = Int32.Parse(cenaTextBox.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("Nepodařilo se mi načíst cenu");
                return;
            }
            

            if (alkoRadioButton.IsChecked == true)
            {
                napoj = new Alko(cena);
            }
            else if (nonalkoRadioButton.IsChecked == true)
            {
                napoj = new Nealko(cena);
            }
            else return;

            try
            {
                souradnice = getXY();
                validSouradnice(souradnice);
                prepravka.PridejNapoj(napoj, souradnice[0], souradnice[1]);
                soucetcenLabel.Content = prepravka.CelkovaCena().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void removeNapoj(object sender, RoutedEventArgs e)
        {

            int[] souradnice = new int[2];
            try
            {
                souradnice = getXY();
                validSouradnice(souradnice);
                prepravka.OdeberNapoj(souradnice[0], souradnice[1]);
                soucetcenLabel.Content = prepravka.CelkovaCena().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private int[] getXY()
        {
            int[] xy = new int[2];
            try
            {
                xy[0] = Int32.Parse(souradnicexTextBox.Text);
                xy[1] = Int32.Parse(souradniceyTextBox.Text);
            }
            catch (Exception)
            {
                throw new Exception("Souřadnice musí být celé kladné číslo!");
            }
            return xy;
        }

        private void validSouradnice(int[] souradnice)
        {
            if(souradnice[0] < 0 || souradnice[0] > prepravka.vyska || souradnice[1] < 0 || souradnice[1] > prepravka.sirka)
            {
                throw new Exception("Souřadnice nejsou v rozmezí přepravky");
            }
        }
    }
}
