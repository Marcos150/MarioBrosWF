using SharpDX.XInput;

namespace MarioBrosWF
{
    internal class Configuracion
    {
        public static int ANCHO_PANTALLA = 640;
        public static int ALTO_PANTALLA = 600;
        public static int RATIO_ANIMACION = 5;
        public static int[] COORDENADAS_INICIALES = {10, 32};
        public static int VIDAS_INICIALES = 3;
        public static int USOS_BLOQUES_POW = 3;
        public static int VELOCIDAD_INICIAL_ENEMIGOS = 1;
        public static int TIEMPO_VULNERABILIDAD_ENEMIGOS = 5000; //Milisegundos
        public static int FILAS_MAPA = 5; //Número de filas de map.txt -1
        public static int GRAVEDAD_MAXIMA = 16;
        public static int FUERZA_SALTO = -16;
        public static string CODIGO_SECRETO = "Up, Up, Down, Down, Left, Right, Left, Right, B, A";

        public static GamepadButtonFlags BOTON_SALTO = GamepadButtonFlags.A;
    }
}
