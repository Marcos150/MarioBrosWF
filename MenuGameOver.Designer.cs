namespace MarioBrosWF
{
    partial class MenuGameOver
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
            this.lblPuntos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPuntos
            // 
            this.lblPuntos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Location = new System.Drawing.Point(324, 61);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(70, 25);
            this.lblPuntos.TabIndex = 0;
            this.lblPuntos.Text = "label1";
            // 
            // MenuGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPuntos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuGameOver";
            this.Text = "Game Over";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuGameOver_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPuntos;
    }
}