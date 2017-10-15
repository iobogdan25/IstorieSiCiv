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
    /// Interaction logic for Cronologie.xaml
    /// </summary>
    public partial class Cronologie : Window
    {
        public Cronologie()
        {
            InitializeComponent();
            List<int> ani = new List<int>();
            List<string> evenimente=new List<string>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("select Anul,Eveniment from Cronologie", con);
                con.Open();
                SqlDataReader dr = comanda.ExecuteReader();
                while (dr.Read())
                {
                    ani.Add(int.Parse(dr[0].ToString()));
                    evenimente.Add(dr[1].ToString());
                }
                int minim=ani.Min();
                int maxim=ani.Max();
                for(int i=minim; i<=maxim;i++){
                    Border border=new Border();
                    border.HorizontalAlignment=HorizontalAlignment.Center;
                    border.BorderBrush=Brushes.Black;
                    border.Margin=new Thickness(3);
                    border.BorderThickness=new Thickness(1.5);


                    TextBlock textblock = new TextBlock();
                    textblock.Text = i.ToString();
                    textblock.Margin = new Thickness(5);
                    textblock.TextWrapping = TextWrapping.Wrap;
                    textblock.Background = Brushes.Goldenrod;
                    border.Child = textblock;
                    lista.Children.Add(border);
                    for(int j=0;j<ani.Count;j++){
                        if(ani[j]==i){
                            //adauga eveniment
                            Border border1 = new Border();
                            border1.HorizontalAlignment = HorizontalAlignment.Center;
                            border1.BorderBrush = Brushes.Black;
                            border1.Margin = new Thickness(3);
                            border1.BorderThickness = new Thickness(1.5);

                            TextBlock textblock1 = new TextBlock();
                            textblock1.Text = evenimente[j];
                            textblock1.Margin = new Thickness(5);
                            textblock1.TextWrapping = TextWrapping.Wrap;

                            border1.Child = textblock1;
                            lista.Children.Add(border1);
                        }
                    }
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
