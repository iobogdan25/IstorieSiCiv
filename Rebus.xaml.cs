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
using System.Windows.Shapes;

namespace Istorie
{
    /// <summary>
    /// Interaction logic for Rebus.xaml
    /// </summary>
    public partial class Rebus : Window
    {
        public Rebus(List<string> cuvinte, string cuvantCheie,List<string> indicatii)
        {
            InitializeComponent();
            cuvinteRebus = cuvinte;
            int[] distanta = new int[1000];
            int contor = 0;
            int maxim = 0;
            foreach (var c in cuvantCheie)
            {
                string cuvant = cuvinte[contor];
                int i = 0;
                foreach (var c_1 in cuvant)
                {

                    if (c == c_1)
                    {
                        distanta[contor] = i;
                        if (i > maxim)
                        {
                            maxim = i;
                        }
                        break;
                    }
                    i++;
                }
                contor++;
            }
            contor = 0;
            foreach (var cuvant in cuvinte)
            {
                StackPanel stack = new StackPanel();
                stack.Name = "cuvant_" + contor;
                stack.Orientation = Orientation.Horizontal;
                stack.Margin = new Thickness((maxim - distanta[contor]) * 35, 0, 0, 0);
                int i = 0;
                foreach (var caracter in cuvant)
                {
                    TextBox tBox = new TextBox();
                    if (i == distanta[contor])
                    {
                        tBox.Background = Brushes.AntiqueWhite;
                    }
                    tBox.Width = 35;
                    tBox.Height = 35;
                    tBox.TextAlignment = TextAlignment.Center;
                    tBox.MaxLength = 1;
                    tBox.FontWeight = FontWeights.Bold;
                    tBox.FontSize = 22;
                    stack.Children.Add(tBox);
                    i++;
                }
                rebus.Children.Add(stack);
                contor++;
            }
            int nr = 1;
            foreach (var cuvant in indicatii)
            {
                TextBlock tb = new TextBlock();
                tb.Text =nr.ToString()+". "+ cuvant;
                tb.TextWrapping = TextWrapping.Wrap;
                tb.FontSize = 17;
                tb.Margin = new Thickness(0, 0, 0, 5);
                Indicatii.Children.Add(tb);
                nr++;
            }
        }
        List<string> cuvinteRebus=new List<string>();

        private void verifica_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void verifica_Click_1(object sender, MouseButtonEventArgs e)
        {
            bool eBun = true;
            int contor = 0;
            foreach (var stack_cuvant in rebus.Children.OfType<StackPanel>())
            {
                string cuvant = "";
                foreach (var textBox_caracter in stack_cuvant.Children.OfType<TextBox>())
                {
                    cuvant += textBox_caracter.Text;
                }
                if (cuvant.ToUpper() != cuvinteRebus[contor].ToUpper())
                {
                    eBun = false;
                    break;
                }
                contor++;
            }
            if (eBun)
            {
                MessageBox.Show("Ai reusit!");
            }
            else
            {
                MessageBox.Show("Esuat");
            }
        }

        private void mainMenu_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
