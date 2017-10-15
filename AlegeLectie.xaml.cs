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
    /// Interaction logic for AlegeLectie.xaml
    /// </summary>
    public partial class AlegeLectie : Window
    {
        public AlegeLectie()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda=new SqlCommand("Select Id,Nume from Lectii",con);
                con.Open();
                SqlDataReader dr=comanda.ExecuteReader();
                while(dr.Read()){
                    ComboBoxItem item=new ComboBoxItem();
                    item.Tag=dr[0].ToString();
                    item.Content=dr[1].ToString();
                    lectieSelectata.Items.Add(item);
                }
                foreach(ComboBoxItem item in lectieSelectata.Items){
                    if(item.Content.ToString()=="Academia de politie"){
                        lectieSelectata.SelectedIndex=lectieSelectata.Items.IndexOf(item);
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

        private void Button_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Button_MouseLeftButtonDown_1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)lectieSelectata.SelectedItem;
            Exersare f = new Exersare(int.Parse(item.Tag.ToString()));
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
