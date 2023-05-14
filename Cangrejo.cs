//Clase que define a los enemigos cangrejo

namespace MarioBrosWF
{
    internal class Cangrejo : Enemigo
    {
        private bool estaEnfadado;

        public Cangrejo() : base()
        {
            this.estaEnfadado = false;
            vidas = 2;
            puntos = 0;
        }
    }
}
