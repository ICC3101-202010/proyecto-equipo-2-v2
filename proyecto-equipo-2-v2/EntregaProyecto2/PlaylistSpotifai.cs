using System;
using System.Collections.Generic;
using System.Threading;
namespace EntregaProyecto2
{
    public class PlaylistSpotifai
    {
        private string typeFile;
        public List<string> Playlist;
        public List<string> PlaylistFav;

        //Agregadas Alvaro
        private string nombre; //nombre de la playlist creada

        public string Nombre { get => nombre; set => nombre = value; }

        public PlaylistSpotifai(string file, string nombre)
        {
            this.nombre = nombre;
            this.typeFile = file;
            Playlist = new List<string>();
            PlaylistFav = new List<string>();
        }

        public bool AddPlaylist()
        {
            return true;
        }
        public bool AddPlaylistFav()
        {
            return true;
        }
        public bool AddQueu()
        {
            return true;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}