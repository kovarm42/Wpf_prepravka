using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Prepravka
{
    internal class Alko : Napoj
    {

        private double _cena;
        public override double Cena { get { return _cena; } set { Cena = _cena; } }
        public Alko(double cena) : base(cena)
        {
            this.lahev.Fill = Brushes.Green;
            this._cena = cena * 1.5;
        }

    }
}
