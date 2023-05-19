//Clase que define a los enemigos tortuga

using System.Drawing;

namespace MarioBrosWF
{
    internal class Tortuga : Enemigo
    {
        public Tortuga() : base()
        {
            FICHERO_SPRITE = Configuracion.CARPETA + "spritesAndarTortuga.png";
            spriteVulnerable = Configuracion.CARPETA + "tortugaVulnerable.png";
            imagen = Image.FromFile(FICHERO_SPRITE);
            x = 20;
            y = 40;
            vidas = 1;
        }
    }
}
