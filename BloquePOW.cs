//Clase que define al bloque POW

namespace MarioBrosWF
{
    internal class BloquePOW : Sprite
    {
        private int usosRestantes;

        public BloquePOW() : base(16, 16)
        {
            usosRestantes = Configuracion.USOS_BLOQUES_POW;
        }
    }
}
