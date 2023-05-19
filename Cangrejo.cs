//Clase que define a los enemigos cangrejo

using System.Drawing;

namespace MarioBrosWF
{
    internal class Cangrejo : Enemigo
    {
        private bool estaEnfadado;

        public Cangrejo() : base()
        {
            this.FICHERO_SPRITE = "recursos/placeholder.png";
            this.estaEnfadado = false;
            vidas = 2;
            spriteX = 0;
            spriteY = 0;
            imagen = Image.FromFile(FICHERO_SPRITE);
            spriteVulnerable = FICHERO_SPRITE;
            coordenadasX[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasY[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasX[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
        }
    }
}
