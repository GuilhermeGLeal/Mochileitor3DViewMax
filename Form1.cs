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

        public Form1()
        {
            InitializeComponent();
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFDialog.Filter = "obj files (*.obj)|*.obj";
            openFDialog.FilterIndex = 0;

            if(openFDialog.ShowDialog() == DialogResult.OK)
            {
                control = new ControladoraArquivo(openFDialog.FileName);
                control.leArquivo();
                control.desenha(imgPrincipal, "asas",100);
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
            control.rotacaoEmX();
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "as",100);
            picBoxPrincp.Image = imgPrincipal;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.rotacaoEmY();
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "as", 100);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.rotacaoEmZ();
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "as", 100);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.escalaPlus();
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "as", 100);
            picBoxPrincp.Image = imgPrincipal;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imgPrincipal = new Bitmap(picBoxPrincp.Width, picBoxPrincp.Height);
            control.escalaMinus();
            control.verificaDesenho(ckFacesOcultas.Checked, imgPrincipal, "as", 100);
            picBoxPrincp.Image = imgPrincipal;
        }
    }
}
