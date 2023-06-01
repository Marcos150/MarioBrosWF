//Clase que gestiona el formulario de partida

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SharpDX.XInput;
using NAudio.Wave;

namespace MarioBrosWF
{
    public partial class Partida : Form
    {
        private const string SONIDO_FONDO = "recursos/music.wav";
        private const string SONIDO_FONDO_SECRETO = "recursos/musicSecret.wav";
        private const string SONIDO_GAME_OVER = "recursos/musicGameOver.wav";
        private const string SONIDO_SUPERADO = "recursos/musicSuperado.wav";
        private const string EFECTO_SALTO = "recursos/sonidoSalto.wav";
        private const string EFECTO_NIVEL = "recursos/sonidoNivel.wav";
        private MenuPrincipal principal;
        private Personaje jugador;
        private List<Enemigo> enemigos;
        private Plataforma[] plataformas;
        private BloquePOW pow;
        private Controller mando;
        private int nivelActual;
        private bool gameOver;
        private WaveStream streamFondo;
        private WaveStream streamEfectoSalto;
        private WaveStream streamEfectoNivel;
        private WaveOut playerFondo;
        private WaveOut playerEfecto;

        public Partida()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
            AjustarTamanyoTuberias();
            Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] = 
                tuberiaIzquierda.Size.Width;
            nivelActual = 0;
            jugador = new Personaje();
            ConfigurarMando();
            IniciarNivel();
            streamFondo = new WaveFileReader(SONIDO_FONDO);
            playerFondo = new WaveOut(); 
            streamFondo.Position = streamFondo.Length;
            ComprobarMusica();
            streamEfectoSalto = new WaveFileReader(EFECTO_SALTO);
            streamEfectoNivel = new WaveFileReader(EFECTO_NIVEL);
            playerEfecto = new WaveOut();
            playerEfecto.Init(streamEfectoSalto);
        }

        private void AjustarTamanyoTuberias()
        {
            tuberiaIzquierda.Image = Image.FromFile(Configuracion.CARPETA + 
                "tuberiaIzquierda.png");
            tuberiaDerecha.Image = Image.FromFile(Configuracion.CARPETA + 
                "tuberiaDerecha.png");
            if (Configuracion.ALTO_PANTALLA == 375)
            {
                tuberiaDerecha.Location = new Point(Configuracion.ANCHO_PANTALLA
                    - 32, 23);
                tuberiaIzquierda.Location = new Point(0, 23);
                tuberiaDerecha.Size = new Size(32, 46);
                tuberiaIzquierda.Size = new Size(32, 46);
            }
            else 
            {
                tuberiaDerecha.Location = new Point(Configuracion.ANCHO_PANTALLA 
                    - 64, 46);
                tuberiaIzquierda.Location = new Point(0, 46);
                tuberiaDerecha.Size = new Size(64, 92);
                tuberiaIzquierda.Size = new Size(64, 92);
            }
        }

        private void IniciarNivel()
        {
            lblLevel.Text = "Nivel " + (nivelActual+1);
            jugador.MoverA(Configuracion.COORDENADAS_INICIALES_PERSONAJE[0], 
                Configuracion.COORDENADAS_INICIALES_PERSONAJE[1]);
            jugador.SetGravedad(0);
            jugador.SetGravedad(0);
            enemigos = new List<Enemigo>();
            CrearEnemigos();
            //Si aún quedan niveles, se sigue con el proceso
            if (!gameOver)
            {
                pow = new BloquePOW();
                gameOver = false;
                //5 es el máximo de plataformas por fila
                plataformas = new Plataforma[Configuracion.FILAS_MAPA * 5];
                plataformas[0] = pow;
                for (int i = 1; i < plataformas.Length; i++)
                {
                    plataformas[i] = new Plataforma();
                }
                CrearPlataformas();
                timerPartida.Start();
                timerEnemigos.Start();
            }
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
                if (estado.Gamepad.Buttons == Configuracion.BOTON_SALTO && 
                    jugador.PuedeSaltar())
                {
                    jugador.Salta();
                    CambiarEfecto(streamEfectoSalto);
                }

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
            if (pow.GetUsosRestantes() > 0)
                pow.Dibujar(e.Graphics);
            foreach (Plataforma p in plataformas)
            {
                if (!(p is BloquePOW))
                    p.Dibujar(e.Graphics);
            }
            foreach (Enemigo enemigo in enemigos)
            {
                if (enemigo.EnPantalla())
                    enemigo.Dibujar(e.Graphics);
            }
        }

        private void GenerarEnemigo()
        {
            bool generado = false;
            foreach (Enemigo e in enemigos)
            {
                //Se generan los enemigos de la lista que no estan en pantalla
                //y aún tienen vidas
                if (!e.EnPantalla() && e.GetVidas() > 0 && !generado)
                {
                    e.Generar();
                    generado = true;
                    //Lado izquierdo
                    if (Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] == 
                        tuberiaIzquierda.Size.Width)
                    {
                        Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] = 
                            Configuracion.ANCHO_PANTALLA - 
                            (tuberiaDerecha.Width + e.Ancho);
                        e.SetDerecha(true);
                        e.SetIzquierda(false);
                    }
                    //Lado derecho
                    else
                    {
                        Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] = 
                            tuberiaIzquierda.Size.Width;
                        e.SetIzquierda(true);
                        e.SetDerecha(false);
                    }
                }
            }
        }

        private void GolpearPOW()
        {
            enemigos.Where(e => e.EnPantalla()).ToList().ForEach(e => 
            e.CambiarVulnerabilidad());
            pow.SetUsosRestantes(pow.GetUsosRestantes() - 1);
            pow.CambiarSprite();
            jugador.SetHaGolpeado(true);
        }

        private void Partida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                jugador.Izquierda = true;
            else if (e.KeyCode == Keys.Right)
                jugador.Derecha = true;

            if (e.KeyCode == Keys.Up && jugador.PuedeSaltar())
            {
                jugador.Salta();
                CambiarEfecto(streamEfectoSalto);
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
            playerFondo.Stop();
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
            ComprobarMusica();
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
                    if (!(p is BloquePOW) && jugador.ColisionaCon(p))
                    {
                        if (jugador.ComprobarTipoColision(p) == 1)
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
                if (jugador.ColisionaCon(e) && !e.EsVulnerable() && 
                    e.EnPantalla())
                    jugador.Reaparecer();
                else if (jugador.ColisionaCon(e) && e.EsVulnerable() && 
                    e.EnPantalla())
                {
                    e.Exterminado();
                    jugador.SetPuntos(jugador.GetPuntos() + 
                        Configuracion.PUNTOS_ENEMIGO);
                }
            }

            //Bloque POW
            if (jugador.ColisionaCon(pow) && pow.GetUsosRestantes() > 0)
            {
                if (jugador.ComprobarTipoColision(pow) == 1 && 
                    !jugador.HaGolpeado())
                    GolpearPOW();
            }
        }

        private void ComprobarEnemigosGolpeados(Plataforma p)
        {
            foreach (Enemigo e in enemigos)
            {
                if (jugador.X > e.X - 5 && jugador.X < e.X + 5 && 
                    e.GetPlataforma() == p)
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
            int contador = 1;
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
                        //-2 para que se vea un poquito la última línea
                        y += Configuracion.ALTO_PANTALLA /
                            Configuracion.FILAS_MAPA - 2;
                    }
                } while(linea != null);
            }
        }

        private void CrearEnemigos()
        {
            //Lee solo la línea correspodiente al nivel actual
            try
            {
                string linea = File.ReadLines("recursos/enemigos.txt").Skip(
                    nivelActual).Take(1).First();
                string[] lineaSplit = linea.Split(';');
                foreach (string s in lineaSplit)
                {
                    if (s == "T")
                        enemigos.Add(new Tortuga());
                    else if (s == "C")
                        enemigos.Add(new Cangrejo());
                }
            }
            //Si no quedan más líneas es que se han superado todos los niveles
            catch
            {
                CambiarMusica(SONIDO_SUPERADO);
                MessageBox.Show("Has completado el juego. Para más novedades" +
                    ", estáte atento al GitHub", "¡Enhorabuena!");
                GameOver();
            }
        }

        private void ComprobarFinPartida()
        {
            bool quedanEnemigos = false;
            
            foreach (Enemigo e in enemigos)
            {
                if (e.EnPantalla() || e.GetVidas() > 0)
                    quedanEnemigos = true;
            }
            //Si se derrotan todos los enemigos del nivel se pasa al siguiente
            if (!quedanEnemigos)
            {
                timerPartida.Stop();
                timerEnemigos.Stop();
                CambiarEfecto(streamEfectoNivel);
                nivelActual++;
                IniciarNivel();
            }
            //El personaje se queda sin vidas
            if (jugador.GetVidas() <= 0)
            {
                timerPartida.Stop();
                timerEnemigos.Stop();
                CambiarMusica(SONIDO_GAME_OVER);
                MessageBox.Show("Has perdido", "Vaya...");
                GameOver();
            }
        }

        private void CambiarMusica(string nuevaMusica)
        {
            streamFondo = new WaveFileReader(nuevaMusica);
            playerFondo.Stop();
            playerFondo = new WaveOut();
            playerFondo.Init(streamFondo);
            playerFondo.Play();
        }

        private void CambiarEfecto(WaveStream nuevoEfecto)
        {
            playerEfecto.Stop();
            playerEfecto.Init(nuevoEfecto);
            nuevoEfecto.Position = 0;
            playerEfecto.Play();
        }

        private void ComprobarMusica()
        {
            if (streamFondo.Position == streamFondo.Length)
            {
                //10% de probabilidades de que al iniciar o loopear la canción
                //Se reproduzca una secreta
                Random r = new Random();
                int x = r.Next(99);

                playerFondo.Stop();
                streamFondo.Position = 0; 
                if (x < 10)
                    streamFondo = new WaveFileReader(SONIDO_FONDO_SECRETO);
                else
                    streamFondo = new WaveFileReader(SONIDO_FONDO);

                playerFondo = new WaveOut();
                playerFondo.Init(streamFondo);
                playerFondo.Play();
            }
        }

        private void GameOver()
        {
            timerEnemigos.Stop();
            timerPartida.Stop();
            gameOver = true;
            MenuGameOver over = new MenuGameOver(jugador.GetPuntos());
            over.SetMenu(this.principal);
            over.Show();
            this.Close();
        }
    }
}
