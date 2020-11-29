using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class NoListaET
    {
        private double Ymax, Xmin, IncrX;
        private NoListaET prox, ant;

        public NoListaET(double ymax, double xmin, double incrX, NoListaET prox, NoListaET ant)
        {
            Ymax = ymax;
            Xmin = xmin;
            IncrX = incrX;
            this.prox = prox;
            this.ant = ant;
        }

        public NoListaET()
        {
        }

        public double Ymax1 { get => Ymax; set => Ymax = value; }
        public double Xmin1 { get => Xmin; set => Xmin = value; }
        public double IncrX1 { get => IncrX; set => IncrX = value; }
        public NoListaET Prox { get => prox; set => prox = value; }

        public NoListaET Ant { get => ant; set => ant = value; }
    }
}
