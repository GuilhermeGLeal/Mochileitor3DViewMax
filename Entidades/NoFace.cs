using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class NoFace
    {
        private int indice;
        private NoFace prox;

        public NoFace()
        {
        }

        public NoFace(int indice, NoFace prox)
        {
            this.indice = indice;
            this.prox = prox;
        }

        public int Indice { get => indice; set => indice = value; }
        public NoFace Prox { get => prox; set => prox = value; }
    }
}
