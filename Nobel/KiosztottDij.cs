using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    class KiosztottDij
    {
        readonly int ev;
        readonly string tipus;
        readonly string keresztnev;
        readonly string vezeteknev;

        public int Ev => ev;

        public string Tipus => tipus;

        public string Keresztnev => keresztnev;

        public string Vezeteknev => vezeteknev;


        public KiosztottDij(int ev, string tipus, string keresztnev, string vezeteknev)
        {
            this.ev = ev;
            this.tipus = tipus;
            this.keresztnev = keresztnev;
            this.vezeteknev = vezeteknev;
        }
    }
}
