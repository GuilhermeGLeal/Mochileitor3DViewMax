using Mochileitor3DView.Controladora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mochileitor3DView
{
    public partial class Form1 : Form
    {
        private ControladoraArquivo control;
        private Bitmap imgPrincipal;
        private int xaux, yaux;
        private Boolean ctrl,shift,clicado;

        public Form1()
        {
            InitializeComponent();
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            picBoxPrincp.Image = imgPrincipal;
            this.ctrl = this.clicado = this.shift = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFDialog.Filter = "obj files (*.obj)|*.obj";
            openFDialog.FilterIndex = 0;

            if(openFDialog.ShowDialog() == DialogResult.OK)
            {
                control = new ControladoraArquivo(openFDialog.FileName);
                control.leArquivo();
                control.desenha(imgPrincipal,"",100);
                picBoxPrincp.Image = imgPrincipal;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btFecharArquivo_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            picBoxPrincp.Image = imgPrincipal;
            control.inicializar();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            //control.rotacaoEmX();
            //   control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal);
            picBoxPrincp.Image = imgPrincipal;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.translacaoXY(-1,-1);
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "", 100);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.translacaoXY(1,1);
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal,"",100);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.rotacaoXY(1,1);
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal,"",100);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.rotacaoXY(-1,-1);
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal,"",100);
            picBoxPrincp.Image = imgPrincipal;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            
            if(ctrl)
            {
                if (e.Delta > 0)
                    control.translacaoZ(1);
                else
                    control.translacaoZ(-1);
            }
            else if(shift)
            {
                if (e.Delta > 0)
                    control.rotacaoEmZ(1);
                else
                    control.rotacaoEmZ(-1);
            }
            else
            {
                if (e.Delta > 0)
                    control.escalaPlus();
                else
                    control.escalaMinus();
            }
           
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "", 100);
            picBoxPrincp.Image = imgPrincipal;          
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                this.ctrl = true;
            }
            if(e.Shift)
            {
                this.shift = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(!e.Control)
            {
                this.ctrl = false;
            }
            if(!e.Shift)
            {
                this.shift = false;
            }
        }

        private void picBoxPrincp_MouseDown(object sender, MouseEventArgs e)
        {
            clicado = true;
            yaux = e.Y;
            xaux = e.X;
        }

        private void picBoxPrincp_MouseUp(object sender, MouseEventArgs e)
        {
            clicado = false;
        }

        private void picBoxPrincp_MouseMove(object sender, MouseEventArgs e)
        {
            if(clicado)
            {
                imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);

                if (e.Button == MouseButtons.Left)
                    control.rotacaoXY(yaux - e.Y, e.X - xaux);
                else if (e.Button == MouseButtons.Right)
                    control.translacaoXY(e.X - xaux, e.Y - yaux);

                control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "", 100);
                picBoxPrincp.Image = imgPrincipal;
            }
            
            yaux = e.Y;
            xaux = e.X;
        }
    }
}
