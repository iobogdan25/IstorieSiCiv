using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for AdaugaLectie.xaml
    /// </summary>
    public partial class AdaugaLectie : Window
    {
        public AdaugaLectie()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            try
            {
                var uriSource = new Uri(cale.Text, UriKind.RelativeOrAbsolute);
                imagine.Source = new BitmapImage(uriSource);
            }
            catch {
                imagine.Source = new BitmapImage();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var _textLectie = new TextRange(textLectie.Document.ContentStart, textLectie.Document.ContentEnd).Text.ToString();
            _textLectie = _textLectie.Replace("Ă", "A");
            _textLectie = _textLectie.Replace("Î", "I");
            _textLectie = _textLectie.Replace("Ş", "S");
            _textLectie = _textLectie.Replace("Â", "A");
            _textLectie = _textLectie.Replace("Ț", "T");
            _textLectie = _textLectie.Replace("ă", "a");
            _textLectie = _textLectie.Replace("î", "i");
            _textLectie = _textLectie.Replace("ș", "s");
            _textLectie = _textLectie.Replace("ț", "t");
            _textLectie = _textLectie.Replace("â", "a");
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("insert into Lectii(Nume,Descriere,isDefault,textLectie,caleImagine) values('"+denumire.Text+"','Default',0,'"+_textLectie+"','"+cale.Text+"')", con);
                con.Open();
                comanda.ExecuteNonQuery();
                MessageBox.Show("Adaugat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
