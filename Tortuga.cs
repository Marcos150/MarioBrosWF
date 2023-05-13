using System.Drawing;

namespace MarioBrosWF
{
    internal class Tortuga : Enemigo
    {
        public Tortuga() : base()
        {
            imagen = Image.FromFile("recursos/sprites.png");
            spriteX = 1;
            spriteY = 137;
            x = 10;
            y = 20;
            vidas = 1;
            puntos = 0;
        }
    }
}
