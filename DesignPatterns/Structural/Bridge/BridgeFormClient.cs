﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DesignPatterns.Structural.Bridge
{
    public partial class BridgeFormClient : Form
    {
        ReproductorVideo reproductorVideo;

        public BridgeFormClient()
        {
            InitializeComponent();
            reproductorVideo = new ReproductorVideo();
        }       

        /// <summary>
        /// Suponemos que reproducir un archivo AVI implica usar un Implementador normal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAVI_Click(object sender, EventArgs e)
        {
            ReproductorVideoImplementador implementador = new ReproductorVideoImplementador();
            VerVideo(implementador);           
        }

        /// <summary>
        /// Suponemos que reproducir un archivo MP4 implica usar un Implementador mejorado que reproduce en HD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMP4_Click(object sender, EventArgs e)
        {
            ReproductorVideoImplementadorMejorado implementadorMejorado = new ReproductorVideoImplementadorMejorado();
            VerVideo(implementadorMejorado);   
        }

        /// <summary>
        /// El cliente permite que el implementador mejore, sin afectar a la interfaz de la abstracción ReproductorVideo.
        /// </summary>
        /// <param name="implementador"></param>
        private void VerVideo(ReproductorMultimediaImplementador implementador)
        {

            txtReproductor.Text = string.Empty;

            reproductorVideo.Implementador = implementador;

            txtReproductor.Text += Environment.NewLine;
            txtReproductor.Text += reproductorVideo.Abrir();
            Application.DoEvents();
            Thread.Sleep(500);

            txtReproductor.Text += Environment.NewLine;
            txtReproductor.Text += reproductorVideo.Reproducir();
            Application.DoEvents();
            Thread.Sleep(500);

            txtReproductor.Text += Environment.NewLine;
            txtReproductor.Text += reproductorVideo.Cerrar();
            Application.DoEvents();
        }
    }
}
