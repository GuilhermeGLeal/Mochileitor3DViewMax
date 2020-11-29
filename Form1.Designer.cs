namespace Mochileitor3DView
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btAbrirArquivo = new System.Windows.Forms.Button();
            this.openFDialog = new System.Windows.Forms.OpenFileDialog();
            this.btFecharArquivo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.picBoxPrincp = new System.Windows.Forms.PictureBox();
            this.ckFacesOcultas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPrincp)).BeginInit();
            this.SuspendLayout();
            // 
            // btAbrirArquivo
            // 
            this.btAbrirArquivo.BackColor = System.Drawing.Color.Black;
            this.btAbrirArquivo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btAbrirArquivo.Location = new System.Drawing.Point(15, 12);
            this.btAbrirArquivo.Name = "btAbrirArquivo";
            this.btAbrirArquivo.Size = new System.Drawing.Size(124, 31);
            this.btAbrirArquivo.TabIndex = 0;
            this.btAbrirArquivo.Text = "Abrir Arquivo";
            this.btAbrirArquivo.UseVisualStyleBackColor = false;
            this.btAbrirArquivo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btFecharArquivo
            // 
            this.btFecharArquivo.BackColor = System.Drawing.Color.Black;
            this.btFecharArquivo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btFecharArquivo.Location = new System.Drawing.Point(142, 12);
            this.btFecharArquivo.Name = "btFecharArquivo";
            this.btFecharArquivo.Size = new System.Drawing.Size(124, 31);
            this.btFecharArquivo.TabIndex = 2;
            this.btFecharArquivo.Text = "Fechar Arquivo";
            this.btFecharArquivo.UseVisualStyleBackColor = false;
            this.btFecharArquivo.Click += new System.EventHandler(this.btFecharArquivo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1234, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "r X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1326, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "r Y";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1234, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "r Z";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1326, 90);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "escala +";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1281, 134);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "escala -";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // picBoxPrincp
            // 
            this.picBoxPrincp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBoxPrincp.Location = new System.Drawing.Point(15, 52);
            this.picBoxPrincp.Name = "picBoxPrincp";
            this.picBoxPrincp.Size = new System.Drawing.Size(1200, 900);
            this.picBoxPrincp.TabIndex = 1;
            this.picBoxPrincp.TabStop = false;
            // 
            // ckFacesOcultas
            // 
            this.ckFacesOcultas.AutoSize = true;
            this.ckFacesOcultas.BackColor = System.Drawing.Color.Black;
            this.ckFacesOcultas.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ckFacesOcultas.Location = new System.Drawing.Point(1234, 189);
            this.ckFacesOcultas.Margin = new System.Windows.Forms.Padding(5);
            this.ckFacesOcultas.Name = "ckFacesOcultas";
            this.ckFacesOcultas.Size = new System.Drawing.Size(120, 21);
            this.ckFacesOcultas.TabIndex = 20;
            this.ckFacesOcultas.Text = "Faces Ocultas";
            this.ckFacesOcultas.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1442, 973);
            this.Controls.Add(this.ckFacesOcultas);
            this.Controls.Add(this.picBoxPrincp);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btFecharArquivo);
            this.Controls.Add(this.btAbrirArquivo);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mochileitor3DView";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPrincp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAbrirArquivo;
        private System.Windows.Forms.OpenFileDialog openFDialog;
        private System.Windows.Forms.Button btFecharArquivo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox picBoxPrincp;
        private System.Windows.Forms.CheckBox ckFacesOcultas;
    }
}

