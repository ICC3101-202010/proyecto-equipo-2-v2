using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace EntregaProyecto2
{
<<<<<<< HEAD
    class Reproductor : Timer// Guarda el estado de la cancion.
=======
    class Reproductor :Timer// Guarda el estado de la cancion.
>>>>>>> 049b70818614190262b3636b174133317e8dffd2
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
<<<<<<< HEAD
        public Reproductor()
        {

        }
=======
>>>>>>> 049b70818614190262b3636b174133317e8dffd2

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

