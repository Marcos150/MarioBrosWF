namespace MarioBrosWF
{
    internal abstract class Enemigo : SpriteAnimado
    {
        protected int vidas;
        protected int velocidadActual;
        protected int puntos;
        protected bool esVulnerable;
        protected int gravedadActual;
        protected bool puedeCaerse;

        protected Enemigo() : base(15, 15)
        {
            esVulnerable = false;
            velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
            gravedadActual = 0;
            puedeCaerse = true;
        }

        public void Mover()
        {
            if (!esVulnerable) 
            {
                int nuevaX = x + velocidadActual;
                MoverA(nuevaX, y);
            }

            if (puedeCaerse)
                this.MoverA(this.X, this.Y + gravedadActual);
            if (gravedadActual < Configuracion.GRAVEDAD_MAXIMA && puedeCaerse)
                gravedadActual++;
            if (!puedeCaerse)
                this.gravedadActual = 0;
        }

        public void Recuperarse()
        {

        }

        public void SetPuedeCaerse(bool p)
        {
            puedeCaerse = p;
        }

        public bool PuedeCaerse()
        {
            return puedeCaerse;
        }
    }
}
