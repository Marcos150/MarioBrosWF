using System;
using System.Windows.Forms;

namespace MarioBrosWF
{
    public partial class MenuPrincipal : Form
    {
        private bool secreto;

        public MenuPrincipal()
        {
            InitializeComponent();
            this.Width = Configuracion.ANCHO_PANTALLA;
            this.Height = Configuracion.ALTO_PANTALLA;
        }

        private void Iniciar()
        {

        }

        private void VerRanking()
        {

        }

        private void Salir()
        {

        }

        private void MenuPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            Partida p = new Partida();
            p.SetMenu(this);
            p.Show();
            this.Hide();
        }
    }
}
