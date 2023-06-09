﻿//Clase del formulario del menú principal

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarioBrosWF
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            Partida p = new Partida();
            p.SetMenu(this);
            p.Show();
            this.Hide();
        }

        private void mostrarRanking()
        {
            listRanking.Items.Clear();
            //Lectura
            string jsonString2 = File.ReadAllText(Configuracion.RANKING);
            List<RegistroRanking> lista = JsonSerializer.Deserialize<List<
                RegistroRanking>>(jsonString2);
            lista.Sort((s1, s2) => s2.Puntuacion.CompareTo(s1.Puntuacion));

            foreach (RegistroRanking r in lista)
            {
                ListViewItem registro = new ListViewItem();
                registro.Text = r.Nombre.ToString();
                registro.SubItems.Add(r.Puntuacion.ToString());
                registro.SubItems.Add(r.Nivel.ToString());
                registro.SubItems.Add(r.Fecha.ToString());  
                listRanking.Items.Add(registro);
            }
            listRanking.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Escritura
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(lista, opciones);
            File.WriteAllText(Configuracion.RANKING, jsonString);
        }

        private void MenuPrincipal_Activated(object sender, EventArgs e)
        {
            mostrarRanking();
        }

        private void buttonTamanyo_Click(object sender, EventArgs e)
        {
            if (Configuracion.ALTO_PANTALLA == 375)
            {
                Configuracion.ALTO_PANTALLA *= 2;
                Configuracion.ANCHO_PANTALLA *= 2;
                Configuracion.DIMENSIONES_POW[0] *= 2;
                Configuracion.DIMENSIONES_POW[1] *= 2;
                Configuracion.DIMENSIONES_PERSONAJE[0] *= 2;
                Configuracion.DIMENSIONES_PERSONAJE[1] *= 2;
                Configuracion.DIMENSIONES_ENEMIGO[0] *= 2;
                Configuracion.DIMENSIONES_ENEMIGO[1] *= 2;
                Configuracion.DIMENSIONES_PLATAFORMA[0] *= 2;
                Configuracion.DIMENSIONES_PLATAFORMA[1] *= 2;
                Configuracion.COORDENADAS_INICIALES_PERSONAJE[0] *=2;
                Configuracion.COORDENADAS_INICIALES_PERSONAJE[1] *=2;
                Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] *= 2;
                Configuracion.COORDENADAS_INICIALES_ENEMIGO[1] *= 2;
                Configuracion.COORDENADAS_INICIALES_POW[0] *= 2;
                Configuracion.COORDENADAS_INICIALES_POW[1] *= 2;
                Configuracion.GRAVEDAD_MAXIMA = 28;
                Configuracion.FUERZA_SALTO = -28;
                Configuracion.GRAVEDAD = 2;

                for (int i = 0; i < 
                    Configuracion.ANIMACION_PERSONAJE_DERECHA.Length; i++)
                {
                    Configuracion.ANIMACION_PERSONAJE_DERECHA[i] *= 2;
                    Configuracion.ANIMACION_PERSONAJE_IZQUIERDA[i] *= 2;
                    Configuracion.ANIMACION_TORTUGA_DERECHA[i] *= 2;
                    Configuracion.ANIMACION_TORTUGA_IZQUIERDA[i] *= 2;
                }
                for (int i = 0; i < Configuracion.ANIMACION_CANGREJO.Length; i++)
                {
                    Configuracion.ANIMACION_CANGREJO[i] *= 2;
                }

                Configuracion.VELOCIDAD_INICIAL_ENEMIGOS *= 2;
                Configuracion.PASO *= 2;
                Configuracion.CARPETA = "recursos/spritesGrandotes/";
            }
            else
            {
                Configuracion.ALTO_PANTALLA /= 2;
                Configuracion.ANCHO_PANTALLA /= 2;
                Configuracion.DIMENSIONES_POW[0] /= 2;
                Configuracion.DIMENSIONES_POW[1] /= 2;
                Configuracion.DIMENSIONES_PERSONAJE[0] /= 2;
                Configuracion.DIMENSIONES_PERSONAJE[1] /= 2;
                Configuracion.DIMENSIONES_ENEMIGO[0] /= 2;
                Configuracion.DIMENSIONES_ENEMIGO[1] /= 2;
                Configuracion.DIMENSIONES_PLATAFORMA[0] /= 2;
                Configuracion.DIMENSIONES_PLATAFORMA[1] /= 2;
                Configuracion.COORDENADAS_INICIALES_PERSONAJE[0] /= 2;
                Configuracion.COORDENADAS_INICIALES_PERSONAJE[1] /= 2;
                Configuracion.COORDENADAS_INICIALES_ENEMIGO[0] /= 2;
                Configuracion.COORDENADAS_INICIALES_ENEMIGO[1] /= 2;
                Configuracion.COORDENADAS_INICIALES_POW[0] /= 2;
                Configuracion.COORDENADAS_INICIALES_POW[1] /= 2;
                Configuracion.GRAVEDAD_MAXIMA = 14;
                Configuracion.FUERZA_SALTO = -14;
                Configuracion.GRAVEDAD = 1;

                for (int i = 0; i < 
                    Configuracion.ANIMACION_PERSONAJE_DERECHA.Length; i++)
                {
                    Configuracion.ANIMACION_PERSONAJE_DERECHA[i] /= 2;
                    Configuracion.ANIMACION_PERSONAJE_IZQUIERDA[i] /= 2;
                    Configuracion.ANIMACION_TORTUGA_DERECHA[i] /= 2;
                    Configuracion.ANIMACION_TORTUGA_IZQUIERDA[i] /= 2;
                }
                for (int i = 0; i < Configuracion.ANIMACION_CANGREJO.Length; i++)
                {
                    Configuracion.ANIMACION_CANGREJO[i] /= 2;
                }

                Configuracion.VELOCIDAD_INICIAL_ENEMIGOS /= 2;
                Configuracion.PASO /= 2;
                Configuracion.CARPETA = "recursos/spritesChiquitos/";
            }
            this.ClientSize = new Size(Configuracion.ANCHO_PANTALLA,
                Configuracion.ALTO_PANTALLA);
            this.CenterToScreen();
        }
    }
}
