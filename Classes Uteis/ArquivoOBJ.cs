using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class ArquivoOBJ
    {
        private string caminho;
        private StreamReader arquivo;
        private Objeto3D objeto;

        public Objeto3D getObj()
        {
            return objeto;
        }

      
        public ArquivoOBJ(string caminho)
        {
            this.caminho = caminho;
            this.arquivo = new StreamReader(caminho);
            this.objeto = new Objeto3D();
        }

        public void lerArquivo()
        {
            string texto = "";
            int cont = 0;

            while (!arquivo.EndOfStream)
            {
                texto = arquivo.ReadLine();

                if(texto.Length > 0)
                {
                    if (texto[0] == 'v')
                    {
                        if (texto[1] == ' ')
                            leuVertice(texto);
                        else
                            leuNormalV(texto);
                    }
                    else if (texto[0] == 'f')
                    {
                        leuFace(texto, cont);
                        cont++;
                    }
                }
               

                   
            }
        }

        private void leuVertice(string texto)
        {
            Ponto pontNovo = new Ponto();
            double xAux = 0, yAux = 0, zAux = 0;
            string stringAux = "";
            int cont = 0;
           
            int i = 2;

            while (i < texto.Length)
            {
                if(texto[i] != ' ')
                {
                    if(texto[i] == 'E')
                    {
                        stringAux = stringAux.Replace('.', ',');
                        zAux = double.Parse(stringAux);
                        stringAux = "";
                        i = texto.Length;
                    }
                    else
                    {
                        stringAux += texto[i];
                    }

                  
                }
                else
                {
                    stringAux = stringAux.Replace('.', ',');

                    if(cont == 0)
                        xAux = double.Parse(stringAux);
                    else if(cont == 1)
                        yAux = double.Parse(stringAux);
                                                                

                    cont++;
                    stringAux = "";
                }

                i++;
            }

            if(stringAux.Length > 0)
            {
                stringAux = stringAux.Replace('.', ',');
                zAux = double.Parse(stringAux);
            }

            pontNovo.X = xAux;
            pontNovo.Y = yAux;
            pontNovo.Z = zAux;

            objeto.setVerticesOrig(pontNovo);
            objeto.setVerticeAtual(pontNovo);

        }

        private void leuFace(string texto, int cont)
        {
            int indice = 0;
            string stringAux = "";
            int i = 2;

            while(i< texto.Length)
            {
                if(texto[i] != ' ' && texto[i] != '/')
                {
                    stringAux += texto[i];
                }
                else
                {
                    if(texto[i] == '/' && stringAux.Length > 0)
                    {
                        indice = int.Parse(stringAux);
                     
                        objeto.setFaces(cont, indice-1);
                    }

                    stringAux = "";
                }

                i++;
            }
        }

        private void leuNormalV(string texto)
        {

        }

        private void leuNormalF(string texto)
        {

        }

        public void inicializar()
        {
            objeto = new Objeto3D();
        }
    }
}
