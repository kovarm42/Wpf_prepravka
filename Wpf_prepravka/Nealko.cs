using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Prepravka
{ /// <summary>
/// 
/// </summary>
    internal class Nealko : Napoj
    {
        private double _cena;
        public override double Cena { get { return _cena; } set { Cena = _cena; } }
        public Nealko(double cena) : base(cena)
        {
            this.lahev.Fill = Brushes.Blue;
            this._cena = cena * 1.21;
        }
    }
}
