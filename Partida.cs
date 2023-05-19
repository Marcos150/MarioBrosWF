//Clase que gestiona el formulario de partida

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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
        private bool gameOver;

        public Partida()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
            Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] = Configuracion.ANCHO_PANTALLA / 10;
            jugador = new Personaje();
            enemigos = new List<Enemigo>();
            gameOver = false;
            CrearEnemigos();
            //5 es el máximo de plataformas por fila
            plataformas = new Plataforma[Configuracion.FILAS_MAPA * 5];
            for (int i = 0; i < plataformas.Length; i++)
            {
                plataformas[i] = new Plataforma();
            }
            CrearPlataformas();
            ConfigurarMando();
            timerPartida.Start();
            timerEnemigos.Start();
        }

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
                if (estado.Gamepad.Buttons == Configuracion.BOTON_SALTO)
                    jugador.Salta();

                if (estado.Gamepad.LeftThumbX < 0)
                {
                    jugador.Izquierda = true;
                    jugador.Derecha = false;
                }
                else if (estado.Gamepad.LeftThumbX > 0)
                {
                    jugador.Derecha = true;
                    jugador.Izquierda = false;
                }
                else
                {
                    jugador.Izquierda = false;
                    jugador.Derecha = false;
                }
            }
        }

        private void Partida_Paint(object sender, PaintEventArgs e)
        {
            jugador.Dibujar(e.Graphics);
            foreach (Plataforma p in plataformas)
            {
                p.Dibujar(e.Graphics);
            }
            foreach (Enemigo enemigo in enemigos)
            {
                if (enemigo.EstaVivo())
                    enemigo.Dibujar(e.Graphics);
            }
        }

        private void GenerarEnemigo()
        {
            bool generado = false;
            foreach (Enemigo e in enemigos)
            {
                if (!e.EstaVivo() && e.GetVidas() > 0 && !generado)
                {
                    e.Generar();
                    generado = true;
                    //Lado izquierdo
                    if (Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] == Configuracion.ANCHO_PANTALLA / 10)
                    {
                        Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] += (Configuracion.ANCHO_PANTALLA / 5) * 4;
                        e.SetDerecha(true);
                        e.SetVelocidad(Configuracion.VELOCIDAD_INICIAL_ENEMIGOS);
                    }
                    //Lado derecho
                    else
                    {
                        Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] = Configuracion.ANCHO_PANTALLA / 10;
                        e.SetIzquierda(true);
                        e.SetVelocidad(-Configuracion.VELOCIDAD_INICIAL_ENEMIGOS);
                    }
                }
            }
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
            lblPuntos.Text = "Puntos: " + jugador.GetPuntos();
            lblVidas.Text = "Vidas: " + jugador.GetVidas();
        }

        private void Partida_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!gameOver)
                principal.Show();
        }

        private void timerPartida_Tick(object sender, EventArgs e)
        {
            Invalidate();
            ComprobarMando();
            ComprobarColisionJugador();
            ComprobarColisionEnemigos();
            jugador.Mover();
            ComprobarTiempoEnemigos();
            MoverEnemigos();
            ActualizarHUD();
            ComprobarFinPartida();
        }

        private void timerEnemigos_Tick(object sender, EventArgs e)
        {
            GenerarEnemigo();
        }

        private void ComprobarColisionJugador()
        {
            //Plataformas
            if (jugador.GetPlataforma() == null)
            {
                jugador.SetPuedeCaerse(true);
                foreach (Plataforma p in plataformas)
                {
                    if (jugador.ColisionaCon(p))
                    {
                        if (jugador.ComprobarTipoColision(p, enemigos) == 1)
                            ComprobarEnemigosGolpeados(p);
                        else
                            jugador.SetHaGolpeado(false);
                    }
                }
            }
            //Comprueba si el jugador sigue en la plataforma
            else
            {
                if (!jugador.ColisionaCon(jugador.GetPlataforma()))
                    jugador.SetPlataforma(null);
            }

            //Enemigos
            foreach (Enemigo e in enemigos)
            {
                if (jugador.ColisionaCon(e) && !e.EsVulnerable() && e.EstaVivo())
                    jugador.Reaparecer();
                else if (jugador.ColisionaCon(e) && e.EsVulnerable() && e.EstaVivo())
                {
                    e.Exterminado();
                    jugador.SetPuntos(jugador.GetPuntos() + Configuracion.PUNTOS_ENEMIGO);
                }
            }
        }

        private void ComprobarEnemigosGolpeados(Plataforma p)
        {
            foreach (Enemigo e in enemigos)
            {
                if (jugador.X > e.X - 5 && jugador.X < e.X + 5 && e.GetPlataforma() == p)
                {
                    if (!jugador.HaGolpeado())
                        e.CambiarVulnerabilidad();
                    jugador.SetHaGolpeado(true);
                }
            }
        }

        private void ComprobarTiempoEnemigos()
        {
            foreach (Enemigo e in enemigos)
            {
                if (e.EsVulnerable())
                {
                    e.RestarTiempo();
                    if (e.GetTiempo() <= 0)
                        e.CambiarVulnerabilidad();
                }
            }
        }

        private void ComprobarColisionEnemigos()
        {
            foreach (Enemigo e in enemigos)
            {
                if (e.GetPlataforma() == null)
                {
                    foreach (Plataforma p in plataformas)
                    {
                        if (e.ColisionaCon(p))
                        {
                            e.SetPlataforma(p);
                            e.Y = p.Y - Configuracion.DIMENSIONES_ENEMIGO[1] +1;
                        }
                    }
                }
                else
                {
                    if (!e.ColisionaCon(e.GetPlataforma()))
                        e.SetPlataforma(null);
                }
            }
        }

        private void MoverEnemigos()
        {
            foreach (Enemigo e in enemigos)
            {
                e.Mover();
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
                            x += Configuracion.DIMENSIONES_PLATAFORMA[0];
                        }
                        y += Configuracion.ALTO_PANTALLA / Configuracion.FILAS_MAPA - 2; //-1 so that the last line is barely visible
                    }
                } while(linea != null);
            }
        }

        private void CrearEnemigos()
        {
            //Esto seguramente se cargará de otra parte para que hayan más niveles
            for (int i = 0; i < 3; i++)
            {
                enemigos.Add(new Tortuga());
                enemigos.Add(new Cangrejo());
            }
        }

        private void ComprobarFinPartida()
        {
            bool quedanEnemigos = false;
            
            foreach (Enemigo e in enemigos)
            {
                if (e.EstaVivo() || e.GetVidas() > 0)
                    quedanEnemigos = true;
            }
            //Se derrotan todos los enemigos
            if (!quedanEnemigos)
            {
                //Aquí se pasaría al siguiente nivel
                timerPartida.Stop();
                timerEnemigos.Stop();
                MessageBox.Show("Has completado el juego. Para más novedades" +
                    ", estáte atento al GitHub", "¡Enhorabuena!");
                GameOver();
            }
            //El personaje se queda sin vidas
            if (jugador.GetVidas() <= 0)
            {
                timerPartida.Stop();
                timerEnemigos.Stop();
                MessageBox.Show("Has perdido", "Vaya...");
                GameOver();
            }
        }

        private void GameOver()
        {
            gameOver = true;
            MenuGameOver over = new MenuGameOver(jugador.GetPuntos());
            over.SetMenu(this.principal);
            over.Show();
            this.Close();
        }
    }
}
