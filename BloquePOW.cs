//Clase que define al bloque POW

using System.Drawing;

namespace MarioBrosWF
{
    internal class BloquePOW : Sprite
    {
        private int usosRestantes;

        public BloquePOW() : base(Configuracion.DIMENSIONES_POW[0],
            Configuracion.DIMENSIONES_POW[1])
        {
            usosRestantes = Configuracion.USOS_BLOQUES_POW;
            imagen = Image.FromFile("recursos/placeholder.png");
            spriteX = 0;
            spriteY = 0;
            x = Configuracion.COORDENADAS_INICIALES_POW[0];
            y = Configuracion.COORDENADAS_INICIALES_POW[1];
        }

        public void CambiarSprite()
        {
            //Aquí se cambia a un sprite diferente
            imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        public void SetUsosRestantes(int usos)
        {
            this.usosRestantes = usos;
        }

        public int GetUsosRestantes() 
        {
            return usosRestantes;
        }
    }
}
