using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class Objeto3D
    {
        private double[,] matrizMa;
        private List<Ponto> verticesOriginais;
        private List<Ponto> verticesAtuais;
        private Face[] faces;
        private List<Ponto> normaisFace;
        private List<Ponto> normaisVertices;
        private int qtdFaces;
        private int k = 4;

        public Objeto3D()
        {
            matrizMa = new double[4, 4];

            matrizMa[0, 0] = 1;
            matrizMa[1, 1] = 1;
            matrizMa[2, 2] = 1;
            matrizMa[3, 3] = 1;

            faces = new Face[10000];
            verticesOriginais = new List<Ponto>();
            verticesAtuais = new List<Ponto>();
            normaisFace = new List<Ponto>();
            normaisVertices = new List<Ponto>();

            qtdFaces = 0;
           
        }

      

        // getters
        public Ponto getVerticeOrig(int pos)
        {
            return this.verticesOriginais[pos]; 
        }

        public Ponto getVerticeAtual(int pos)
        {
            return this.verticesAtuais[pos];
        }

        public Ponto getnormaisFace(int pos)
        {
            return this.normaisFace[pos];
        }

        public Ponto getnormaisVertices(int pos)
        {
            return this.normaisVertices[pos];
        }

        public int getQtdFaces()
        {
            return qtdFaces;
        }
        // setters

        public void setVerticesOrig(Ponto pont)
        {
            this.verticesOriginais.Add(pont);
        }

        public void setVerticeAtual(Ponto pont)
        {
            this.verticesAtuais.Add(pont);
        }

        public void setnormaisFace(Ponto pont)
        {
            this.normaisFace.Add(pont);
        }

        public void setnormaisVertices(Ponto pont)
        {
            this.normaisVertices.Add(pont);
        }

        public void setFaces(int pos, int indice)
        {
            if (faces[pos] == null)
            {
                this.faces[pos] = new Face();
                qtdFaces++;
            }
           

            this.faces[pos].inserir(indice);
        }

        public List<int> retornaIndices(int pos)
        {
            List<int> indicesPos = new List<int>();
            NoFace aux = this.faces[pos].getInicio();

            while(aux != null)
            {
                indicesPos.Add(aux.Indice);
                aux = aux.Prox;
            }

            return indicesPos;

        }


        //-------------------------- TRANSFORMAÇÕES

        private double[,] retMatAux(double[,] matrizAcumulada)
        {
            double[,] matrizAux = new double[k, k];

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    matrizAux[i, j] = matrizAcumulada[i, j];
                }
            }
            return matrizAux;
        }

        public void translacao(double X, double Y, double Z)
        {

            double[,] matrizTrans = new double[k, k];
            double[,] matrizAux;

            double soma;
            matrizTrans[0, 0] = 1.0;
            matrizTrans[1, 1] = 1.0;
            matrizTrans[2, 2] = 1.0;
            matrizTrans[3, 3] = 1.0;
            matrizTrans[0, 3] = X;
            matrizTrans[1, 3] = Y;
            matrizTrans[2, 3] = Z;

            matrizAux = retMatAux(matrizMa);

            for (int linha = 0; linha < k; linha++)
            {
                for (int coluna = 0; coluna < k; coluna++)
                {
                    soma = 0;

                    for (int k = 0; k < this.k; k++)
                    {
                        soma += matrizTrans[linha, k] * matrizAux[k, coluna];
                    }

                    this.matrizMa[linha, coluna] = soma;
                }
            }


        }

        public double retornaCX()
        {
            double somaX = 0;

            for (int i = 0; i < verticesAtuais.Count; i++)
            {
                somaX += verticesAtuais[i].X;
            }

            return somaX / verticesAtuais.Count;
        }

        public double retornaCZ()
        {
            double somaZ = 0;

            for (int i = 0; i < verticesAtuais.Count; i++)
            {
                somaZ += verticesAtuais[i].Z;
            }

            return somaZ / verticesAtuais.Count;
        }

        public double retornaCY()
        {
            double somaY = 0;

            for (int i = 0; i < verticesAtuais.Count; i++)
            {
                somaY += verticesAtuais[i].Y;
            }

            return somaY / verticesAtuais.Count;
        }

        public void rotacaoZ(int sinal)
        {
            this.translacao(-retornaCX(), -retornaCY(), - retornaCZ());
            this.chamarotacaoZ(sinal);
            this.translacao(retornaCX(), retornaCY(), retornaCZ());
        }

        public void chamarotacaoZ(int sinal)
        {
            double rad = 5.0 * Math.PI / 180.0;
            double[,] matrizAngulo = new double[k, k];
            double soma;

            rad = rad * sinal;
            matrizAngulo[0, 0] = Math.Cos(rad);
            matrizAngulo[0, 1] = -Math.Sin(rad);
            matrizAngulo[1, 0] = Math.Sin(rad);
            matrizAngulo[1, 1] = Math.Cos(rad);
            matrizAngulo[2, 2] = 1.0;
            matrizAngulo[3, 3] = 1.0;

            double[,] matrizAux = retMatAux(this.matrizMa);


            for (int linha = 0; linha < k; linha++)
            {
                for (int coluna = 0; coluna < k; coluna++)
                {
                    soma = 0;

                    for (int k = 0; k < this.k; k++)
                    {
                        soma += matrizAngulo[linha, k] * matrizAux[k, coluna];
                    }

                    this.matrizMa[linha, coluna] = soma;
                }
            }

        }

        public void rotacaoY(int sinal)
        {
            this.translacao(-retornaCX(), -retornaCY(), -retornaCZ());
            this.chamarotacaoY(sinal);
            this.translacao(retornaCX(), retornaCY(), retornaCZ());
        }

        public void chamarotacaoY(int sinal)
        {
            double rad = 5.0 * Math.PI / 180.0;
            double[,] matrizAngulo = new double[k, k];
            double soma;

            rad = rad * sinal;

            matrizAngulo[0, 0] = Math.Cos(rad);
            matrizAngulo[0, 2] = Math.Sin(rad);
            matrizAngulo[2, 0] = -Math.Sin(rad);
            matrizAngulo[1, 1] = 1;
            matrizAngulo[2, 2] = Math.Cos(rad);
            matrizAngulo[3, 3] = 1.0;

            double[,] matrizAux = retMatAux(this.matrizMa);


            for (int linha = 0; linha < k; linha++)
            {
                for (int coluna = 0; coluna < k; coluna++)
                {
                    soma = 0;

                    for (int k = 0; k < this.k; k++)
                    {
                        soma += matrizAngulo[linha, k] * matrizAux[k, coluna];
                    }

                    this.matrizMa[linha, coluna] = soma;
                }
            }

        }

        public void rotacaoX(int sinal)
        {
            this.translacao(-retornaCX(), -retornaCY(), -retornaCZ());
            this.chamarotacaoX(sinal);
            this.translacao(retornaCX(), retornaCY(), retornaCZ());
        }

        public void chamarotacaoX(int sinal)
        {
            double rad = 20.0 * Math.PI / 180.0;
            double[,] matrizAngulo = new double[k, k];
            double soma;

            rad = rad * sinal;

            matrizAngulo[0, 0] = 1;
            matrizAngulo[1, 1] = Math.Cos(rad);
            matrizAngulo[1, 2] = -Math.Sin(rad);
            matrizAngulo[2, 1] = Math.Sin(rad);
            matrizAngulo[2, 2] = Math.Cos(rad);
            matrizAngulo[3, 3] = 1.0;

            double[,] matrizAux = retMatAux(this.matrizMa);


            for (int linha = 0; linha < k; linha++)
            {
                for (int coluna = 0; coluna < k; coluna++)
                {
                    soma = 0;

                    for (int k = 0; k < this.k; k++)
                    {
                        soma += matrizAngulo[linha, k] * matrizAux[k, coluna];
                    }

                    this.matrizMa[linha, coluna] = soma;
                }
            }

        }

        public void escala(double multi)
        {
            this.translacao(-retornaCX(), -retornaCY(), -retornaCZ());
            this.chamaescala(multi);
            this.translacao(retornaCX(), retornaCY(), retornaCZ());
        }

        public void chamaescala(double multi)
        {
            double[,] matrizEscala = new double[k, k];

            matrizEscala[0, 0] = multi;
            matrizEscala[1, 1] = multi;
            matrizEscala[2, 2] = multi;
            matrizEscala[3, 3] = 1.0;

            double soma;
            double[,] matrizAux = retMatAux(this.matrizMa);

            for (int linha = 0; linha < k; linha++)
            {
                for (int coluna = 0; coluna < k; coluna++)
                {
                    soma = 0;

                    for (int k = 0; k < this.k; k++)
                    {
                        soma += matrizEscala[linha, k] * matrizAux[k, coluna];
                    }

                    this.matrizMa[linha, coluna] = soma;
                }
            }
        }

        public void aplicarMA()
        {
            double[,] pontosOrig = new double[4, 1];
            double[,] novoPonto = new double[4, 1];
            double soma;


            for (int i = 0; i < verticesOriginais.Count; i++)
            {
                pontosOrig[0, 0] = verticesOriginais[i].X;
                pontosOrig[1, 0] = verticesOriginais[i].Y;
                pontosOrig[2, 0] = verticesOriginais[i].Z;
                pontosOrig[3, 0] = 1.0;

                for (int linha = 0; linha < 4; linha++)
                {

                    for (int coluna = 0; coluna < 1; coluna++)
                    {
                        soma = 0;

                        for (int k = 0; k < 4; k++)
                        {
                            soma += matrizMa[linha,k] * pontosOrig[k, coluna];
                        }

                        novoPonto[linha, coluna] = Math.Round(soma);
                    }

                }

                this.verticesAtuais[i].X = novoPonto[0, 0];
                this.verticesAtuais[i].Y = novoPonto[1, 0];
                this.verticesAtuais[i].Z = novoPonto[2, 0];
            }
        }

        //--------------------------------- CALCULOS

        public Ponto retornaVetorFinal(double[,] matrizDeterm)
        {
            Ponto vetorFinal = new Ponto();
            double posI, posJ, posK;

            posI = (matrizDeterm[1, 1] + matrizDeterm[2, 2]) - (matrizDeterm[1,2] + matrizDeterm[2,1]);
            posJ = (matrizDeterm[1, 2] + matrizDeterm[2, 0]) - (matrizDeterm[1,0] + matrizDeterm[2,2]);
            posK = (matrizDeterm[1,0] + matrizDeterm[2,1]) - (matrizDeterm[1,1] + matrizDeterm[2,0]);

            vetorFinal.X = posI;
            vetorFinal.Y = posJ;
            vetorFinal.Z = posK;

            return vetorFinal;
        }

        public Ponto retornaVetor1(List<int> indices)
        {
            Ponto vetor01 = new Ponto();
            Ponto aux1, aux2;

            aux1 = this.getVerticeAtual(indices[0]);
            aux2 = this.getVerticeAtual(indices[1]);

            vetor01.X = aux2.X - aux1.X;
            vetor01.Y = aux2.Y - aux1.Y;
            vetor01.Z = aux2.Z - aux1.Z;

            return vetor01;
        }

        public Ponto retornaVetor2(List<int> indices)
        {
            Ponto vetor03 = new Ponto();
            Ponto aux1, aux2;

            aux1 = this.getVerticeAtual(indices[0]);
            aux2 = this.getVerticeAtual(indices[indices.Count-1]);

            vetor03.X = aux2.X - aux1.X;
            vetor03.Y = aux2.Y - aux1.Y;
            vetor03.Z = aux2.Z - aux1.Z;

            return vetor03;
        }

        public void calcularNormais()
        {
            List<int> indices;
            Ponto vetor01;
            Ponto vetor03;
            Ponto vetorFinal;
            double [,]matrizDeterm = new double[3,3];
            double tamVetor;

            for (int i = 0; i < this.qtdFaces; i++)
            {
                indices = this.retornaIndices(i);

                vetor01 = retornaVetor1(indices);
                vetor03 = retornaVetor2(indices);
                              
                matrizDeterm[1, 0] = vetor01.X; matrizDeterm[1, 1] = vetor01.Y; matrizDeterm[1, 2] = vetor01.Z;
                matrizDeterm[2, 0] = vetor03.X; matrizDeterm[2, 1] = vetor03.Y; matrizDeterm[2, 2] = vetor03.Z;

                vetorFinal = retornaVetorFinal(matrizDeterm);

                tamVetor = Math.Sqrt(Math.Pow(vetorFinal.X, 2.0) + Math.Pow(vetorFinal.Y, 2.0) + Math.Pow(vetorFinal.Z, 2.0));

                vetorFinal.X = vetorFinal.X / tamVetor;
                vetorFinal.Y = vetorFinal.Y / tamVetor;
                vetorFinal.Z = vetorFinal.Z / tamVetor;

                this.setnormaisFace(vetorFinal);
            }
        }

        //--------------------------------- SCAN LINE
        private int retornaYMax()
        {
            double x = 0;

            for (int i = 0; i < verticesAtuais.Count; i++)
            {
                if (verticesAtuais[i].Y > x)
                    x = verticesAtuais[i].Y;
            }

            return (int)x;
        }

        private void carregaListaET(Bitmap imageBitSrc)
        {
            int tamLista = retornaYMax();
            ListaET[] listas = new ListaET[tamLista + 1];
            double Ymax = 0, Xmim = 0, incrX = 0, dy, dx, Ymin;

            for (int i = 0; i < verticesAtuais.Count - 1; i++)
            {
                if (verticesAtuais[i].Y < verticesAtuais[i + 1].Y)
                {
                    Ymax = verticesAtuais[i + 1].Y;
                    Xmim = verticesAtuais[i].X;
                    Ymin = verticesAtuais[i].Y;

                    dy = Ymax - Ymin;
                    dx = verticesAtuais[i + 1].X - Xmim;
                }
                else
                {
                    Ymax = verticesAtuais[i].Y;
                    Xmim = verticesAtuais[i + 1].X;
                    Ymin = verticesAtuais[i + 1].Y;

                    dy = Ymax - Ymin;
                    dx = verticesAtuais[i].X - Xmim;
                }

                incrX = dx / dy;
                if (listas[(int)Ymin] == null)
                    listas[(int)Ymin] = new ListaET();

                listas[(int)Ymin].inserir(Ymax, Xmim, incrX);
            }

            if (verticesAtuais[0].Y < verticesAtuais[verticesAtuais.Count - 1].Y)
            {
                Ymax = verticesAtuais[verticesAtuais.Count - 1].Y;
                Xmim = verticesAtuais[0].X;
                Ymin = verticesAtuais[0].Y;

                dy = Ymax - Ymin;
                dx = verticesAtuais[verticesAtuais.Count - 1].X - Xmim;
            }
            else
            {
                Ymax = verticesAtuais[0].Y;
                Xmim = verticesAtuais[verticesAtuais.Count - 1].X;
                Ymin = verticesAtuais[verticesAtuais.Count - 1].Y;

                dy = Ymax - Ymin;
                dx = verticesAtuais[0].X - Xmim;
            }

            incrX = dx / dy;
            if (listas[(int)Ymin] == null)
                listas[(int)Ymin] = new ListaET();
            listas[(int)Ymin].inserir(Ymax, Xmim, incrX);

            criaAET(imageBitSrc, listas);
        }

        private void retornaET(ListaET[] listas, ListaET AET, ref int y)
        {
            NoListaET aux;

            if (y == -1)
            {
                for (int i = 0; i < listas.Length; i++)
                {
                    if (listas[i] != null)
                    {
                        y = i;

                        aux = listas[i].Inicio;
                        while (aux != null)
                        {
                            AET.inserir(aux.Ymax1, aux.Xmin1, aux.IncrX1);
                            aux = aux.Prox;
                        }


                        break;
                    }
                }
            }
            else
            {
                if (listas[y] != null)
                {
                    aux = listas[y].Inicio;

                    while (aux != null)
                    {
                        AET.inserir(aux.Ymax1, aux.Xmin1, aux.IncrX1);
                        aux = aux.Prox;
                    }
                }
            }
        }

        private void incrementaXMIN(ListaET AET)
        {
            NoListaET aux = AET.Inicio;

            while (aux != null)
            {
                aux.Xmin1 += aux.IncrX1;
                aux = aux.Prox;
            }
        }

        private void pintarValores(ListaET AET, Bitmap imageBitSrc, int y)
        {
            NoListaET cx1, cx2;
            cx1 = AET.Inicio;
            cx2 = AET.Inicio.Prox;

            while (cx2 != null)
            {
                for (int i = (int)cx1.Xmin1; i < cx2.Xmin1; i++)
                {
                    imageBitSrc.SetPixel(i, y, Color.FromArgb(150, 150, 150));
                }

                cx1 = cx1.Prox.Prox;
                cx2 = cx1 == null ? null : cx2.Prox.Prox;
            }

        }

        private void criaAET(Bitmap imageBitSrc, ListaET[] listas)
        {
            try
            {
                ListaET AET = new ListaET();
                int Y = -1;

                retornaET(listas, AET, ref Y);

                while (AET.Inicio != null)
                {
                    AET.retirarIgual(Y); // retirar y == ymax

                    if (AET.Inicio != null)
                    {
                        AET.ordenaXmin(); // ordernar a AET pelo xmin de forma crescente
                        pintarValores(AET, imageBitSrc, Y); // desenhar aos pares na lista AET, de xmin até xmin
                        incrementaXMIN(AET); // incrementar o xmin de cada caixa com seu incrx respectivo
                        Y++; // Y++
                        retornaET(listas, AET, ref Y);// chamar o retornaET passado o Y
                    }

                }
            }
            catch (Exception e) { }

        }

        // transformações

    }
}
