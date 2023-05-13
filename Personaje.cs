using System;
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

        public Personaje() : base(15, 31)
        {
            spriteX = 1; 
            spriteY = 1;
            x = Configuracion.COORDENADAS_INICIALES[0];
            y = Configuracion.COORDENADAS_INICIALES[1];
            gravedadActual = 0;
            puedeSaltar = true;
            puedeCaerse = true;
            plataformaActual = null;
            vidas = Configuracion.VIDAS_INICIALES;
            puntos = 0;
            imagen = Image.FromFile("recursos/sprites.png");
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

        public void ComprobarTipoColision(Plataforma p)
        {
            //Si choca por encima
            if (this.Y <= p.Y)
            {
                this.SetPuedeSaltar(true);
                this.plataformaActual = p;
                this.y = p.Y - 30;
                this.gravedadActual = 0;
            }
            //Sí choca por debajo
            else
                puedeCaerse = false;
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
