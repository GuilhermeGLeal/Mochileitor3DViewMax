using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class Face
    {
        private NoFace inicio;

        public Face()
        {
            this.inicio = null;
        }

        public NoFace getInicio()
        {
            return this.inicio;

        }

        public void inserir(int indice)
        {
            NoFace novo = new NoFace(indice, null);
            NoFace aux = inicio;

            if (aux == null)
                inicio = novo;
            else
            {
                while (aux.Prox != null)
                {
                    aux = aux.Prox;
                }

                aux.Prox = novo;
            }
            
        }
    }
}
