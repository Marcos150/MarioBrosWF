//Clase que define al bloque POW

using System.Drawing;

namespace MarioBrosWF
{
    internal class BloquePOW : Plataforma
    {
        private int usosRestantes;
        private string[] sprites;

        public BloquePOW()
        {
            this.ancho = Configuracion.DIMENSIONES_POW[0];
            this.alto = Configuracion.DIMENSIONES_POW[1];
            sprites = new string[] { "powFull.png", "powMid.png", "powLow.png" };
            usosRestantes = Configuracion.USOS_BLOQUES_POW;
            imagen = Image.FromFile(Configuracion.CARPETA + sprites[0]);
            spriteX = 0;
            spriteY = 0;
            x = Configuracion.COORDENADAS_INICIALES_POW[0];
            y = Configuracion.COORDENADAS_INICIALES_POW[1];
        }

        public void CambiarSprite()
        {
            if (usosRestantes > 0)
            imagen = Image.FromFile(Configuracion.CARPETA + 
                sprites[3-usosRestantes]);
            else
                imagen = null;
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
