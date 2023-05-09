namespace MarioBrosWF
{
    internal abstract class Enemigo : SpriteAnimado
    {
        protected int vidas;
        protected int velocidadActual;
        protected int puntos;
        protected bool esVulnerable;

        protected Enemigo() : base(16, 16)
        {
        }

        public void mover()
        {

        }

        public void Recuperarse()
        {

        }
    }
}
