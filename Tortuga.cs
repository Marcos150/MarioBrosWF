using System.Drawing;

namespace MarioBrosWF
{
    internal class Tortuga : Enemigo
    {
        public Tortuga() : base()
        {
            FICHERO_SPRITE = "recursos/spritesAndarTortuga.png";
            spriteVulnerable = "recursos/tortugaVulnerable.png";
            imagen = Image.FromFile(FICHERO_SPRITE);
            x = 10;
            y = 20;
            vidas = 1;
            puntos = 0;
        }
    }
}
