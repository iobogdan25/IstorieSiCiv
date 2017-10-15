using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace Istorie
{
    public class IntrebareGrila
    {
        #region declarari
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        private string intrebare;

        public string Intrebare
        {
            get { return intrebare; }
            set { intrebare = value; }
        }
        private string raspuns_1;

        public string Raspuns_1
        {
            get { return raspuns_1; }
            set { raspuns_1 = value; }
        }
        private string raspuns_2;

        public string Raspuns_2
        {
            get { return raspuns_2; }
            set { raspuns_2 = value; }
        }
        private string raspuns_3;

        public string Raspuns_3
        {
            get { return raspuns_3; }
            set { raspuns_3 = value; }
        }
        private string raspuns_4;

        public string Raspuns_4
        {
            get { return raspuns_4; }
            set { raspuns_4 = value; }
        }
        private bool isCorect_1;

        public bool IsCorect_1
        {
            get { return isCorect_1; }
            set { isCorect_1 = value; }
        }
        private bool isCorect_2;

        public bool IsCorect_2
        {
            get { return isCorect_2; }
            set { isCorect_2 = value; }
        }
        private bool isCorect_3;

        public bool IsCorect_3
        {
            get { return isCorect_3; }
            set { isCorect_3 = value; }
        }
        private bool isCorect_4;

        public bool IsCorect_4
        {
            get { return isCorect_4; }
            set { isCorect_4 = value; }
        }
        #endregion
        public IntrebareGrila()
        {
        }
        public IntrebareGrila(int _id,string intrebare, string raspunsuri)
        {
            try
            {
                //intrebari=[i:intrebare][r:raspuns][r:raspuns]...[r:raspuns]
                //raspunsuri=0;1;0;0;
                this.id = _id;
                int indexOfI = intrebare.IndexOf("]");
                this.intrebare = intrebare.Substring(3, indexOfI - 3);
                int indexOfR1 = intrebare.IndexOf("]", indexOfI + 1);
                this.raspuns_1 = intrebare.Substring(indexOfI + 4, indexOfR1 - indexOfI - 4);
                int indexOfR2 = intrebare.IndexOf("]", indexOfR1 + 1);
                this.raspuns_2 = intrebare.Substring(indexOfR1 + 4, indexOfR2 - indexOfR1 - 4);
                int indexOfR3 = intrebare.IndexOf("]", indexOfR2 + 1);
                this.raspuns_3 = intrebare.Substring(indexOfR2 + 4, indexOfR3 - indexOfR2 - 4);
                int indexOfR4 = intrebare.IndexOf("]", indexOfR3 + 1);
                this.raspuns_4 = intrebare.Substring(indexOfR3 + 4, indexOfR4 - indexOfR3 - 4);
                this.isCorect_1 = Convert.ToBoolean(Convert.ToInt16(raspunsuri.Substring(0, 1)));
                this.isCorect_2 = Convert.ToBoolean(Convert.ToInt16(raspunsuri.Substring(2, 1)));
                this.isCorect_3 = Convert.ToBoolean(Convert.ToInt16(raspunsuri.Substring(4, 1)));
                this.isCorect_4 = Convert.ToBoolean(Convert.ToInt16(raspunsuri.Substring(6, 1)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
