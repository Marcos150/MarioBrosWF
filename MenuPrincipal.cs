//Clase del formulario del menú principal

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace MarioBrosWF
{
    public partial class MenuPrincipal : Form
    {
        private bool secreto;
        private const string RANKING = "recursos/ranking.json";

        public MenuPrincipal()
        {
            InitializeComponent();
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
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

        private void buttonRanking_Click(object sender, EventArgs e)
        {
            listRanking.Items.Clear();
            //Lectura
            string jsonString2 = File.ReadAllText(RANKING);
            List<RegistroRanking> lista = JsonSerializer.Deserialize<List<RegistroRanking>>(jsonString2);
            
            foreach (RegistroRanking r in lista)
            {
                listRanking.Items.Add(r.ToString());
            }
            listRanking.Show();

            //Escritura
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(RANKING, jsonString);
        }
    }
}
