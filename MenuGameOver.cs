using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
