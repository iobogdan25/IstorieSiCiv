using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using Microsoft.Win32;
using IstorieSiCiv;
using System.Data.SqlClient;
namespace Istorie
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class RazboiMondial2 : Window
    {
        public RazboiMondial2()
        {
            InitializeComponent();
            player.MediaEnded += player_MediaEnded;
        }

        void player_MediaEnded(object sender, EventArgs e)
        {
            if (indice + 1 < muzicaLB.Items.Count)
            {
                indice++;
            }
            else
            {
                indice = 0;
            }
            ListBoxItem item =(ListBoxItem) muzicaLB.Items[indice];
            player.Open(new Uri(item.Tag.ToString(), UriKind.RelativeOrAbsolute));
            player.Play();

        }
        MediaPlayer player = new MediaPlayer();
        int indice = 0;
        private void Marea_Britanie_MouseEnter(object sender, MouseEventArgs e)
        {
            Canvas canvas = new Canvas();
            canvas = (Canvas)sender;
            foreach (var children in canvas_principal.Children.OfType<Canvas>())
            {
                if (children.Name != "Harta_principala")
                {
                    foreach (var children_1 in children.Children.OfType<System.Windows.Shapes.Path>())
                    {
                        children_1.Opacity = 0;
                        children_1.StrokeThickness = 1;

                    }
                }
            }
            foreach (var children in canvas.Children.OfType<System.Windows.Shapes.Path>())
            {
                children.Fill = Brushes.Aqua;
                children.Opacity = 1;
                children.StrokeThickness = 3;
                children.StrokeMiterLimit = 1;
                children.Stroke = Brushes.Black;
            }
            
            tara.Content = canvas.Name;
            if (canvas.Name == "Germania_de_Vest")
            {
                tara.Content = "Germania de Vest";
            }
            else if (canvas.Name == "Germania_de_Est")
            {
                tara.Content = "Germania de Est";
            }
            else if (canvas.Name == "MareaBritanie")
            {
                tara.Content = "Marea Britanie";
            }

        }

        private void Anglia_MouseLeave(object sender, MouseEventArgs e)
        {
            tara.Content = "";
            Canvas canvas = new Canvas();
            canvas = (Canvas)sender;
            foreach (var children in canvas.Children.OfType<System.Windows.Shapes.Path>())
            {
                children.Opacity = 0;
                children.StrokeThickness = 1;

            }
        }

        private void Label_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
           // MediaPlayer player = new MediaPlayer();
           // player.Open(new Uri("../../Resources/Muzica/Thirty Seconds To Mars - This Is War.mp3", UriKind.RelativeOrAbsolute));
           //player.Play();
           Application.Current.Shutdown(0);
        }
        [STAThread] 
        private void incarcaPlaylist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string path = "muzica.txt";
            if (!File.Exists(path))
            {
                MessageBox.Show("Fisierul muzica.txt nu exista.");
            }
            else
            {
                muzicaLB.Items.Clear();
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = "";
                    while ((line=sr.ReadLine())!=null)
                    {
                        ListBoxItem item = new ListBoxItem();
                        
                        if (line.Substring(line.Length - 4, 4) == ".mp3")
                        {
                            item.Content= line.Substring(line.LastIndexOf('\\')+1);
                            item.Tag = line;
                            muzicaLB.Items.Add(item);
                        }
                        
                    }
                }
            }
        }

        private void muzicaLB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void muzicaLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)muzicaLB.SelectedItem;
            indice = muzicaLB.SelectedIndex;
            player.Open(new Uri(item.Tag.ToString(), UriKind.RelativeOrAbsolute));
            player.Play();
            stop_Button.Visibility = Visibility.Visible;
            start_Button.Visibility = Visibility.Hidden;
        }

        private void volum_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = volum.Value;
        }

        private void start_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            player.Play();
            stop_Button.Visibility = Visibility.Visible;
            start_Button.Visibility = Visibility.Hidden;
        }

        private void stop_Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            player.Stop();
            stop_Button.Visibility = Visibility.Hidden;
            start_Button.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            MainWindow f = new MainWindow();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void Anglia_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas canvas = new Canvas();
            canvas = (Canvas)sender;
            foreach (var children in canvas_principal.Children.OfType<Canvas>())
            {
                if (children.Name != "Harta_principala")
                {
                    foreach (var children_1 in children.Children.OfType<System.Windows.Shapes.Path>())
                    {
                        children_1.Opacity = 0;
                        children_1.StrokeThickness = 1;

                    }
                }
            }
            foreach (var children in canvas.Children.OfType<System.Windows.Shapes.Path>())
            {
                children.Fill = Brushes.Aqua;
                children.Opacity = 1;
                children.StrokeThickness = 3;
                children.StrokeMiterLimit = 1;
                children.Stroke = Brushes.Black;
            }

            tara.Content = canvas.Name;
            if (canvas.Name == "Germania_de_Vest")
            {
                tara.Content = "Germania de Vest";
            }
            else if (canvas.Name == "Germania_de_Est")
            {
                tara.Content = "Germania de Est";
            }
            else if (canvas.Name == "MareaBritanie")
            {
                tara.Content = "Marea Britanie";
            }
            switch (tara.Content.ToString())
            {
                case "Cehoslovacia":
                    {
                        istoric_tara.Text = "     Statutul protectoratului Boemiei și Moraviei era stabilit de un ordin al lui Hitler din 16 martie 1939. Protectoratul Boemiei și Moraviei nu avea o reprezentare clară peste graniță și nici armată națională. Guvernul local avea mai degrabă un rol consultativ. În toate provinciile, guvernarea era asigurată de un Oberlandrat\". A fost autorizată existența unui singur partid politic „Alianța națională”. Cu o majoritate zdrobitoare (99%) a fost aprobat printru-un plebiscit ca în Protectorat să nu mai fie ales un parlament. Președintele și guvernul protectoratului nu se bucurau de puteri reale. Puterea se afla în mâinile lui Karl Hermann Frank, „Reichsprotektor” și secretar al protectoratului. Diferitele servicii polițienești ale Germaniei Naziste, precum Sicherheitsdienst sau Gestapo, operau fără restricții pe întreagul teritoriu al Moraviei și Boemiei, acționând împotriva oponenților politici cehi sau germani. În prima lună de la instaurarea protectoratului, ocupația germană a fost relativ blândă. Germanii au încercat în acest fel să câștige simpatia și colaborarea muncitorilor calificați, de care avea atâta nevoie.  Represiunea dură a fost rezervată în principal pentru intelectuali și politicieni, cărora dezlănțuirea luptelor celui de-al doilea război mondial le putea da unele speranțe de eliberare.";
                    }break;
                case "Romania":
                    {
                        istoric_tara.Text = "     Campania din est: Pe 22 iunie, 1941, armata germană împreună cu unităţi ale armatei române au început campania din est împotriva Uniunii Sovietice. Armata română a început lupta împotriva forţelor sovietice în dimineaţa zilei de 22 iunie 1941 pe un front cuprins între munţii Bucovinei şi Marea Neagră. La 5 iulie intră în Cernăuţi primele trupe române. La 10 iulie oraşul Soroca este eliberat de către Divizia blindată română care apoi se îndreaptă către localitatea Bălţi pe care o eliberează la 12 iulie. Localitatea Orhei este eliberată în data de 15 iulie de către unităţi din Divizia 5 infanterie română. Pe 16 iulie ca urmare a acţiunilor întreprinse de Corpul 3 român şi Corpul 54 german este eliberat oraşul Chişinău. A doua zi, pe 17 iulie, Cartierul general al Comandamentului frontului germano-român transmite că odată cu victoria pentru cucerirea masivului Corneşti, “cheia strategică a Basarabiei e în mâna noastră” şi că Hotinul, Soroca, Orheiul şi Chişinăul au fost eliberate. Pe 21 iulie, Divizia 10 infanterie trece Dunărea şi eliberează localităţile Ismail, Chilia Nouă, Vîlcov şi continuă să meargă către Cetatea Albă cu scopul eliberării totale a Basarabiei.\n      La 27 iulie 1941, Hitler îi trimite lui Antonescu un mesaj de felicitare pentru eliberarea Basarabiei şi Bucovinei şi îi cere să treacă Nistrul şi să ia sub supraveghere teritoriul dintre Nistru şi Bug. Dacă până la eliberarea teritoriilor româneşti, Antonescu a avut sprijin total din partea societăţii româneşti, în momentul în care s-a înfăptuit acest lucru, a apărut întrebarea dacă să se mergă doar “până la Nistru sau până la victoria finală”. Unul dintre cei care susţineau că armata română ar trebui să se oprească la Nistru era Iuliu Maniu argumentând că mai departe nu este războiul românilor şi că atenţia ar trebui îndreptată către Ardeal. Tot cu gândul la Ardeal a hotărât şi Antonescu să treacă Nistrul cu speranţa că Hitler va face dreptate românilor în problema Ardealului. Astfel că la scrisoarea trimisă de Hitler în 27 iulie, răspunde afirmativ la 31 iulie, arătându-şi totodată şi încrederea în “justiţia pe care Fuhrerul cancelar Adolf Hitler o va face poporului român şi drepturilor statornice seculare, misiunii sale din Carpaţi, de la Dunăre şi de la Marea Neagră” .\n      La 22 august 1941, Ion Antonescu este ridicat prin decret regal la demnitatea de mareşal al României şi decorat cu Ordinul militar “Mihai Viteazul” clasa I. Răspunzând la 12 septembrie la o scrisoare a unor refugiaţi români din Ardeal, Ion Antonescu spune: “Nicio brazadă românească nu se uită. Nicio umilire nu rămâne nerăzbunată. Jertfele pentru Odessa nu sunt numai pentru graniţa răsăriteană, ci pentru împlinirea tuturor drepturilor şi năzuiţelor neamului” .\n     După ce au eliberat Basarabia şi Bucovina, unităţile române au luptat alături de Germania mai departe la Odessa, Sevastopol, şi Stalingrad. Contribuţia României în efective de luptă a fost enormă, depăşită doar de armata germană, dar depăşind celelalte aliate ale Germaniei.\n     În anii regimului lui Antonescu, România a alimentat economia de război a Germaniei cu petrol, cereale, precum şi produse industriale fară vreo recompensă.\nRomânia a devenit o ţintă a bombardamentului aliat, mai ales pe 1 august, 1943 când au fost atacate câmpurile petroliere şi rafinăriile de la Ploieşti.\n   Deşi şi România şi Ungaria erau aliate ale Germaniei, regimul Antonescu şi-a continuat ostilitatea diplomatică faţă de Ungaria din cauza problemei Transilvaniei.";
                    }break;
                case "Ucraina":
                    {
                        istoric_tara.Text = "     După semnarea Pactului Ribbentrop-Molotov, armatele Germaniei Naziste (1 septembrie 1939) și Uniunii Sovietice (17 septembrie 1939) au invadat Polonia. Teritoriul polonez a fost împărțit între cele două puteri invadatoare, Galiția și Volâna revenind sovieticilor. După capitularea Franței în fața Germaniei, România, în fața utlimatumului sovietic, a cedat fără luptă Basarabia și nordul Bucovinei în iunie 1940. RSS Ucraineană a luat în stăpânire nordul și sudul Basarabiei și nordul Bucovinei, dar a cedat o fâșie de-a lungul Nistrului noii formate RSS Modovenești. Toate aceste câștiguri teritoriale, plus Transcarpatia aveau să fie recunoscute la sfârșitul războiului prin semnarea Tratatul de pace de la Paris din 1947.\nÎn momentul în care Germania Nazistă și aliații săi au declanșat Operațiunea Barbarossa în 1941, numeroși polonezi și ucraineni, sătui de cei doi ani de dominați draconică sovietică, i-au primit pe invadatori ca pe niște eliberatori. Activiștii naționaliști ucraineni au considerat că momentul este propice pentru instaurarea unui stat ucrainean independent. La începutul războiului, germanii i-au încurajat într-o oarecare măsură pe naționaliștii ucrainei, făcând promisiuni pentru proclamarea unei „Ucraine Mari”, în încercarea de a folosi sentimentele antisovietice, antipoloneze și antievreiești. A fost înființată o poliție auxiliară ucraineană și o unitate ucraineană în cadrul Waffen SS. Până în cele din urmă, după perioada inițială de toleranță limitată, atitudinea autorităților germane de ocupație s-a modificat brusc, iar mișcările naționaliste ucrainene au fost zdrobite în mod brutal.\nCei mai mulți ucraineni însă au opus rezistență ocupației germane încă de la începutul invaziei, organizând o vastă rețea de unități de partizani, care au acționat pe tot întinsul Ucrainei. Elementele naționaliste ucrainene au format Armata Insurecțională care a luptat atât împotriva germanilor, cât și împotriva sovieticilor, românilor, slovacilor și polonezilor. Luptătorii Aramtei Insurecționale Ucrainene au reușit să continue lupta împotriva autorităților sovietice până în deceniul al șaselea.\nAdministratorii naziști ai teritoriilor sovietice ocupate nu au făcut nicio încercare să exploateze nemulțumirile populației locale față de abordările politice și economice sovietice. Mai mult decât atât, naziștii au păstrat sistemul fermelor coective, au deportat numeroși tineri ucraineni la muncă forțată în Germania și au declanșat genocidul împotriva evreilor. Lupta partizanilor ucraineni a adus o contribuție importantă la victoria Armatei Roșii împotriva germanilor.\nPierderile totale din rândul civililor ucraineni în timpul ocupației naziste sunt estimate la aproximativ șapte milioane de oameni, din care cam un milion de evrei uciși de Einsatzgruppen.\nNumeroși civili au căzut victime ale abuzurilor, muncii forțate sau a represaliilor ca urmare a atacurilor partizanilor împotriva germanilor. Din rândul celor unsprezece milioane de soldați ai Armatei Roșii, aproximativ un sfert au fost etnici ucraineni. Ucrainenii au participat la unele dintre cele mai mari bătălii ale celui de-al Doilea Război Mondial precum încecuirea de la Kiev din 1941 (capitala Ucrainei avea să fie proclamată Oraș Erou la sfârșitul războiului), unde peste 660.000 de soldați sovietici au căzut prizonieri, asediul Odesei sau forțarea Niprului din 1943.\n";
                    }break;
                case "Iugoslavia":
                    {
                        istoric_tara.Text = "     Pe 6 aprilie 1941, la ora 5:12 A.M., forțele maghiare, italiene și germane au atacat Iugoslavia. Forțele aeriene germane (Luftwaffe) au bombardat orașele mari, printre care și capitala Belgrad. Reprezentanții diferitelor regiuni ale Iugoslaviei au semnat, în 17 aprilie, la Belgrad, un armistițiu cu Germania care a pus capăt rezistenței de unsprezece zile împotriva invadării armatei germane (Wehrmacht Heer). Peste trei sute de mii de soldați și ofițeri iugoslavi au fost luați prizonieri.\nPuterile Axei au ocupat Iugoslavia și au împărțit-o. Statul Independent al Croației a fost înființat ca un stat nazist, condus de Ante Pavelič, șeful miliției fasciste, cunoscută cu numele Ustași (mișcare care a fost înființată în 1929, activitățile acesteia fiind, însă, relativ limitate până în 1941). Trupele germane au ocupat Bosnia și Herțegovina, precum și anumite părți din Serbia și Slovenia, în timp celelalte părți din țară erau ocupate de Bulgaria, Ungaria și Italia. În timpul existenței sale, Statul Independent al Croației a creat lagăre de concentrare pentru anti-fasciști, comuniști, sârbi, rromi, evrei și croații care care se opuneau ideologiei.\nÎncă de la începutul ocupației, forțele de rezistență au fost formate din două facțiuni: una condusă de comuniști – partizanii iugoslavi – și a doua a regaliștilor naționaliști – mișcarea cetnicilor. Partizanii iugoslavi pro comuniști au beneficiat de recunoașterea tuturor Aliaților doar după Conferința de la Teheran din 1943, după ce gradul de colaborare a cetnicilor cu ocupantul german a crescut treptat.\nPartizanii au inițiat o campanie de gherilă, ce a fost dezvoltată, ulterior, în armată de rezistență contra ocupantului nazist al Europei Centrale și Occidentale. Inițial, cetnicii erau susținuți de guvernul regal exilat, precum și Aliați, însă imediat s-au axat pe combaterea partizanilor, în timp ce colaborau cu forțele ocupate către o extindere mai mare. Până la sfârșitul războiului, mișcarea cetnicilor se transformase într-o miliție sârbă naționalistă colaboraționistă, complet dependentă de puterile Axei[4], în timp ce grupurile de partizani din munți, conduși de comunistul Iosip Broz Tito și-au continuat războiul de gherilă cu succes enorm. Victoriile cele mai cunoscute împotriva forțelor ocupante au fost bătăliile de la Neretva și Sutjeska.\nLa 25 noiembrie 1942, Consiliul Antifascist de Eliberare Națională a Iugoslaviei (Antifašističko vijeće narodnog oslobođenja Jugoslavije) a fost convocat în Bosnia și Herțegovina la Bihać. Consiliul a fost din nou convocat, în 25 noiembrie 1943, tot în Bosnia și Herțegovina, la Jajce, și a stabilit baza de organizare postbelică a țării, de instituire a unei federații (această dată a fost sărbătorită ca Ziua Republicii după război).\nPartizanii iugoslavi au fost capabili să scoată puterile Axei din Serbia, în 1944, și din restul Iugoslaviei, în 1945. În cursul primilor ani de război, Armata Roșie, spre deosebire de anglo-americani, putuse oferi puțină asistență militară, cu excepția eliberării Belgradului, în 20 octombrie 1944, iar retragerea ei s-a încheiat imediat după sfârșitul războiului. În mai 1945, partizanii s-au întâlnit cu forțele aliate în afara granițelor fostei Iugoslavii, după ce au cucerit Trieste și alte părți din provinciile austriece din sud, Stiria și Carintia. Cu toate acestea, partizanii s-au retras de la Trieste, în iunie al aceluiași an.\nÎncercările occidentale de reunire a partizanilor, care negau supremația vechiul guvern al Regatului Iugoslavia, și emigrarea loialilor regelui au dus la Acordul Tito-Šubašić, în iunie 1944. Cu toate acestea, mareșalul Iosip Broz Tito era văzut de cetățeni ca un erou național, și a fost ales în urma unui referendum să conducă noul stat comunist independent, în calitate de prim-ministru. Estimările iugoslave oficiale postbelice privind pierderile umane ale Iugoslaviei în cel de-al Doilea Război Mondial se ridică la 1.704.000 de victime. După recorelarea datelor, în 1980, de către istoricii Vladimir Žerjavić și Bogoljub Kočović s-a dezvăluit că numărul real de morți a fost de circa 1 milion.\n";
                    }break;
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
                        //<StackPanel>
                        //    <StackPanel Orientation="Horizontal" Margin="30,20,0,0">
                        //        <Border BorderThickness="0.6" Width="100" Height="60" BorderBrush="#FF727272" CornerRadius="1">
                        //            <StackPanel Width="100" Height="60">
                        //                <TextBlock FontSize="15" Margin="5,3,0,0" Foreground="#FF3C3C3C"><Run Text="20 Ianuarie"/></TextBlock>
                        //                <TextBlock FontSize="30" Margin="5,-5,0,0" Foreground="#FF363636"><Run Text="1939"/></TextBlock>
                        //            </StackPanel>
                        //        </Border>
                        //        <TextBlock VerticalAlignment="Bottom" Margin="10,0,0,0" FontSize="30" TextWrapping="Wrap" Foreground="Black"><Run Text="Revista TIME l-a numit pe Hitler Omul Anului"/></TextBlock>
                        //    </StackPanel>
                        //    <TextBlock TextWrapping="Wrap" Margin="140,0,0,0" FontSize="20" Foreground="#FF616161">Revista americană Time Magazine are o tradiție veche: la începutul fiecărui an, publică o ediție despre „Omul Anului”. Tradiția, începută în 1927 cu aviatorul Charles Lindbergh, continuă până în zilele noastre. Desemnarea este considerată, de regulă, o onoare, fiind alese persoane cu contribuții importante în viața politică, economică sau socială din lume. Însă în 1938, revista Time l-a numit „Omul Anului” pe dictatorul german Adolf Hitler.</TextBlock>
                        //</StackPanel>

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename='|DataDirectory|\Informatii.mdf';Integrated Security=True");
            try
            {
                SqlCommand comanda = new SqlCommand("select * from CronologieRM2 where Year(DataEveniment)=" + anul_cb.SelectionBoxItem.ToString() + " order by DataEveniment asc", con);
                con.Open();
                m_stack.Children.Clear();
                SqlDataReader dr = comanda.ExecuteReader();
                while (dr.Read())
                {
                    DateTime dt = DateTime.Parse(dr[1].ToString());
                    string titlu = dr[2].ToString();
                    string descriere = dr[3].ToString();
                    //StackPanel
                    StackPanel stackPanel = new StackPanel();

                    //StackPanel_2
                    StackPanel stackPanel_2 = new StackPanel();
                    stackPanel_2.Orientation = Orientation.Horizontal;
                    stackPanel_2.Margin = new Thickness(30, 20, 0, 0);
                    
                    //Border
                    //orderThickness="0.6" Width="100" Height="60" BorderBrush="#FF727272" CornerRadius="1"
                    Border border = new Border();
                    border.BorderThickness = new Thickness(0.6);
                    border.Height = 60;
                    border.Width = 100;
                    var bc = new BrushConverter();
                    border.BorderBrush = (Brush)bc.ConvertFrom("#FF727272");
                    border.CornerRadius = new CornerRadius(1);

                    //stackPanel_3
                    StackPanel stackPanel_3 = new StackPanel();
                    stackPanel_3.Width = 100;
                    stackPanel_3.Height = 60;
                    //<TextBlock FontSize="15" Margin="5,3,0,0" Foreground="#FF3C3C3C"><Run Text="20 Ianuarie"/></TextBlock>
                    //<TextBlock FontSize="30" Margin="5,-5,0,0" Foreground="#FF363636"><Run Text="1939"/></TextBlock>
                    TextBlock textBlock_1=new TextBlock();
                    textBlock_1.FontSize=15;
                    textBlock_1.Margin=new Thickness(5,3,0,0);
                    textBlock_1.Foreground = (Brush)bc.ConvertFrom("#FF3C3C3C");
                    switch (dt.Month)
                    {
                        case 1:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Ianuarie";
                            } break;
                        case 2:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Februarie";
                            } break;
                        case 3:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Martie";
                            } break;
                        case 4:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Aprilie";
                            } break;
                        case 5:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Mai";
                            } break;
                        case 6:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Iunie";
                            } break;
                        case 7:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Iulie";
                            } break;
                        case 8:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " August";
                            } break;
                        case 9:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Septembrie";
                            } break;
                        case 10:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Octombrie";
                            } break;
                        case 11:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Noiembrie";
                            } break;
                        case 12:
                            {
                                textBlock_1.Text = dt.Day.ToString() + " Decembrie";
                            } break;
                    }
                

                    TextBlock textBlock_2 = new TextBlock();
                    textBlock_2.FontSize = 30;
                    textBlock_2.Margin = new Thickness(5, -5, 0, 0);
                    textBlock_2.Foreground = (Brush)bc.ConvertFrom("#FF363636");
                    textBlock_2.Text = anul_cb.SelectionBoxItem.ToString();
                    stackPanel_3.Children.Add(textBlock_1);
                    stackPanel_3.Children.Add(textBlock_2);
                    border.Child = stackPanel_3;
                    stackPanel_2.Children.Add(border);

                    //<TextBlock VerticalAlignment="Bottom" Margin="10,0,0,0" FontSize="30" TextWrapping="Wrap" Foreground="Black">
                    //<TextBlock TextWrapping="Wrap" Margin="140,0,0,0" FontSize="20" Foreground="#FF616161">
                    TextBlock textBlock_3 = new TextBlock();
                    textBlock_3.FontSize = 30;
                    textBlock_3.Margin = new Thickness(10, 0, 0, 0);
                    textBlock_3.Foreground = Brushes.Black;
                    textBlock_3.TextWrapping = TextWrapping.Wrap;
                    textBlock_3.VerticalAlignment = VerticalAlignment.Bottom;
                    textBlock_3.Text = titlu;
                    stackPanel_2.Children.Add(textBlock_3);

                    TextBlock textBlock_4 = new TextBlock();
                    textBlock_4.FontSize = 20;
                    textBlock_4.Margin = new Thickness(140, 0, 0, 0);
                    textBlock_4.Foreground = (Brush)bc.ConvertFrom("#FF616161");
                    textBlock_4.TextWrapping = TextWrapping.Wrap;
                    textBlock_4.Text = descriere;
                    stackPanel.Children.Add(stackPanel_2);
                    stackPanel.Children.Add(textBlock_4);
                    m_stack.Children.Add(stackPanel);
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
        public void dezactiveazaTot()
        {
            cronologie.Visibility = Visibility.Hidden;
            introduce.Visibility = Visibility.Hidden;
            harta_1945.Visibility = Visibility.Hidden;
        }
        private void Label_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            dezactiveazaTot();
            cronologie.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            dezactiveazaTot();
            harta_1945.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            dezactiveazaTot();
            introduce.Visibility = Visibility.Visible;
        }


       
    }
}
