//Clase del formulario de la pantalla de game over

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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

        private void buttonRegistrar_Click(object sender, System.EventArgs e)
        {
            //Lectura
            string jsonString2 = File.ReadAllText(Configuracion.RANKING);
            List<RegistroRanking> lista = JsonSerializer.Deserialize<List<RegistroRanking>>(jsonString2);

            //CAMBIAR PARA QUE COMPRUEBE QUE HAY ALGUNA LETRA
            if (textBoxNombre.Text != "")
            {
                lista.Add(new RegistroRanking(puntos, textBoxNombre.Text));
                MessageBox.Show("Registro añadido correctamente");
            }
            else
                MessageBox.Show("Tienes que escribir un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //Escritura
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(Configuracion.RANKING, jsonString);

            buttonRegistrar.Hide();
        }

        private void buttonMenu_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
