using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Istorie
{
    class CuvantRebus
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cuvant;

        public string Cuvant
        {
            get { return cuvant; }
            set { cuvant = value; }
        }
        private string indiciu;

        public string Indiciu
        {
            get { return indiciu; }
            set { indiciu = value; }
        }
        
    }
}
