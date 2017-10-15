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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for IncarcaRebus.xaml
    /// </summary>
    public partial class IncarcaRebus : Window
    {
        public IncarcaRebus()
        {
            InitializeComponent();

            Random r = new Random();
            random=r.Next(3000,4000);
            
            //f.ShowDialog();
        }
        List<CuvantRebus> cuvinte = new List<CuvantRebus>();
        int[,] matrice = new int[100, 22];
        int random = -1;
        int total = 0;
        int[] solutie = new int[100];
        public void incarcaRebusul()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("select * from Rebus", con);
                con.Open();
                SqlDataReader dr = comanda.ExecuteReader();
                while (dr.Read())
                {
                    int id = int.Parse(dr[0].ToString());
                    string cuvant = dr[1].ToString();
                    string indiciu = dr[2].ToString();
                    CuvantRebus cuvantul = new CuvantRebus();
                    cuvantul.Id = id;
                    cuvantul.Cuvant = cuvant.ToUpper();
                    cuvantul.Indiciu = indiciu;
                    cuvinte.Add(cuvantul);
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
            string cuvantCheie = _cuvantCheie.SelectionBoxItem.ToString().ToUpper();
            int contor = 0;
            foreach (var caracter in cuvantCheie)
            {
                matrice[contor,0] = 0;
                foreach (var cuvant in cuvinte)
                {
                    if (cuvant.Cuvant.Contains(caracter))
                    {
                        matrice[contor, matrice[contor, 0] + 1] = cuvant.Id;
                        matrice[contor, 0]++;
                    }
                }
                contor++;
            }
            back(0, cuvantCheie.Length);
            List<string> solutie_1= new List<string>();
            List<string> indicatii = new List<string>();
            for(int i=0;i<cuvantCheie.Length;i++){
                foreach(var cuvant in cuvinte){
                    if(cuvant.Id==solutie[i]){
                        solutie_1.Add(cuvant.Cuvant);
                        indicatii.Add(cuvant.Indiciu);
                    }
                }
            }
            Rebus f = new Rebus(solutie_1, _cuvantCheie.SelectionBoxItem.ToString().ToUpper(), indicatii);
            this.Hide();
            f.ShowDialog();
            this.Close();
            Random r = new Random();
        }
        bool eGata = false;
        public void back(int k,int n)
        {
            if (k == n)
            {
                Random r = new Random();
                int nr_1 = r.Next(0, 20);
                if (nr_1 == 7)
                {
                    eGata = true;
                }
            }
            else
            {
                if (!eGata)
                {
                    for (int i = 1; i <= matrice[k, 0]; i++)
                    {
                        int id = matrice[k, i];
                        bool canUse = true;
                        for (int j = 0; j < k; j++)
                        {
                            if (solutie[j] == id)
                            {
                                canUse = false;
                            }
                        }
                        if (canUse && !eGata)
                        {
                            solutie[k] = id;
                            back(k + 1, n);
                        }
                    }
                }
            }
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            incarcaRebusul();
        }
    }
}
