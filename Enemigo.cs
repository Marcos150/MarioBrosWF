//Clase abstracta que define a los enemigos

using System.Drawing;

namespace MarioBrosWF
{
    internal abstract class Enemigo : SpriteAnimado
    {
        protected int vidas;
        protected int velocidadActual;
        protected bool esVulnerable;
        protected int gravedadActual;
        protected bool estaVivo;
        //Plataforma sobre la que esta el enemigo
        protected Plataforma plataformaActual;
        //Tiempo que pasa desde que es golpeado hasta que se recupara
        protected int tiempoVulnerabilidad;
        protected string spriteVulnerable;

        protected Enemigo() : base(Configuracion.DIMENSIONES_ENEMIGO[0], 
            Configuracion.DIMENSIONES_ENEMIGO[1])
        {
            coordenadasX[DERECHA] = Configuracion.ANIMACION_ENEMIGO_DERECHA;
            coordenadasY[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasX[IZQUIERDA] = Configuracion.ANIMACION_ENEMIGO_IZQUIERDA;
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
            izquierda = false;
            derecha = false;
            estaVivo = false;
            ActualizarCoordenadasSprite();
            x = Configuracion.COORDENADAS_INICIALES_PERSONAJE[0];
            y = Configuracion.COORDENADAS_INICIALES_PERSONAJE[1];
            esVulnerable = false;
            gravedadActual = 0;
            tiempoVulnerabilidad = 0;
        }

        public void Mover()
        {
            if (estaVivo)
            {
                if (!esVulnerable)
                {
                    int nuevaX = x + velocidadActual;
                    MoverA(nuevaX, y);
                    if (derecha)
                        Animar(DERECHA);
                    else if (izquierda)
                        Animar(IZQUIERDA);
                }

                if (plataformaActual == null)
                    this.MoverA(this.X, this.Y + gravedadActual);
                if (gravedadActual < Configuracion.GRAVEDAD_MAXIMA && plataformaActual == null)
                    gravedadActual += Configuracion.GRAVEDAD;
                if (plataformaActual != null)
                    this.gravedadActual = 0;
            }
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
            else if (estaVivo)
            {
                esVulnerable = false;
                velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
                imagen = Image.FromFile(FICHERO_SPRITE);
                vidas = 1;
            }
        }

        public void Generar()
        {
            estaVivo = true;
            this.x = Configuracion.COORDENADAS_INICIALES_ENEMIGO[0];
            this.y = Configuracion.COORDENADAS_INICIALES_ENEMIGO[1];
        }

        public bool EsVulnerable()
        {
            return esVulnerable;
        }

        public bool EstaVivo()
        {
            return estaVivo;
        }

        public void Exterminado()
        {
            this.estaVivo = false;
            this.vidas = 0;
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

        public int GetVidas()
        {
            return vidas;
        }

        public void SetVelocidad(int velocidad)
        {
            this.velocidadActual = velocidad;
        }

        public void SetDerecha(bool derecha)
        {
            this.derecha = derecha;
        }

        public void SetIzquierda(bool izquierda)
        {
            this.izquierda = izquierda;
        }
    }
}
