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
    /// Interaction logic for VizualizareLectie.xaml
    /// </summary>
    public partial class VizualizareLectie : Window
    {
        public VizualizareLectie(Lectie lectie)
        {
                InitializeComponent();
                titlu.Text = lectie.Denumire;
                //textBlock
                //TextWrapping="Wrap" FontSize="17" FontFamily="Georgia" Margin="0,15,0,0" xml:space="preserve"
                textLectiee.Text = lectie.TextLectie;
            
        }
        bool ePrimul = true;
        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!ePrimul)
            {
                textLectiee.FontSize = Math.Round( marime.Value);
            }
            ePrimul = false;
        }
    }
}
