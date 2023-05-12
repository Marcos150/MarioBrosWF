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
        private bool enPlataforma;
        private bool puedeMoverse;

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
            x = 10;
            y = 32;
            gravedadActual = 0;
            puedeSaltar = true;
            puedeMoverse = true;
            enPlataforma = false;
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

            if (puedeMoverse)
                this.MoverA(this.X, this.Y + this.GetGravedad());
            if (this.GetGravedad() < Configuracion.GRAVEDAD_MAXIMA && !this.EnPlataforma())
                gravedadActual++;
            if (EnPlataforma())
                this.gravedadActual = 0;
        }

        public void ComprobarTipoColision(Plataforma p)
        {
            if (this.Y < p.Y)
            {
                this.SetEnPlataforma(true);
                this.SetPuedeSaltar(true);
                this.y = p.Y - 30;
            }
            else
                this.SetEnPlataforma(false);
        }

        public void Salta()
        {
            if (puedeSaltar)
            {
                this.gravedadActual = Configuracion.FUERZA_SALTO;
                this.puedeSaltar = false;
            }
        }

        public void Reaparecer()
        {

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

        public bool EnPlataforma()
        {
            return enPlataforma;
        }

        public void SetEnPlataforma(bool enPlataforma)
        {
            this.enPlataforma = enPlataforma;
        }

        public bool PuedeMoverse()
        {
            return puedeMoverse;
        }

        public void SetPuedeMoverse(bool puedeMoverse)
        {
            this.puedeMoverse = puedeMoverse;
        }
    }
}
