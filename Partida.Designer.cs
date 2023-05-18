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
            this.timerPartida = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerPartida
            // 
            this.timerPartida.Interval = 30;
            this.timerPartida.Tick += new System.EventHandler(this.timerPartida_Tick);
            // 
            // Partida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Partida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mario Bros FX";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Partida_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Partida_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Partida_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Partida_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPartida;
    }
}