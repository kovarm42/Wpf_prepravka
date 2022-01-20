using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Prepravka
{
    internal class Box
    {
        Canvas canvas;
        Napoj [,] box;
        double prumerLahve;
        public int sirka { get; }
        public int vyska { get; }

        public Box(int x, int y, Canvas canvas)
        {
            this.canvas = canvas;
            this.sirka = y;
            this.vyska = x;
            this.box = new Napoj [x, y];
            if (canvas.ActualHeight / x < canvas.ActualWidth/y)
            {
                prumerLahve = canvas.Height / (x + 1);
            }
            else
            {
                prumerLahve = canvas.Width / (y + 1);
            }
        }

        public void PridejNapoj(Napoj napoj, int x, int y)
        {
            if (box[x-1, y-1] is not null){
                throw new Exception("Pozice je obsazená");
            } else
            {
                box.SetValue(napoj, x-1, y-1);
                napoj.lahev.Width = prumerLahve;
                napoj.lahev.Height = prumerLahve;
                Canvas.SetLeft(napoj.lahev, (y * prumerLahve) - ((canvas.Width - (box.GetLength(1) * prumerLahve))/2));
                Canvas.SetTop(napoj.lahev, ((x-1) * prumerLahve) + ((canvas.Height - (box.GetLength(0) * prumerLahve)) / 2));
                canvas.Children.Add(napoj.lahev);
            }
        }

        public void OdeberNapoj(int x, int y)
        {
            if (box[x-1, y-1] is null)
            {
                throw new Exception("Žádná lahev tu není");
            }
            else
            {
                Napoj napoj = box[x - 1, y - 1];
                box.SetValue(null, x-1, y-1);
                canvas.Children.Remove(napoj.lahev);
            }
        }

        public double CelkovaCena()
        {
            double sumCena = 0;
            foreach (Napoj napoj in box)
            {
                if (napoj is not null)
                {
                    sumCena += napoj.Cena;
                }
            }
            return sumCena;
        }
    }
}
