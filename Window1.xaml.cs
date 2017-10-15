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
using System.IO;
using System.Data.SqlClient;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void incarca_Click_1(object sender, RoutedEventArgs e)
        {
            string path = "evenimente.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string line="";
                while ((line=sr.ReadLine())!=null)
                {
                    int an = int.Parse(line.Substring(0, 4));
                    int indice = line.IndexOf(":");
                    string eveniment = line.Substring(indice+2);
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
                    try
                    {
                        SqlCommand comanda = new SqlCommand("insert into Cronologie(Anul,Eveniment) values('" + an + "','" + eveniment + "')", con);
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
                    if (eveniment.Contains("Trump"))
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
