using System;
using System.Drawing;

namespace MarioBrosWF
{
    internal class Personaje : SpriteAnimado
    {
        private int vidas;
        private int puntos;
        public const int IZQUIERDA = 0;
        public const int DERECHA = 1;
        public const int PASO = 4;
        private bool izquierda, derecha;

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
                else
                {
                    nuevaX += Math.Min(PASO,
                        Configuracion.ANCHO_PANTALLA - this.ancho - x);
                    Animar(DERECHA);
                }
                MoverA(nuevaX, y);
            }
        }

        public void Reaparecer()
        {

        }
    }
}
