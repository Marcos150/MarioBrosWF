namespace MarioBrosWF
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
            this.buttonTamanyo = new System.Windows.Forms.Button();
            this.listRanking = new System.Windows.Forms.ListView();
            this.columnaNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaPuntos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonInicio
            // 
            this.buttonInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonInicio.Location = new System.Drawing.Point(545, 154);
            this.buttonInicio.Name = "buttonInicio";
            this.buttonInicio.Size = new System.Drawing.Size(200, 53);
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
            // buttonTamanyo
            // 
            this.buttonTamanyo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTamanyo.Location = new System.Drawing.Point(545, 75);
            this.buttonTamanyo.Name = "buttonTamanyo";
            this.buttonTamanyo.Size = new System.Drawing.Size(200, 50);
            this.buttonTamanyo.TabIndex = 5;
            this.buttonTamanyo.Text = "Cambiar tamaño";
            this.buttonTamanyo.UseVisualStyleBackColor = true;
            this.buttonTamanyo.Click += new System.EventHandler(this.buttonTamanyo_Click);
            // 
            // listRanking
            // 
            this.listRanking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listRanking.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnaNombre,
            this.columnaPuntos,
            this.columnaFecha});
            this.listRanking.Enabled = false;
            this.listRanking.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listRanking.HideSelection = false;
            this.listRanking.Location = new System.Drawing.Point(304, 213);
            this.listRanking.MultiSelect = false;
            this.listRanking.Name = "listRanking";
            this.listRanking.Size = new System.Drawing.Size(677, 460);
            this.listRanking.TabIndex = 6;
            this.listRanking.UseCompatibleStateImageBehavior = false;
            this.listRanking.View = System.Windows.Forms.View.Details;
            // 
            // columnaNombre
            // 
            this.columnaNombre.Text = "Nombre";
            this.columnaNombre.Width = 25;
            // 
            // columnaPuntos
            // 
            this.columnaPuntos.Text = "Puntos";
            this.columnaPuntos.Width = 25;
            // 
            // columnaFecha
            // 
            this.columnaFecha.Text = "Fecha";
            this.columnaFecha.Width = 25;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 679);
            this.Controls.Add(this.listRanking);
            this.Controls.Add(this.buttonTamanyo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonInicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mario Bros WF";
            this.Activated += new System.EventHandler(this.MenuPrincipal_Activated);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonTamanyo;
        private System.Windows.Forms.Button buttonInicio;
        private System.Windows.Forms.ListView listRanking;
        private System.Windows.Forms.ColumnHeader columnaNombre;
        private System.Windows.Forms.ColumnHeader columnaPuntos;
        private System.Windows.Forms.ColumnHeader columnaFecha;
    }
}

