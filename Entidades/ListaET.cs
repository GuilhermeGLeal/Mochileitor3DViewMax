using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class ListaET
    {
        private NoListaET inicio;

        public ListaET()
        {
            inicio = null;
        }

        public NoListaET Inicio { get => inicio; set => inicio = value; }

        public void inserir(double ymax, double xmax, double incrx)
        {
            NoListaET novo = new NoListaET(ymax, xmax, incrx, null, null);
            NoListaET aux = inicio;

            if (aux == null)
                inicio = novo;
            else
            {

                while (aux.Prox != null)
                {
                    aux = aux.Prox;
                }

                aux.Prox = novo;
                novo.Ant = aux;

            }
        }

        public void retirarIgual(double Y)
        {
            NoListaET aux = inicio;
            NoListaET ant;

            while (aux != null)
            {
                ant = aux.Ant;

                if (aux.Ymax1 == Y && inicio == aux)
                {
                    inicio = aux.Prox;
                    if (inicio != null)
                        inicio.Ant = null;
                }
                else if (aux.Ymax1 == Y)
                {
                    ant.Prox = aux.Prox;

                    if (aux != null && aux.Prox != null)
                        aux.Prox.Ant = ant;

                }

                aux = aux.Prox;
            }


        }

        public void ordenaXmin()
        {
            NoListaET aux = inicio, pos;
            double Ymax, Xmin, IncrX;

            while (aux != null)
            {
                Ymax = aux.Ymax1;
                Xmin = aux.Xmin1;
                IncrX = aux.IncrX1;

                pos = aux;

                while (inicio != pos && Xmin < pos.Ant.Xmin1)
                {
                    pos.Ymax1 = pos.Ant.Ymax1;
                    pos.Xmin1 = pos.Ant.Xmin1;
                    pos.IncrX1 = pos.Ant.IncrX1;

                    pos = pos.Ant;
                }

                pos.Ymax1 = Ymax;
                pos.Xmin1 = Xmin;
                pos.IncrX1 = IncrX;

                aux = aux.Prox;
            }
        }
    }
}
