using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektkonzol
{
    class Felkeszito
    {
        public string Nev { get; set; }
        public int Kor {  get; set; }
        public string Nem { get; set; }
        public string[] Lakcim { get; set; }
        public string VaVi { get; set; }
        public string Kolleg { get; set; }
        public string Bejar { get; set; }
        public string Szemszam { get; set; }
        public string Gondviselo { get; set; }
        public string Email { get; set; }
        public string Tel {  get; set; }
        public string GondTel { get; set; }

        public Felkeszito(string[] temp)
        {
            Nev = temp[0];
            Kor = int.Parse(temp[1]);
            Nem = temp[2];
            Lakcim = temp[3].Split(',');
            VaVi = temp[4];
            Kolleg = temp[5];
            Bejar = temp[6];
            Szemszam = (temp[7]);
            Gondviselo = temp[8];
            Email = temp[9];
            Tel = temp[10];
            GondTel = temp[11];
        }
    }
}
