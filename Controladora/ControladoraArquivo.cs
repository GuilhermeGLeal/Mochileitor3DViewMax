using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView.Controladora
{
    class ControladoraArquivo
    {
        private ArquivoOBJ arqv;

        public ControladoraArquivo(string path)
        {
            this.arqv = new ArquivoOBJ(path);
        }

        public Ponto retornaPespectiva(Ponto pontAtual, int d)
        {
            Ponto novoPonto = new Ponto();

            novoPonto.X = (pontAtual.X * d) / (pontAtual.Z + d);
            novoPonto.Y = (pontAtual.Y * d) / (pontAtual.Z + d);

            return novoPonto;
        }
               
           

        public Ponto cavaleiraCabinetObli(Ponto pontAtual, bool opcao)
        {
            double[,] matrizOb = new double[4, 4];
            double[,] novoPonto = new double[4, 1];
            double[,] pontosOri = new double[4, 1];
            double soma;

            if (opcao)
            {
                matrizOb[0, 0] = matrizOb[1, 1] = matrizOb[3, 3] = 1;
                matrizOb[0, 2] = Math.Cos(45.0 * Math.PI / 180.0);
                matrizOb[1, 2] = Math.Sin(45.0 * Math.PI / 180.0);
            }
            else
            {
                matrizOb[0, 0] = matrizOb[1, 1] = matrizOb[3, 3] = 1;
                matrizOb[0, 2] = 0.5 * Math.Cos(45.0 * Math.PI / 180.0);
                matrizOb[1, 2] = 0.5 * Math.Sin(45.0 * Math.PI / 180.0);
            }

            pontosOri[0, 0] = pontAtual.X;
            pontosOri[1, 0] = pontAtual.Y;
            pontosOri[2, 0] = pontAtual.Z;
            pontosOri[3, 0] = 1.0;

            for (int linha = 0; linha < 4; linha++)
            {

                for (int coluna = 0; coluna < 1; coluna++)
                {
                    soma = 0;

                    for (int k = 0; k < 4; k++)
                    {
                        soma += matrizOb[linha, k] * pontosOri[k, coluna];
                    }

                    novoPonto[linha, coluna] = Math.Round(soma);
                }

            }

            pontAtual.X = novoPonto[0, 0];
            pontAtual.Y = novoPonto[1, 0];

            return pontAtual;
        }               

        public Ponto validaPonto(string opcao, int d, Ponto pontAtual)
        {
            
            switch (opcao)
            {
                case "PERSPECTIVA":
                    pontAtual = retornaPespectiva(pontAtual, d);
                    break;
                case "LATERAL":
                    pontAtual.X = pontAtual.Z;
                    break;
                case "PLANTA":
                    pontAtual.Y = pontAtual.Z;
                    break;
                case "CAVALEIRA":
                    pontAtual = cavaleiraCabinetObli(pontAtual, true);
                    break;
                case "CABINET":
                    pontAtual = cavaleiraCabinetObli(pontAtual, false);
                    break;
                
            }

            return pontAtual;
        }

        public void verificaDesenho(bool check, Bitmap imgPrincipal, string opcao, int d)
        {
            if (check)
            {
                desenha(imgPrincipal, opcao, d);
            }
            else
            {
                desenha2(imgPrincipal, opcao, d);
            }
        }

        public void desenha2(Bitmap imgPrincipal, string opcao, int d)
        {
            List<int> indices;
            Ponto pont1, pont2;
            int xini, xfim, yini, yfim;
            double result;

            for (int i = 0; i < arqv.getObj().getQtdFaces(); i++)
            {

                pont1 = arqv.getObj().getnormaisFace(i);
                result = pont1.Z * 1.0;

                if(result >= 0)
                {
                    indices = arqv.getObj().retornaIndices(i);

                    for (int j = 0; j < indices.Count; j++)
                    {
                        if (j == indices.Count - 1)
                        {
                            pont1 = arqv.getObj().getVerticeAtual(indices[j]);
                            pont2 = arqv.getObj().getVerticeAtual(indices[0]);
                        }
                        else
                        {
                            pont1 = arqv.getObj().getVerticeAtual(indices[j]);
                            pont2 = arqv.getObj().getVerticeAtual(indices[j + 1]);
                        }

                        pont1 = validaPonto(opcao, d, pont1);
                        pont2 = validaPonto(opcao, d, pont2);

                        xini = (int)(pont1.X + imgPrincipal.Width / 2.0);
                        xfim = (int)(pont2.X + imgPrincipal.Width / 2.0);
                        yini = (int)(pont1.Y + imgPrincipal.Height / 2.0);
                        yfim = (int)(pont2.Y + imgPrincipal.Height / 2.0);

                        MetodosParaDesenho.bresenham2(imgPrincipal, xini, xfim, yini, yfim);
                    }
                }
               
            }
        }

        public void desenha(Bitmap imgPrincipal, string opcao, int d)
        {
            List<int> indices;
            Ponto pont1, pont2;
            int xini, xfim, yini, yfim;

            for (int i = 0; i < arqv.getObj().getQtdFaces(); i++)
            {
                indices = arqv.getObj().retornaIndices(i);

                for (int j = 0; j < indices.Count; j++)
                {
                    if(j == indices.Count-1)
                    {
                        pont1 = arqv.getObj().getVerticeAtual(indices[j]);
                        pont2 = arqv.getObj().getVerticeAtual(indices[0]);
                    }
                    else
                    {
                        pont1 = arqv.getObj().getVerticeAtual(indices[j]);
                        pont2 = arqv.getObj().getVerticeAtual(indices[j + 1]);
                    }

                    pont1 = validaPonto(opcao, d, pont1);
                    pont2 = validaPonto(opcao, d, pont2);

                    xini = (int)(pont1.X + imgPrincipal.Width / 2.0);
                    xfim = (int)(pont2.X + imgPrincipal.Width / 2.0);
                    yini = (int)(pont1.Y + imgPrincipal.Height / 2.0);
                    yfim = (int)(pont2.Y + imgPrincipal.Height / 2.0);

                    MetodosParaDesenho.bresenham2(imgPrincipal, xini, xfim, yini, yfim);
                }
            }
        }

        public void escalaPlus()
        {
            arqv.getObj().escala(1);
            arqv.getObj().aplicarMA();
            arqv.getObj().calcularNormais();

        }

        public void escalaMinus()
        {
            arqv.getObj().escala(-1);
            arqv.getObj().aplicarMA();
            arqv.getObj().calcularNormais();
        }

        public void rotacaoEmX()
        {
            arqv.getObj().chamarotacaoX();
            arqv.getObj().aplicarMA();
            arqv.getObj().calcularNormais();

        }

        public void rotacaoEmY()
        {
            arqv.getObj().chamarotacaoY();
            arqv.getObj().aplicarMA();
            arqv.getObj().calcularNormais();

        }

        public void rotacaoEmZ()
        {
            arqv.getObj().chamarotacaoZ();
            arqv.getObj().aplicarMA();
            arqv.getObj().calcularNormais();
            
        }

        public void leArquivo()
        {
            arqv.lerArquivo();
          
        }

        public void inicializar()
        {
            arqv.inicializar();
        }
    }
}
