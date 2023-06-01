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
        //Define si un enemigo sale en la pantalla
        protected bool enPantalla;
        //Plataforma sobre la que esta el enemigo
        protected Plataforma plataformaActual;
        //Tiempo que pasa desde que es golpeado hasta que se recupara
        protected int tiempoVulnerabilidad;
        protected string spriteVulnerable;

        public Enemigo() : base(Configuracion.DIMENSIONES_ENEMIGO[0], 
            Configuracion.DIMENSIONES_ENEMIGO[1])
        {
            coordenadasX[DERECHA] = Configuracion.ANIMACION_TORTUGA_DERECHA;
            coordenadasY[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasX[IZQUIERDA] = Configuracion.ANIMACION_TORTUGA_IZQUIERDA;
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
            izquierda = false;
            derecha = false;
            enPantalla = false;
            ActualizarCoordenadasSprite();
            esVulnerable = false;
            velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
            gravedadActual = 0;
            tiempoVulnerabilidad = 0;
        }

        public void Mover()
        {
            if (enPantalla)
            {
                if (!esVulnerable)
                {
                    int nuevaX = 0;

                    if (derecha)
                    {
                        Animar(DERECHA);
                        nuevaX = x + velocidadActual;
                    }
                    else if (izquierda)
                    {
                        Animar(IZQUIERDA);
                        nuevaX = x - velocidadActual;
                    }
                    MoverA(nuevaX, y);
                }

                if (plataformaActual == null)
                    this.MoverA(this.X, this.Y + gravedadActual);
                if (gravedadActual < Configuracion.GRAVEDAD_MAXIMA && plataformaActual == null)
                    gravedadActual += Configuracion.GRAVEDAD;
                if (plataformaActual != null)
                    this.gravedadActual = 0;
            }
            //Si el enemigo se sale de la pantalla se pone a falso enPantalla
            //para que pueda ser generado otra vez
            if (x <= -ancho || x >= Configuracion.ANCHO_PANTALLA)
                enPantalla = false;
        }

        public void CambiarVulnerabilidad()
        {
            if (!esVulnerable)
            {
                vidas--;
                if (vidas == 1 && this is Cangrejo)
                {
                    imagen = Image.FromFile(Configuracion.CARPETA + "cangrejoEnfadado.png");
                    this.velocidadActual *= 2;
                }
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
            else if (enPantalla)
            {
                esVulnerable = false;
                if (derecha)
                    velocidadActual = Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
                else if (izquierda)
                    velocidadActual = -Configuracion.VELOCIDAD_INICIAL_ENEMIGOS;
                imagen = Image.FromFile(FICHERO_SPRITE);
                if (this is Tortuga) 
                    vidas = 1;
                else if (this is Cangrejo) 
                    vidas = 2;
            }
        }

        public void Generar()
        {
            enPantalla = true;
            x = Configuracion.COORDENADAS_INICIALES_ENEMIGO[0];
            y = Configuracion.COORDENADAS_INICIALES_ENEMIGO[1];
        }

        public bool EsVulnerable()
        {
            return esVulnerable;
        }

        public bool EnPantalla()
        {
            return enPantalla;
        }

        public void Exterminado()
        {
            enPantalla = false;
            vidas = 0;
        }

        public void SetPlataforma(Plataforma p)
        {
            plataformaActual = p;
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
            velocidadActual = velocidad;
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
