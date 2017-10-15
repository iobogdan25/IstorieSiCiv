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
    /// Interaction logic for Reguli.xaml
    /// </summary>
    public partial class Reguli : Window
    {
        public Reguli()
        {
            InitializeComponent();
        }
        bool eApasat1 = false;
        bool eApasat2 = false;
        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "X")
            {
                eApasat1 = true;
            }
            else if (e.Key.ToString() == "K")
            {
                eApasat2 = true;
            }
            if (eApasat1 && eApasat2) {
                Duel f = new Duel();
                f.ShowDialog();
            }
        }
    }
}
