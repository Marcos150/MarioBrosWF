//Clase que define las plataformas

using System.Drawing;


namespace MarioBrosWF
{
    internal class Plataforma : Sprite
    {
        public Plataforma() : base(Configuracion.DIMENSIONES_PLATAFORMA[0],
            Configuracion.DIMENSIONES_PLATAFORMA[1])
        {
            imagen = Image.FromFile(Configuracion.CARPETA + 
                "platforms_sprite.png");
            spriteX = 0; 
            spriteY = 0;
        }
    }
}
