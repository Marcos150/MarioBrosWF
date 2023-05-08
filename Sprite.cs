using System.Drawing;

namespace MarioBrosWF
{
    internal abstract class Sprite
    {
        protected int alto;
        protected int ancho;
        protected int x;
        protected int y;
        protected Image imagen;

        public void MoverA(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Dibujar()
        {

        }

        public bool ColisionaCon(Sprite s)
        {
            return false;
        }
    }
}
