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

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

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

        public bool ColisionaCon(Sprite sp)
        {
            return (x < sp.x + sp.ancho && x + ancho > sp.x &&
                    y < sp.y + alto && y + alto > sp.y);
        }
    }
}
