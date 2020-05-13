using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace EntregaProyecto2
{

    // Guarda el estado de la cancion.

    class Reproductor :Timer// Guarda el estado de la cancion.
    {
        private DateTime _inicio;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="intervalo">En milisegundos</param>
        public Reproductor(double intervalo)
        {
            base.Interval = intervalo;
            this.Elapsed += Tic;
        }

        public Reproductor()
        {

        }


        public void Iniciar()
        {
            this._inicio = DateTime.Now;
            this.Start();
            TimeSpan transcurrio = DateTime.Now - this._inicio;

        }

        public TimeSpan Detener()
        {
            this.Stop();
            TimeSpan transcurrio = DateTime.Now - this._inicio;
            return transcurrio;
        }

        private void Tic(object sender, ElapsedEventArgs e)
        {
            System.Console.Clear();
            TimeSpan transcurrio = DateTime.Now - this._inicio;
            System.Console.WriteLine(transcurrio.ToString());
        }
    }
}

