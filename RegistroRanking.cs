//Struct con los elementos de un registro del ranking

using System;

namespace MarioBrosWF
{
    internal struct RegistroRanking
    {
        int puntuacion;
        int nivel;
        string nombre;
        DateTime fecha;

        public int Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }


        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Fecha
        {
            get { return fecha.ToString(); }
            set { fecha = DateTime.Parse(value); }
        }

        public RegistroRanking(int puntuacion, int nivel, string nombre)
        {
            this.puntuacion = puntuacion;
            this.nivel = nivel;
            this.nombre = nombre;
            this.fecha = DateTime.Now;
        }
    }
}
