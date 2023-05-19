//Clase del formulario de la pantalla de game over

using System.Windows.Forms;

namespace MarioBrosWF
{
    public partial class MenuGameOver : Form
    {
        private MenuPrincipal principal;
        private int puntos;

        public MenuGameOver(int puntos)
        {
            InitializeComponent();
            this.Width = Configuracion.ANCHO_PANTALLA;
            this.Height = Configuracion.ALTO_PANTALLA;
            this.puntos = puntos;
            this.lblPuntos.Text = "Puntuación final: " + puntos + " puntos";
        }

        public void SetMenu(MenuPrincipal principal)
        {
            this.principal = principal;
        }

        public MenuPrincipal GetMenu()
        {
            return this.principal;
        }

        private RegistroRanking NuevoRegistro()
        {
            return new RegistroRanking();
        }

        private void MenuGameOver_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.Show();
        }
    }
}
