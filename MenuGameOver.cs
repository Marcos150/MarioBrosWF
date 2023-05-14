//Clase del formulario de la pantalla de game over

using System.Windows.Forms;

namespace MarioBrosWF
{
    public partial class MenuGameOver : Form
    {
        public MenuGameOver()
        {
            InitializeComponent();
            this.Width = Configuracion.ANCHO_PANTALLA;
            this.Height = Configuracion.ALTO_PANTALLA;
        }

        private void Iniciar()
        {

        }

        private RegistroRanking NuevoRegistro()
        {
            return new RegistroRanking();
        }
    }
}
