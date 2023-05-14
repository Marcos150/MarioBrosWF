//Clase abstracta que define a los enemigos

using System.Drawing;

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
        //Tiempo que pasa desde que es golpeado hasta que se recupara
        protected int tiempoVulnerabilidad;
        protected string spriteVulnerable;

        protected Enemigo() : base(15, 15)
        {
            coordenadasX[DERECHA] = new int[] { 80, 96, 112, 128, 144 };
            coordenadasY[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasX[IZQUIERDA] = new int[] { 0, 16, 32, 48, 64 };
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
            izquierda = false;
            derecha = false;
            ActualizarCoordenadasSprite();
            x = Configuracion.COORDENADAS_INICIALES[0];
            y = Configuracion.COORDENADAS_INICIALES[1];
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
                if (velocidadActual > 0) 
                    Animar(DERECHA);
                else if (velocidadActual < 0)
                    Animar(IZQUIERDA);
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
                    spriteX = 0;
                    spriteY = 0;
                    imagen = Image.FromFile(spriteVulnerable);
                }
            }
            else
            {
                esVulnerable = false;
                velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
                imagen = Image.FromFile(FICHERO_SPRITE);
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
