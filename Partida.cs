using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using SharpDX.XInput;

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
        private Controller mando;

        public void SetMenu(MenuPrincipal principal)
        {
            this.principal = principal;
        }

        public MenuPrincipal GetMenu()
        { 
            return this.principal; 
        }

        private void ConfigurarMando()
        {
            mando = new Controller(UserIndex.One);
            if (mando.IsConnected)
                MessageBox.Show("Mando conectado");
        }

        private void ComprobarMando()
        {
            if (mando.IsConnected)
            {
                State estado = mando.GetState();
                if (estado.Gamepad.Buttons == GamepadButtonFlags.A)
                    jugador.Salta();

                if (estado.Gamepad.LeftThumbX < 0)
                    jugador.Izquierda = true;
                else if (estado.Gamepad.LeftThumbX > 0)
                    jugador.Derecha = true;
                else
                {
                    jugador.Izquierda = false;
                    jugador.Derecha = false;
                }
            }
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
            CrearPlataformas();
            ConfigurarMando();
            timerPartida.Start(); 
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
            ComprobarMando();
            ComprobarColisionJugador();
            jugador.Mover();
        }

        private void ComprobarColisionJugador()
        {
            jugador.SetPuedeMoverse(true);
            foreach (Plataforma p in plataformas)
            {
                if (jugador.PuedeMoverse())
                {
                    if (jugador.ColisionaCon(p))
                    {
                        jugador.ComprobarTipoColision(p);
                        if (!(jugador.EnPlataforma() && jugador.GetGravedad() < 0)
                            && !(!jugador.EnPlataforma() && jugador.GetGravedad() > 0))
                            jugador.SetPuedeMoverse(false);
                    }
                    else
                        jugador.SetEnPlataforma(false);
                }
                
            }
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
