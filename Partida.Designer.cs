namespace MarioBrosWF
{
    partial class Partida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Partida));
            this.timerPartida = new System.Windows.Forms.Timer(this.components);
            this.timerEnemigos = new System.Windows.Forms.Timer(this.components);
            this.lblPuntos = new System.Windows.Forms.Label();
            this.lblVidas = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.tuberiaIzquierda = new System.Windows.Forms.PictureBox();
            this.tuberiaDerecha = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tuberiaIzquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuberiaDerecha)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPartida
            // 
            this.timerPartida.Interval = 30;
            this.timerPartida.Tick += new System.EventHandler(this.timerPartida_Tick);
            // 
            // timerEnemigos
            // 
            this.timerEnemigos.Interval = 4000;
            this.timerEnemigos.Tick += new System.EventHandler(this.timerEnemigos_Tick);
            // 
            // lblPuntos
            // 
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Location = new System.Drawing.Point(12, 9);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(70, 25);
            this.lblPuntos.TabIndex = 0;
            this.lblPuntos.Text = "label1";
            // 
            // lblVidas
            // 
            this.lblVidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVidas.AutoSize = true;
            this.lblVidas.Location = new System.Drawing.Point(1150, 9);
            this.lblVidas.Name = "lblVidas";
            this.lblVidas.Size = new System.Drawing.Size(70, 25);
            this.lblVidas.TabIndex = 1;
            this.lblVidas.Text = "label1";
            // 
            // lblLevel
            // 
            this.lblLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(560, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(70, 25);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "label1";
            // 
            // tuberiaIzquierda
            // 
            this.tuberiaIzquierda.BackColor = System.Drawing.Color.Transparent;
            this.tuberiaIzquierda.Image = ((System.Drawing.Image)(resources.GetObject("tuberiaIzquierda.Image")));
            this.tuberiaIzquierda.Location = new System.Drawing.Point(0, 48);
            this.tuberiaIzquierda.Name = "tuberiaIzquierda";
            this.tuberiaIzquierda.Size = new System.Drawing.Size(64, 92);
            this.tuberiaIzquierda.TabIndex = 3;
            this.tuberiaIzquierda.TabStop = false;
            // 
            // tuberiaDerecha
            // 
            this.tuberiaDerecha.BackColor = System.Drawing.Color.Transparent;
            this.tuberiaDerecha.Image = ((System.Drawing.Image)(resources.GetObject("tuberiaDerecha.Image")));
            this.tuberiaDerecha.Location = new System.Drawing.Point(1215, 48);
            this.tuberiaDerecha.Name = "tuberiaDerecha";
            this.tuberiaDerecha.Size = new System.Drawing.Size(64, 92);
            this.tuberiaDerecha.TabIndex = 4;
            this.tuberiaDerecha.TabStop = false;
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 679);
            this.Controls.Add(this.tuberiaDerecha);
            this.Controls.Add(this.tuberiaIzquierda);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblVidas);
            this.Controls.Add(this.lblPuntos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Partida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mario Bros WF";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Partida_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Partida_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Partida_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Partida_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tuberiaIzquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuberiaDerecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPartida;
        private System.Windows.Forms.Timer timerEnemigos;
        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Label lblVidas;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.PictureBox tuberiaIzquierda;
        private System.Windows.Forms.PictureBox tuberiaDerecha;
    }
}