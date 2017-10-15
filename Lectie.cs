using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istorie
{
    public class Lectie
    {
        private string denume;

        public string Denumire
        {
            get { return denume; }
            set { denume = value; }
        }
        private string descriere;

        public string Descriere
        {
            get { return descriere; }
            set { descriere = value; }
        }
        private string textLectie;

        public string TextLectie
        {
            get { return textLectie; }
            set { textLectie = value; }
        }
        private string caleImagine;

        public string CaleImagine
        {
            get { return caleImagine; }
            set { caleImagine = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
