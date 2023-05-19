//Clase con los elementos configurables

using SharpDX.XInput;

namespace MarioBrosWF
{
    internal class Configuracion
    {
        public static int ANCHO_PANTALLA = 640;
        public static int ALTO_PANTALLA = 375;
        public static int RATIO_ANIMACION = 5;
        public static int[] COORDENADAS_INICIALES_PERSONAJE = {100, 32};
        public static int[] COORDENADAS_INICIALES_ENEMIGO = {64, 32};
        public static int VIDAS_INICIALES = 3;
        public static int USOS_BLOQUES_POW = 3;
        public static int VELOCIDAD_INICIAL_ENEMIGOS = 1;
        public static int PUNTOS_ENEMIGO = 300;
        public static int PASO = 4;
        public static int TIEMPO_VULNERABILIDAD_ENEMIGOS = 5000; //Milisegundos
        public static int FILAS_MAPA = 5; //Número de filas de map.txt -1
        public static int GRAVEDAD = 1;
        public static int GRAVEDAD_MAXIMA = 14;
        public static int FUERZA_SALTO = -14;
        public static string CODIGO_SECRETO = "Up, Up, Down, Down, Left, Right, Left, Right, B, A";

        public static int[] DIMENSIONES_PERSONAJE = {16, 23};
        public static int[] DIMENSIONES_ENEMIGO = {16, 16};
        public static int[] DIMENSIONES_PLATAFORMA = {128, 16};
        public static int[] ANIMACION_PERSONAJE_DERECHA = { 80, 96, 112, 128, 144 };
        public static int[] ANIMACION_PERSONAJE_IZQUIERDA = { 0, 16, 32, 48, 64 };
        public static int[] ANIMACION_ENEMIGO_DERECHA = { 80, 96, 112, 128, 144 };
        public static int[] ANIMACION_ENEMIGO_IZQUIERDA = { 0, 16, 32, 48, 64 };
        public static string CARPETA = "recursos/spritesChiquitos/";

        public static GamepadButtonFlags BOTON_SALTO = GamepadButtonFlags.A;
    }
}
