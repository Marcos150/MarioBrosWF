using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MarioBrosWF
{
    public partial class Partida : Form
    {
        private MenuPrincipal principal;
        private Personaje jugador;
        private List<Enemigo> enemigos;
        private bool secreto;
        private Plataforma[] plataformas;
        private BloquePOW pow;

        public void SetMenu(MenuPrincipal principal)
        {
            this.principal = principal;
        }

        public MenuPrincipal GetMenu()
        { 
            return this.principal; 
        }

        public Partida()
        {
            InitializeComponent();
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
            jugador = new Personaje();
            timerPartida.Start();
            DoubleBuffered = true;
        }

        private void Partida_Paint(object sender, PaintEventArgs e)
        {
            jugador.Dibujar(e.Graphics);
        }

        private void GenerarEnemigo()
        {

        }

        private void GolpearPOW()
        {

        }

        private void Partida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                jugador.Izquierda = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                jugador.Derecha = true;
            }
        }

        private void Partida_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                jugador.Izquierda = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                jugador.Derecha = false;
            }
        }

        private void ActualizarHUD()
        {

        }

        private void Partida_FormClosed(object sender, FormClosedEventArgs e)
        {
            principal.Show();
        }

        private void timerPartida_Tick(object sender, EventArgs e)
        {
            Invalidate();
            jugador.Mover();
        }
    }
}
