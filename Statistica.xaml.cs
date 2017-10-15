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
using System.Collections.ObjectModel;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for Statistica.xaml
    /// </summary>
    public partial class Statistica : Window
    {
        public Statistica()
        {

            InitializeComponent();
            incarcaTotaluri();
            incarcaTeste();
        }
        public void incarcaTotaluri()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("select count(Id) from TesteEfectuate", con);
                con.Open();
                totalTeste.Text = comanda.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            try
            {
                SqlCommand comanda = new SqlCommand("select count (*) from (Select  count(Distinct(IdTestEfectuat)) as total from TestEfectuatIntrebare Group by IdTestEfectuat having sum(eCorect)>11 and count(eCorect)=15 ) as testeReusite", con);
                con.Open();
                int nrTotal = int.Parse(totalTeste.Text.ToString());
                int nrReusite = int.Parse(comanda.ExecuteScalar().ToString());
                testeReusiste.Text = nrReusite.ToString();
                testeNereusite.Text = (nrTotal - nrReusite).ToString();
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
        public void incarcaTeste(){
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("select * from TesteEfectuate", con);
                con.Open();
                SqlDataReader dr = comanda.ExecuteReader();
                int contor = 1;
                while (dr.Read())
                {
                    string idLectie = dr[1].ToString();
                    string dataTest = dr[2].ToString();
                    int eReusit = int.Parse(dr[3].ToString());
                    string[] splitDataTest = dataTest.Split('.');
                    string an = splitDataTest[0];
                    string luna = splitDataTest[1];
                    string zi = splitDataTest[2];
                    string ora = splitDataTest[3];
                    string minut = splitDataTest[4];
                    Border border = new Border();
                    border.Margin = new Thickness(2);
                    border.BorderThickness=new Thickness(0.6);
                    border.HorizontalAlignment = HorizontalAlignment.Left;
                    border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9C9C9"));
                    border.Width = 180;
                    StackPanel stack = new StackPanel();
                    TextBlock text_rand_1 = new TextBlock();
                    text_rand_1.Margin = new Thickness(2);
                    text_rand_1.TextWrapping = TextWrapping.Wrap;
                    text_rand_1.Text = "#" + contor + " Test initiat la " + luna + "/" + zi + "/" + an + " " + ora + ":" + minut;
                    TextBlock text_rand_2 = new TextBlock();
                    text_rand_2.Margin = new Thickness(2);
                    text_rand_2.TextWrapping = TextWrapping.Wrap;
                    if (eReusit == 1)
                    {
                        text_rand_2.Text = "PROMOVAT";
                        text_rand_1.Foreground = Brushes.Green;
                        text_rand_2.Foreground = Brushes.Green;
                    }
                    else
                    {
                        text_rand_2.Text = "RESPINS";
                        text_rand_1.Foreground = Brushes.Red;
                        text_rand_2.Foreground = Brushes.Red;
                    }
                    stack.Children.Add(text_rand_1);
                    stack.Children.Add(text_rand_2);
                    border.Child = stack;
                    teste.Children.Add(border);
                    contor++;
                }
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
