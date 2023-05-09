namespace MarioBrosWF
{
    internal abstract class SpriteAnimado : Sprite
    {
        public int ALTO;
        public int ANCHO;
        protected string FICHERO_SPRITE;
        protected int movimientosTotales;
        protected int movimientoActual;
        protected int spriteActual;
        protected int contadorCambioSprite;
        protected int[][] coordenadasX;
        protected int[][] coordenadasY;
        protected bool izquierda;
        protected bool derecha;

        protected SpriteAnimado(int ancho, int alto) : base(ancho, alto)
        {
        }

        public void Animar(int movimiento)
        {

        }

        protected void ActualizarCoordenadasSprite()
        {

        }
    }
}
