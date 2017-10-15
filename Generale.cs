using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
namespace Istorie
{
    public static class Generale
    {
        private static List<string> curiozitati = new List<string>();
        private static List<IntrebareGrila> intrebariGrila = new List<IntrebareGrila>();
        public static void generareCuriozitati(){
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("Select Text from Curiozitati", con);
                con.Open();
                SqlDataReader dr = comanda.ExecuteReader();
                while (dr.Read())
                {
                    curiozitati.Add(dr[0].ToString());
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
        public static string CuriozitateRandom()
        {
            int nrCuriozitati = curiozitati.Count;
            Random r = new Random();
            int random = r.Next(0, nrCuriozitati);
            return curiozitati.ElementAt(random);
        }
        public static void generareIntrebariGrila(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {

                SqlCommand comanda = new SqlCommand("select Id,Intrebare, Raspunsuri from Intrebari where IdTipIntrebare=1 and IdLectie="+id.ToString(), con);
                if (id == 0)
                {
                    comanda.CommandText = "select Id,Intrebare, Raspunsuri from Intrebari where IdTipIntrebare=1";
                }
                con.Open();
                SqlDataReader dr = comanda.ExecuteReader();
                intrebariGrila.Clear();
                while (dr.Read())
                {
                    intrebariGrila.Add(new IntrebareGrila(int.Parse(dr[0].ToString()),dr[1].ToString(),dr[2].ToString()));
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
        public static IntrebareGrila IntrebareGrilaRandom()
        {
            Random r = new Random();
            int x = r.Next(0, intrebariGrila.Count);
            IntrebareGrila intrebare = new IntrebareGrila();
            intrebare = intrebariGrila.ElementAt(x);
            return intrebare;
        }
    }
}
