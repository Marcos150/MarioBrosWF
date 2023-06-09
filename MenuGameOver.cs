﻿//Clase del formulario de la pantalla de game over

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
        private int nivelAlcanzado;

        public MenuGameOver(int puntos, int nivelAlcanzado)
        {
            InitializeComponent();
            this.Width = Configuracion.ANCHO_PANTALLA;
            this.Height = Configuracion.ALTO_PANTALLA;
            this.puntos = puntos;
            this.nivelAlcanzado = nivelAlcanzado;
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

        private void MenuGameOver_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.Show();
        }

        private void buttonRegistrar_Click(object sender, System.EventArgs e)
        {
            //Lectura
            string jsonString2 = File.ReadAllText(Configuracion.RANKING);
            List<RegistroRanking> lista = JsonSerializer.Deserialize<
                List<RegistroRanking>>(jsonString2);

            if (textBoxNombre.Text != "" && ! (textBoxNombre.Text.Length > 25))
            {
                lista.Add(new RegistroRanking(puntos, nivelAlcanzado,textBoxNombre.Text));
                MessageBox.Show("Registro añadido correctamente");
                buttonRegistrar.Hide();
            }
            else
                MessageBox.Show("Nombre vacío o demasiado largo", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //Escritura
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(Configuracion.RANKING, jsonString);
        }

        private void buttonMenu_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
