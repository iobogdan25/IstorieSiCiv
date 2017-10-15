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
using System.Data.SqlClient;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for Exersare.xaml
    /// </summary>
    public partial class Exersare : Window
    {
        public Exersare(int id)
        {
            InitializeComponent();
            raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            Generale.generareIntrebariGrila(id);
            string date = DateTime.Now.Year.ToString()+"."+DateTime.Now.Month.ToString()+"."+DateTime.Now.Day.ToString()+"."+ DateTime.Now.Hour.ToString()+"." + DateTime.Now.Minute.ToString() +"."+ DateTime.Now.Second.ToString() +"."+ DateTime.Now.Millisecond.ToString();
            //adaugare in DB
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("insert into TesteEfectuate(IdLectie,DataTest) values(" + id + ",'" + date + "')", con);
                con.Open();
                comanda.ExecuteNonQuery();
                
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
                SqlCommand comanda = new SqlCommand("select Id from TesteEfectuate where DataTest='" + date + "'", con);
                con.Open();
                idTest = int.Parse(comanda.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            //MessageBox.Show(idTest.ToString());
            generareIntrebare();
        }
        IntrebareGrila intrebareA;
        List<IntrebareGrila> intrebariTrecute = new List<IntrebareGrila>();
        int intrebariRamase = 14;
        int viata = 3;
        int idTest = 0;
        private void raspuns_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_1.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_1.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_1.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        private void raspuns_4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_4.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_4.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_4.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        private void raspuns_2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_2.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_2.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_2.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        private void raspuns_3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_3.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_3.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_3.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        public void generareIntrebare()
        {
            grid_trimitere.Visibility = Visibility.Visible;
            intrebareA = Generale.IntrebareGrilaRandom();
            bool eBuna = true;
            do
            {
                eBuna = true;
                foreach (var intrebare1 in intrebariTrecute)
                {
                    if (intrebareA.Id == intrebare1.Id)
                    {
                        eBuna = false;
                        break;
                    }
                }
                intrebareA = Generale.IntrebareGrilaRandom();
            } while (eBuna == false);
            intrebariTrecute.Add(intrebareA);
            intrebare.Text = intrebareA.Intrebare;
            raspuns_1.Text = intrebareA.Raspuns_1;
            raspuns_2.Text = intrebareA.Raspuns_2;
            raspuns_3.Text = intrebareA.Raspuns_3;
            raspuns_4.Text = intrebareA.Raspuns_4;
            raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            grid_raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            grid_raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            grid_raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            grid_raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
        
                
        }
        public bool verificareRaspuns()
        {
            if ((raspuns_1.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_1 == true) ||(raspuns_1.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_1 == false))
            {
                return false;
            }
            if ((raspuns_2.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_2 == true) ||(raspuns_2.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_2 == false))
            {
                return false;
            }
            if ((raspuns_3.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_3 == true) ||(raspuns_3.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_3 == false))
            {
                return false;
            }
            if ((raspuns_4.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_4 == true) ||(raspuns_4.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_4 == false))
            {
                return false;
            }
            return true;
        }

        private void grid_trimitere_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            intrebariRamase--;
            intrebari_r.Content = intrebariRamase.ToString();
            if (verificareRaspuns())
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
                try
                {
                    SqlCommand comanda = new SqlCommand("insert into TestEfectuatIntrebare(IdTestEfectuat,IdIntrebare,eCorect) values(" + idTest + "," + intrebareA.Id + ",1)", con);
                    con.Open();
                    comanda.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
                generareIntrebare();
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
                try
                {
                    SqlCommand comanda = new SqlCommand("insert into TestEfectuatIntrebare(IdTestEfectuat,IdIntrebare,eCorect) values(" + idTest + "," + intrebareA.Id + ",0)", con);
                    con.Open();
                    comanda.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
                string raspunsCorect = "Raspunsuri corecte : \n";
                if (intrebareA.IsCorect_1 == true)
                {
                    raspunsCorect += intrebareA.Raspuns_1+"\n";
                }
                if (intrebareA.IsCorect_2 == true)
                {
                    raspunsCorect += intrebareA.Raspuns_2 + "\n";
                }
                if (intrebareA.IsCorect_3 == true)
                {
                    raspunsCorect += intrebareA.Raspuns_3 + "\n";
                }
                if (intrebareA.IsCorect_4 == true)
                {
                    raspunsCorect += intrebareA.Raspuns_4 + "\n";
                }
                MessageBox.Show("Ai gresit!" + Environment.NewLine + raspunsCorect);
                if (viata == 3)
                {
                    viata_3.Visibility = Visibility.Hidden;
                }
                else if (viata == 2)
                {
                    viata_2.Visibility = Visibility.Hidden;
                }
                else if (viata == 1)
                {
                    viata_1.Visibility = Visibility.Hidden;
                }
                else if (viata == 0)
                {
                    MessageBox.Show("Ai pierdut!");
                    this.Close();
                }
                viata--;
                generareIntrebare();
                //grid_trimitere.Visibility = Visibility.Hidden;
                //if (intrebareA.IsCorect_1)
                //{
                //    raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                //}
                //if (intrebareA.IsCorect_2)
                //{
                //    raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                //}
                //if (intrebareA.IsCorect_3)
                //{
                //    raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                //}
                //if (intrebareA.IsCorect_4)
                //{
                //    raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF0000"));
                //}
            }
            if (intrebariRamase == -1 && viata>-1)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
                try
                {
                    SqlCommand comanda = new SqlCommand("update TesteEfectuate set eReusit=1 where Id=" + idTest, con);
                    con.Open();
                    comanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                }
                MessageBox.Show("Ai castigat!");
                this.Close();
            }
        }

        private void grid_next_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            generareIntrebare();
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "A")
            {
                raspuns_1_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            else if (e.Key.ToString() == "S")
            {
                raspuns_2_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            else if (e.Key.ToString() == "D")
            {
                raspuns_3_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            else if (e.Key.ToString() == "F")
            {
                raspuns_4_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            else if (e.Key.ToString() == "X")
            {
                grid_trimitere_MouseLeftButtonDown_1(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
        }
    }
}