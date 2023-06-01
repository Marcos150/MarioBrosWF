//Clase que define a los enemigos cangrejo

using System.Drawing;

namespace MarioBrosWF
{
    internal class Cangrejo : Enemigo
    {
        public Cangrejo() : base()
        {
            this.FICHERO_SPRITE = Configuracion.CARPETA + "cangrejoAndar.png";
            vidas = 2;
            spriteX = 0;
            spriteY = 0;
            imagen = Image.FromFile(FICHERO_SPRITE);
            spriteVulnerable = Configuracion.CARPETA + "cangrejoVulnerable.png";
            coordenadasX[DERECHA] = Configuracion.ANIMACION_CANGREJO;
            coordenadasY[DERECHA] = new int[] { 0, 0, 0 };
            coordenadasX[IZQUIERDA] = Configuracion.ANIMACION_CANGREJO;
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0 };
        }
    }
}
