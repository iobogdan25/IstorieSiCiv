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
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using IstorieSiCiv;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for Duel.xaml
    /// </summary>
    public partial class Duel : Window
    {
        public Duel()
        {
            InitializeComponent();
            raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            generareIntrebare();
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            wrong_image_2.Visibility = Visibility.Hidden;
            grid_player_2.Opacity = 1;
        }
        DispatcherTimer timer = new DispatcherTimer();
        int secunde = 30;
        int scor_jucator_1 = 0;
        int scor_jucator_2 = 0;
        bool eGresit_p1 = false;
        bool eGresit_p2 = false;
        int nrIntrebare = 0;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            secunde--;
            secunde_ramase.Text = secunde.ToString();
            if (secunde == 0)
            {
                secunde = 30;
                secunde_ramase.Text = secunde.ToString();
                generareIntrebare();
            }
        }
        IntrebareGrila intrebareA;
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
        private void raspuns_5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_5.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_5.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_5.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        private void raspuns_8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_8.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_8.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_8.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        private void raspuns_6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_6.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_6.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_6.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        private void raspuns_7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var gray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));

            if (raspuns_7.Background.ToString() == "#FFD8D8D8")
            {
                raspuns_7.Background = new SolidColorBrush(Colors.GreenYellow);
                grid_raspuns_7.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                raspuns_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        public void generareIntrebare()
        {
            if (nrIntrebare == 10)
            {
                if (scor_jucator_1 > scor_jucator_2)
                {
                    MessageBox.Show("Jucatorul 1 a castigat!");
                }
                else if (scor_jucator_1 < scor_jucator_2)
                {
                    MessageBox.Show("Jucatorul 2 a castigat!");
                }
                else if (scor_jucator_1 == scor_jucator_2)
                {
                    MessageBox.Show("Remiza!");
                }
                timer.Stop();
                this.Close();
               
                
            }
            else
            {
                nrIntrebare++;
                nrIntr.Text = nrIntrebare.ToString();
                eGresit_p1 = false;
                eGresit_p2 = false;
                wrong_image_1.Visibility = Visibility.Hidden;
                grid_player_1.Opacity = 1;
                wrong_image_2.Visibility = Visibility.Hidden;
                grid_player_2.Opacity = 1;
                grid_trimitere.Visibility = Visibility.Visible;
                grid_trimitere_1.Visibility = Visibility.Visible;
                intrebareA = Generale.IntrebareGrilaRandom();
                intrebare.Text = intrebareA.Intrebare;
                intrebare_1.Text = intrebareA.Intrebare;
                raspuns_1.Text = intrebareA.Raspuns_1;
                raspuns_2.Text = intrebareA.Raspuns_2;
                raspuns_3.Text = intrebareA.Raspuns_3;
                raspuns_4.Text = intrebareA.Raspuns_4;
                raspuns_5.Text = intrebareA.Raspuns_1;
                raspuns_6.Text = intrebareA.Raspuns_2;
                raspuns_7.Text = intrebareA.Raspuns_3;
                raspuns_8.Text = intrebareA.Raspuns_4;
                raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                raspuns_8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
                grid_raspuns_8.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD8D8D8"));
            }
        }
        //jucator 1=1
        //-//-    2=2
        public bool verificareRaspuns(int jucator)
        {
            switch (jucator)
            {
                case 1:
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
                    }
                    break;
                case 2:
                    {
                        if ((raspuns_5.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_1 == true) ||(raspuns_5.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_1 == false))
                        {
                            return false;
                        }
                        if ((raspuns_6.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_2 == true) ||(raspuns_6.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_2 == false))
                        {
                            return false;
                        }
                        if ((raspuns_7.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_3 == true) ||(raspuns_7.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_3 == false))
                        {
                            return false;
                        }
                        if ((raspuns_8.Background.ToString() == "#FFD8D8D8" && intrebareA.IsCorect_4 == true) ||(raspuns_8.Background.ToString() != "#FFD8D8D8" && intrebareA.IsCorect_4 == false))
                        {
                            return false;
                        }
                    } break;
            }
            return true;
        }

        private void grid_trimitere_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (verificareRaspuns(1))
            {
                scor_jucator_1 += 10;
                scor_player_1.Text = scor_jucator_1.ToString();
                generareIntrebare();
                secunde = 30;
                secunde_ramase.Text = secunde.ToString();
            }
            else
            {
                eGresit_p1 = true;
                wrong_image_1.Visibility = Visibility.Visible;
                grid_player_1.Opacity = 0.1f;
               
            }
            if (eGresit_p1 && eGresit_p2)
            {
                generareIntrebare();
                secunde = 30;
                secunde_ramase.Text = secunde.ToString();
            }
        }
        private void grid_trimitere_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (verificareRaspuns(2))
            {
                generareIntrebare();
                scor_jucator_2 += 10;
                scor_player_2.Text = scor_jucator_2.ToString();
                secunde = 30;
                secunde_ramase.Text = secunde.ToString();
            }
            else
            {
                wrong_image_2.Visibility = Visibility.Visible;
                grid_player_2.Opacity = 0.1f;
                eGresit_p2 = true;
                
            }
            if (eGresit_p1 && eGresit_p2)
            {
                generareIntrebare();
                secunde = 30;
                secunde_ramase.Text = secunde.ToString();
            }
        }
        private void grid_next_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            generareIntrebare();
        }
        private void grid_next_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            generareIntrebare();
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString() == "A")
            {
                raspuns_1_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if(e.Key.ToString()=="S"){
                raspuns_2_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "D")
            {
                raspuns_3_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "F")
            {
                raspuns_4_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "U")
            {
                raspuns_5_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "I")
            {
                raspuns_6_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "O")
            {
                raspuns_7_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "P")
            {
                raspuns_8_MouseLeftButtonDown(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "X" && eGresit_p1==false)
            {
                grid_trimitere_MouseLeftButtonDown_1(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
            if (e.Key.ToString() == "K" && eGresit_p2==false)
            {
                grid_trimitere_MouseLeftButtonDown_2(new object(), new MouseButtonEventArgs(Mouse.PrimaryDevice, 100, MouseButton.Left));
            }
        }
    }
}
