//Clase que define las plataformas

using System.Drawing;


namespace MarioBrosWF
{
    internal class Plataforma : Sprite
    {
        public Plataforma() : base(128, 16)
        {
            imagen = Image.FromFile("recursos/platforms_sprite.png");
            spriteX = 0; 
            spriteY = 0;
        }
    }
}
