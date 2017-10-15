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
    /// Interaction logic for GenerareIntrebareGrila.xaml
    /// </summary>
    public partial class GenerareIntrebareGrila : Window
    {
        public GenerareIntrebareGrila()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var textRange = new TextRange(intrebare.Document.ContentStart, intrebare.Document.ContentEnd).Text.ToString();
            textRange = textRange.Substring(0, textRange.Length - 2);
            
            string raspunsGenerat = "[i:" + textRange.Replace("\n","") + "][r:" + raspuns_1.Text + "][r:" + raspuns_2.Text + "][r:" + raspuns_3.Text + "][r:" + raspuns_4.Text + "]";
            string variante= varianta_1.IsChecked==true ? "1;" : "0;";
            variante += varianta_2.IsChecked==true ? "1;" : "0;";
            variante += varianta_3.IsChecked==true ? "1;" : "0;";
            variante += varianta_4.IsChecked==true ? "1;" : "0;";
            //generat.Text = raspunsGenerat;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try 
            {
                SqlCommand comanda = new SqlCommand("insert into Intrebari(IdLectie,IdTipIntrebare,Intrebare,Raspunsuri) values (2,1,'"+raspunsGenerat+"','"+variante+"')",con);
                con.Open();
                comanda.ExecuteNonQuery();
                MessageBox.Show("Adaugata!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            
            IntrebareGrila grila = new IntrebareGrila(0,raspunsGenerat, "1;1;0;0;");
        }
    }
}
