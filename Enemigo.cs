namespace MarioBrosWF
{
    internal abstract class Enemigo : SpriteAnimado
    {
        protected int vidas;
        protected int velocidadActual;
        protected int puntos;
        protected bool esVulnerable;
        protected int gravedadActual;
        //Plataforma sobre la que esta el enemigo
        protected Plataforma plataformaActual;
        protected int tiempoVulnerabilidad;

        protected Enemigo() : base(15, 15)
        {
            esVulnerable = false;
            velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
            gravedadActual = 0;
            tiempoVulnerabilidad = 0;
        }

        public void Mover()
        {
            if (!esVulnerable) 
            {
                int nuevaX = x + velocidadActual;
                MoverA(nuevaX, y);
            }

            if (plataformaActual == null)
                this.MoverA(this.X, this.Y + gravedadActual);
            if (gravedadActual < Configuracion.GRAVEDAD_MAXIMA && plataformaActual == null)
                gravedadActual++;
            if (plataformaActual != null)
                this.gravedadActual = 0;
        }

        public void Recuperarse()
        {

        }

        public void CambiarVulnerabilidad()
        {
            if (!esVulnerable)
            {
                vidas--;
                if (vidas == 0)
                {
                    esVulnerable = true;
                    velocidadActual = 0;
                    tiempoVulnerabilidad = Configuracion.TIEMPO_VULNERABILIDAD_ENEMIGOS / 30;
                }
            }
            else
            {
                esVulnerable = false;
                velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
                vidas = 1;
            }
        }

        public bool EsVulnerable()
        {
            return esVulnerable;
        }

        public void SetPlataforma(Plataforma p)
        {
            this.plataformaActual = p;
        }

        public Plataforma GetPlataforma()
        {
            return plataformaActual;
        }

        public int GetTiempo()
        {
            return tiempoVulnerabilidad;
        }

        public void RestarTiempo()
        {
            tiempoVulnerabilidad--;
        }
    }
}
