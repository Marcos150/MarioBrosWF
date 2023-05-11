using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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
            DoubleBuffered = true;
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
            jugador = new Personaje();
            plataformas = new Plataforma[Configuracion.FILAS_MAPA*5];
            for (int i = 0; i < plataformas.Length; i++)
            {
                plataformas[i] = new Plataforma();
            }
            timerPartida.Start();
            CrearPlataformas();
        }

        private void Partida_Paint(object sender, PaintEventArgs e)
        {
            jugador.Dibujar(e.Graphics);
            foreach (Plataforma p in plataformas)
            {
                p.Dibujar(e.Graphics);
            }
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

            if (e.KeyCode == Keys.Up)
            {
                jugador.Salta();
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

        private void CrearPlataformas()
        {
            string linea;
            int contador = 0;
            int y = 0;
            using (StreamReader fichero = new StreamReader("recursos/map.txt"))
            {
                do
                {
                    linea = fichero.ReadLine();
                    if (linea != null)
                    {
                        int x = 0;
                        foreach (char c in linea)
                        {
                            if (c == 'x')
                            {
                                plataformas[contador].MoverA(x, y);
                                contador++;
                            }
                            x += 128;
                        }
                        y += Configuracion.ALTO_PANTALLA / Configuracion.FILAS_MAPA - 1; //-1 so that the last line is barely visible
                    }
                } while(linea != null);
            }
        }
    }
}
