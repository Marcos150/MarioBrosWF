//Clase abstracta de los elementos animados

namespace MarioBrosWF
{
    internal abstract class SpriteAnimado : Sprite
    {
        public int ALTO;
        public int ANCHO;
        public const int IZQUIERDA = 0;
        public const int DERECHA = 1;
        protected string FICHERO_SPRITE;
        // Cuántos movimientos diferentes puede hacer el objeto
        protected int movimientosTotales;
        // Dirección o movimiento actual del objeto
        protected int movimientoActual;
        // Índice del sprite actual en la animación
        protected int spriteActual;
        // Contador de iteraciones para siguiente cambio de sprite
        protected int contadorCambioSprite;
        // Array de coordenadas X, Y de cada sprite para cada movimiento
        protected int[][] coordenadasX;
        protected int[][] coordenadasY;
        protected bool izquierda;
        protected bool derecha;

        protected SpriteAnimado(int ancho, int alto) : base(ancho, alto)
        {
            movimientosTotales = 2;
            coordenadasX = new int[movimientosTotales][];
            coordenadasY = new int[movimientosTotales][];
            movimientoActual = 0;
            spriteActual = 0;
            contadorCambioSprite = 0;
        }

        public void Animar(int movimiento)
        {
            if (movimiento != movimientoActual)
            {
                movimientoActual = movimiento;
                spriteActual = 0;
                contadorCambioSprite = 0;
            }
            else
            {
                contadorCambioSprite++;
                if (contadorCambioSprite >=
                    Configuracion.RATIO_ANIMACION)
                {
                    contadorCambioSprite = 0;
                    spriteActual = (byte)((spriteActual + 1) %
                            coordenadasX[movimientoActual].Length);
                }
            }
            ActualizarCoordenadasSprite();
        }

        protected void ActualizarCoordenadasSprite()
        {
            spriteX = coordenadasX[movimientoActual][spriteActual];
            spriteY = coordenadasY[movimientoActual][spriteActual];
        }
    }
}
