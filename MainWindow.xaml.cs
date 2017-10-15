using Istorie;
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

namespace IstorieSiCiv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Generale.generareCuriozitati();
            Generale.generareIntrebariGrila(0);
            curiozitate.Text = Generale.CuriozitateRandom();
        }

        private void exitGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void refreshButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            curiozitate.Text = Generale.CuriozitateRandom();
        }

       

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "R")
            {
                curiozitate.Text = Generale.CuriozitateRandom();
            }
            else if (e.Key.ToString() == "F")
            {
                GenerareIntrebareGrila f = new GenerareIntrebareGrila();
                f.Show();
            }
            else if (e.Key.ToString() == "E")
            {
                Window1 f = new Window1();
                f.Show();
            }
            else if (e.Key.ToString() == "A")
            {
                AdaugaLectie f = new AdaugaLectie();
                f.Show();
            }
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            AlegeLectie f = new AlegeLectie();
            f.ShowDialog();
        }

        private void duel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Reguli f = new Reguli();
            f.ShowDialog();
            

        }

        private void invatare_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListLectii f = new ListLectii();
            f.ShowDialog();
            
        }

        private void cronologie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cronologie f = new Cronologie();
            f.ShowDialog();
        }

        private void statistica_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Statistica f = new Statistica();
            f.ShowDialog();
        }

        private void rebus_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            IncarcaRebus f = new IncarcaRebus();
            f.ShowDialog();
        }

        private void razboiMondial2_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            RazboiMondial2 f = new RazboiMondial2();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void info_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            ComenziInfo f = new ComenziInfo();
            f.ShowDialog();
        }

    }
}
