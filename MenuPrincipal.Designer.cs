﻿namespace MarioBrosWF
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInicio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRanking = new System.Windows.Forms.Button();
            this.listRanking = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonInicio
            // 
            this.buttonInicio.Location = new System.Drawing.Point(556, 444);
            this.buttonInicio.Name = "buttonInicio";
            this.buttonInicio.Size = new System.Drawing.Size(127, 53);
            this.buttonInicio.TabIndex = 0;
            this.buttonInicio.Text = "Comenzar";
            this.buttonInicio.UseVisualStyleBackColor = true;
            this.buttonInicio.Click += new System.EventHandler(this.buttonInicio_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(666, 660);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonRanking
            // 
            this.buttonRanking.Location = new System.Drawing.Point(515, 568);
            this.buttonRanking.Name = "buttonRanking";
            this.buttonRanking.Size = new System.Drawing.Size(200, 50);
            this.buttonRanking.TabIndex = 2;
            this.buttonRanking.Text = "Mostrar ranking";
            this.buttonRanking.UseVisualStyleBackColor = true;
            this.buttonRanking.Click += new System.EventHandler(this.buttonRanking_Click);
            // 
            // listRanking
            // 
            this.listRanking.FormattingEnabled = true;
            this.listRanking.ItemHeight = 25;
            this.listRanking.Location = new System.Drawing.Point(341, 638);
            this.listRanking.Name = "listRanking";
            this.listRanking.Size = new System.Drawing.Size(565, 454);
            this.listRanking.TabIndex = 4;
            this.listRanking.Visible = false;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 1129);
            this.Controls.Add(this.listRanking);
            this.Controls.Add(this.buttonRanking);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonInicio);
            this.Name = "MenuPrincipal";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MenuPrincipal_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInicio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRanking;
        private System.Windows.Forms.ListBox listRanking;
    }
}

