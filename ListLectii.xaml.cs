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
    /// Interaction logic for ListLectii.xaml
    /// </summary>
    public partial class ListLectii : Window
    {
        public ListLectii()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");

            try
            {
                SqlCommand comanda = new SqlCommand("select * from Lectii  where isDefault=0", con);
                con.Open();
                SqlDataReader dr = comanda.ExecuteReader();
                while (dr.Read())
                {
                    Lectie lectie = new Lectie();
                    lectie.Id = int.Parse(dr[0].ToString());
                    lectie.Denumire = dr[1].ToString();
                    lectie.Descriere = dr[2].ToString();
                    lectie.TextLectie = dr[4].ToString();
                    lectie.CaleImagine = dr[5].ToString();
                    lectii.Add(lectie);
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
            foreach (var lectie in lectii)
            {
                //Border
                //BorderBrush="Black" Margin="3" BorderThickness="0.9"
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.Margin = new Thickness(3);
                border.BorderThickness = new Thickness(0.9);

                //Grid
                //Height="70" Width="240" Background="White"  Name="revolutiaIndustriala" MouseLeftButtonDown="revolutiaIndustriala_MouseLeftButtonDown"
                Grid grid = new Grid();
                grid.Height = 70;
                grid.Width = 240;
                grid.Background = Brushes.White;
                grid.Name = "_" + lectie.Id;
                grid.MouseLeftButtonDown += grid_MouseLeftButtonDown;
                grid.MouseRightButtonDown +=grid_MouseRightButtonDown;
                //stackPanel
                StackPanel stackpanel = new StackPanel();
                stackpanel.Orientation = Orientation.Horizontal;

                //image
                //Grid.Column="0" Source="Resources/Barrow_Steelworks.jpg" HorizontalAlignment="Left" Width="100" Height="70"
                Image image = new Image();
                try
                {
                    var uriSource = new Uri(lectie.CaleImagine, UriKind.RelativeOrAbsolute);
                    image.Source = new BitmapImage(uriSource);
                }
                catch{
                    image.Source=new BitmapImage();
                }
                image.HorizontalAlignment = HorizontalAlignment.Left;
                image.Width = 100;
                image.Height = 70;
                stackpanel.Children.Add(image);

                //textblock
                //Grid.Column="1" Margin="4,0,0,0" FontSize="16" VerticalAlignment="Center"
                TextBlock textBlock = new TextBlock();
                textBlock.Margin = new Thickness(4, 0, 0, 0);
                textBlock.FontSize = 16;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Text = lectie.Denumire;
                stackpanel.Children.Add(textBlock);

                grid.Children.Add(stackpanel);
                border.Child = grid;
                m_stack.Children.Add(border);
            }
        }
        List<Lectie> lectii = new List<Lectie>();
        private void consolidareaSua_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ConsolidareSUA f = new ConsolidareSUA();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void revolutiaIndustriala_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RevolutiaIndustriala f = new RevolutiaIndustriala();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        private void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Lectie lectia = new Lectie();
            string name = ((Grid)sender).Name;
            int id =int.Parse(name.Substring(1));
            foreach (var lectie in lectii)
            {
                if (lectie.Id == id)
                {
                    lectia = lectie;
                    break;
                }
            }
            VizualizareLectie f = new VizualizareLectie(lectia);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        int idSelectie;
        private void grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
            string name = ((Grid)sender).Name;
            int id = int.Parse(name.Substring(1));
            idSelectie = id;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");

            try
            {
                SqlCommand comanda = new SqlCommand("delete from Lectii where Id=" + idSelectie, con);
                con.Open();
                comanda.ExecuteNonQuery();
                MessageBox.Show("Lectie stearsa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            string idGrid = "_" + idSelectie;
            foreach (var border in m_stack.Children.OfType<Border>())
            {
                if (((Grid)border.Child).Name==idGrid)
                {
                    m_stack.Children.Remove(border);
                    break;
                }
            }
        }
    }
}
