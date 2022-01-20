using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Prepravka
{
    internal class Napoj
    {
        private double _cenaBezDan;
        private double _cena;
        public virtual double Cena { set { _cena = _cenaBezDan * 1; } get { return _cena; } }
        public Ellipse lahev { get; }

        public Napoj(double cena)
        {
            _cenaBezDan = cena;
            lahev = new Ellipse();
        }

    }
}
