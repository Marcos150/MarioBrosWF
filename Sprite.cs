using System.Drawing;

namespace MarioBrosWF
{
    internal abstract class Sprite
    {
        protected int alto;
        protected int ancho;
        protected int x;
        protected int y;
        protected int spriteX, spriteY;
        protected Image imagen;

        public Sprite(int ancho, int alto)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public void MoverA(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Dibujar(Graphics g)
        {
            Rectangle rect = new Rectangle(spriteX, spriteY, ancho, alto);
            g.DrawImage(imagen, x, y, rect, GraphicsUnit.Pixel);
        }

        public bool ColisionaCon(Sprite s)
        {
            return false;
        }
    }
}
