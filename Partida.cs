﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarioBrosWF
{
    public partial class Partida : Form
    {
        private Personaje jugador;
        private List<Enemigo> enemigos;
        private Timer cronometro;
        private bool secreto;
        private Plataforma[] plataformas;
        private BloquePOW pow;

        public Partida()
        {
            InitializeComponent();
            this.Width = Configuracion.ANCHO_PANTALLA;
            this.Height = Configuracion.ALTO_PANTALLA;
        }

        private void Partida_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GenerarEnemigo()
        {

        }

        private void GolpearPOW()
        {

        }

        private void Partida_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Partida_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TickTemporizador()
        {

        }

        private void ActualizarHUD()
        {

        }
    }
}
