//Clase que define al personaje controlado por el jugador

using NAudio.Wave;
using System.Drawing;

namespace MarioBrosWF
{
    internal class Personaje : SpriteAnimado
    {
        private int vidas;
        private int puntos;
        private int gravedadActual;
        private int ultimaDireccion;
        private bool puedeSaltar;
        private bool puedeCaerse;
        private string spriteSaltoIzquierda;
        private string spriteSaltoDerecha;
        private string spriteQuietoIzquierda;
        private string spriteQuietoDerecha;
        //Plataforma sobre la que esta el jugador
        private Plataforma plataformaActual;
        //Determina si ya ha golpeado una plataforma por debajo o un bloque POW
        private bool haGolpeado;

        public bool Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }

        public bool Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }

        public Personaje() : base(Configuracion.DIMENSIONES_PERSONAJE[0], 
            Configuracion.DIMENSIONES_PERSONAJE[1])
        {
            FICHERO_SPRITE = Configuracion.CARPETA + "spritesAndar.png";
            spriteSaltoIzquierda = Configuracion.CARPETA + 
                "spriteSaltoIzquierda.png";
            spriteQuietoIzquierda = Configuracion.CARPETA + 
                "spriteQuietoIzquierda.png";
            spriteSaltoDerecha = Configuracion.CARPETA + 
                "spriteSaltoDerecha.png";
            spriteQuietoDerecha = Configuracion.CARPETA + 
                "spriteQuietoDerecha.png";
            coordenadasX[DERECHA] = Configuracion.ANIMACION_PERSONAJE_DERECHA;
            coordenadasY[DERECHA] = new int[] { 0, 0, 0, 0, 0 };
            coordenadasX[IZQUIERDA] = Configuracion.ANIMACION_PERSONAJE_IZQUIERDA;
            coordenadasY[IZQUIERDA] = new int[] { 0, 0, 0, 0, 0 };
            izquierda = false;
            derecha = false;
            ultimaDireccion = DERECHA;
            ActualizarCoordenadasSprite();
            gravedadActual = 0;
            puedeSaltar = true;
            puedeCaerse = true;
            haGolpeado = false;
            plataformaActual = null;
            vidas = Configuracion.VIDAS_INICIALES;
            puntos = 0;
            imagen = Image.FromFile(FICHERO_SPRITE);
        }

        public void Mover()
        {
            // Comparador XOR
            if (izquierda ^ derecha)
            {
                int nuevaX = x;
                if (izquierda)
                {
                    ultimaDireccion = IZQUIERDA;
                    nuevaX -= Configuracion.PASO;
                    //Si esta en una plataforma
                    if (plataformaActual != null)
                    {
                        imagen = Image.FromFile(FICHERO_SPRITE);
                        Animar(IZQUIERDA);
                    }
                    //Si esta en el aire
                    else
                    {
                        spriteX = 0;
                        spriteY = 0;
                        imagen = Image.FromFile(spriteSaltoIzquierda);
                    }
                }
                else if (derecha)
                {
                    ultimaDireccion = DERECHA;
                    nuevaX += Configuracion.PASO;
                    //Si esta en una plataforma
                    if (plataformaActual != null)
                    {
                        imagen = Image.FromFile(FICHERO_SPRITE);
                        Animar(DERECHA);
                    }
                    //Si esta en el aire
                    else
                    {
                        spriteX = 0;
                        spriteY = 0;
                        imagen = Image.FromFile(spriteSaltoDerecha);
                    }
                }
                MoverA(nuevaX, y);
            }
            else
            {
                spriteX = 0;
                spriteY = 0;
                if (ultimaDireccion == IZQUIERDA)
                    imagen = Image.FromFile(spriteQuietoIzquierda);
                else
                    imagen = Image.FromFile(spriteQuietoDerecha);
            }
            //Si sale de un lado de la pantalla, entra por el otro
            if (x <= - ancho)
                x = Configuracion.ANCHO_PANTALLA - ancho;
            if (x >= Configuracion.ANCHO_PANTALLA)
                x = 0;

            //Se mueve verticalmente si no esta en una plataforma
            //y no golpea a nada por arriba
            if (plataformaActual == null && (puedeCaerse || gravedadActual > 0))
                this.MoverA(this.X, this.Y + this.GetGravedad());
            //Aumenta gravedad si no se ha alcanzado la gravedad máxima
            //y no se esta en una plataforma
            if (this.GetGravedad() < Configuracion.GRAVEDAD_MAXIMA && 
                plataformaActual == null)
                gravedadActual += Configuracion.GRAVEDAD;
        }

        public int ComprobarTipoColision(Plataforma p)
        {
            //Si choca por encima
            if (this.Y <= p.Y)
            {
                this.SetPuedeSaltar(true);
                this.plataformaActual = p;
                this.y = p.Y - Configuracion.DIMENSIONES_PERSONAJE[1] + 1;
                this.gravedadActual = 0;
                if (derecha || izquierda)
                    imagen = Image.FromFile(FICHERO_SPRITE);
                return 0;
            }
            //Sí choca por debajo
            else
            {
                puedeCaerse = false;
                return 1;
            }
        }

        public void Salta()
        {
            y--; //Evita que que se pueda saltar 2 veces
            plataformaActual = null;
            this.gravedadActual = Configuracion.FUERZA_SALTO;
            this.puedeSaltar = false;
        }

        public void Reaparecer()
        {
            gravedadActual = 0;
            this.MoverA(Configuracion.COORDENADAS_INICIALES_PERSONAJE[0], 
                Configuracion.COORDENADAS_INICIALES_PERSONAJE[1]);
            vidas--;
        }

        public void SetGravedad(int g)
        {
            this.gravedadActual = g;
        }

        public int GetGravedad()
        {
            return gravedadActual;
        }

        public bool PuedeSaltar()
        {
            return puedeSaltar;
        }

        public void SetPuedeSaltar(bool puedeSaltar)
        {
            this.puedeSaltar = puedeSaltar;
        }

        public bool HaGolpeado()
        {
            return haGolpeado;
        }

        public void SetHaGolpeado(bool ha)
        {
            this.haGolpeado = ha;
        }

        public void SetPuedeCaerse(bool puedeMoverse)
        {
            this.puedeCaerse = puedeMoverse;
        }

        public void SetPlataforma(Plataforma p)
        {
            this.plataformaActual = p;
        }

        public Plataforma GetPlataforma()
        { 
            return plataformaActual; 
        }

        public int GetPuntos()
        {
            return puntos;
        }

        public void SetPuntos(int puntos)
        {
            this.puntos = puntos;
        }

        public int GetVidas()
        {
            return vidas;
        }
    }
}
