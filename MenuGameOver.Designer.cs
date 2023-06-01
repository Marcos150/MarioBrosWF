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
            System.Windows.Forms.Label lblNombre;
            this.lblPuntos = new System.Windows.Forms.Label();
            this.buttonRegistrar = new System.Windows.Forms.Button();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.buttonMenu = new System.Windows.Forms.Button();
            lblNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblNombre.AutoSize = true;
            lblNombre.Location = new System.Drawing.Point(481, 255);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(297, 25);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre (Máx. 25 caracteres):";
            // 
            // lblPuntos
            // 
            this.lblPuntos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPuntos.AutoSize = true;
            this.lblPuntos.Location = new System.Drawing.Point(503, 185);
            this.lblPuntos.Name = "lblPuntos";
            this.lblPuntos.Size = new System.Drawing.Size(70, 25);
            this.lblPuntos.TabIndex = 0;
            this.lblPuntos.Text = "label1";
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRegistrar.Location = new System.Drawing.Point(508, 402);
            this.buttonRegistrar.Name = "buttonRegistrar";
            this.buttonRegistrar.Size = new System.Drawing.Size(179, 52);
            this.buttonRegistrar.TabIndex = 1;
            this.buttonRegistrar.Text = "Añadir Registro";
            this.buttonRegistrar.UseVisualStyleBackColor = true;
            this.buttonRegistrar.Click += new System.EventHandler(this.buttonRegistrar_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNombre.Location = new System.Drawing.Point(393, 283);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(429, 31);
            this.textBoxNombre.TabIndex = 2;
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMenu.Location = new System.Drawing.Point(508, 487);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(179, 47);
            this.buttonMenu.TabIndex = 4;
            this.buttonMenu.Text = "Menú principal";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // MenuGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 679);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(lblNombre);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.buttonRegistrar);
            this.Controls.Add(this.lblPuntos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuGameOver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Over";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuGameOver_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPuntos;
        private System.Windows.Forms.Button buttonRegistrar;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Button buttonMenu;
    }
}