using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarioBrosWF
{
    internal class Personaje : SpriteAnimado
    {
        private int vidas;
        private int puntos;
        private int gravedadActual;
        public const int IZQUIERDA = 0;
        public const int DERECHA = 1;
        public const int PASO = 4;
        private bool izquierda, derecha;
        private bool puedeSaltar;
        private bool puedeCaerse;
        //Plataforma sobre la que esta el jugador
        private Plataforma plataformaActual;
        //Determina si ya ha golpeado una plataforma por debajo
        private bool haGolpeado;

        public bool Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }

        public bool Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }

        public Personaje() : base(16, 32)
        {
            coordenadasX[DERECHA] = new int[] { 80, 96, 112, 128, 144 };
            coordenadasY[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasX[IZQUIERDA] = new int[] { 0, 16, 32, 48, 64 };
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
            izquierda = false;
            derecha = false;
            ActualizarCoordenadasSprite();
            x = Configuracion.COORDENADAS_INICIALES[0];
            y = Configuracion.COORDENADAS_INICIALES[1];
            gravedadActual = 0;
            puedeSaltar = true;
            puedeCaerse = true;
            haGolpeado = false;
            plataformaActual = null;
            vidas = Configuracion.VIDAS_INICIALES;
            puntos = 0;
            imagen = Image.FromFile("recursos/spritesAndar.png");
        }

        public void Mover(int movimiento)
        {
            int nuevaX = x;
            if (movimiento == IZQUIERDA)
                nuevaX -= 2;
            if (movimiento == DERECHA)
                nuevaX += 2;
            MoverA(nuevaX, y);
        }

        public void Mover()
        {
            // Comparador XOR
            if (izquierda ^ derecha)
            {
                int nuevaX = x;
                if (izquierda)
                {
                    nuevaX -= Math.Min(PASO, x);
                    Animar(IZQUIERDA);
                }
                else if (derecha)
                {
                    nuevaX += Math.Min(PASO,
                        Configuracion.ANCHO_PANTALLA - this.ancho - x);
                    Animar(DERECHA);
                }
                MoverA(nuevaX, y);
            }

            if (plataformaActual == null && (puedeCaerse || gravedadActual > 0))
                this.MoverA(this.X, this.Y + this.GetGravedad());
            if (this.GetGravedad() < Configuracion.GRAVEDAD_MAXIMA && plataformaActual == null)
                gravedadActual++;
            if (plataformaActual != null)
                this.gravedadActual = 0;
        }

        public int ComprobarTipoColision(Plataforma p, List<Enemigo> enemigos)
        {
            //Si choca por encima
            if (this.Y <= p.Y)
            {
                this.SetPuedeSaltar(true);
                this.plataformaActual = p;
                this.y = p.Y - 31;
                this.gravedadActual = 0;
                return 0;
            }
            //Sí choca por debajo
            else
            {
                puedeCaerse = false;
                return 1;
            }
        }

        public void Salta()
        {
            if (puedeSaltar)
            {
                y--; //Evita que que se pueda saltar 2 veces
                plataformaActual = null;
                this.gravedadActual = Configuracion.FUERZA_SALTO;
                this.puedeSaltar = false;
            }
        }

        public void Reaparecer()
        {
            x = Configuracion.COORDENADAS_INICIALES[0];
            y = Configuracion.COORDENADAS_INICIALES[1];
            MoverA(x, y);
        }

        public void SetGravedad(int g)
        {
            this.gravedadActual = g;
        }

        public int GetGravedad()
        {
            return gravedadActual;
        }

        public bool PuedeSaltar()
        {
            return puedeSaltar;
        }

        public void SetPuedeSaltar(bool puedeSaltar)
        {
            this.puedeSaltar = puedeSaltar;
        }

        public bool HaGolpeado()
        {
            return haGolpeado;
        }

        public void SetHaGolpeado(bool ha)
        {
            this.haGolpeado = ha;
        }

        public void SetPuedeCaerse(bool puedeMoverse)
        {
            this.puedeCaerse = puedeMoverse;
        }

        public void SetPlataforma(Plataforma p)
        {
            this.plataformaActual = p;
        }

        public Plataforma GetPlataforma()
        { 
            return plataformaActual; 
        }
    }
}
