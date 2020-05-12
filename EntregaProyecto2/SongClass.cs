using System;
using System.Collections.Generic;

namespace EntregaProyecto2
{
    [Serializable]
    public class SongClass
    {
        private string composer;
        private string singer;
        private string album; //AGERGAR A SUS RESPECTIVAS CLASES
        private string lyrics;
        private string format;
        private List<SongClass> canciones;

        //Atributos AbsMaster
        private string gender;
        private string publicationYear;
        private string title;
        private int duration;
        private int memory;
        private string study;
        private string keyword;

        public string Composer { get => composer; set => composer = value; }
        public string Singer { get => singer; set => singer = value; }
        public string Album { get => album; set => album = value; }
        public string Lyrics { get => lyrics; set => lyrics = value; }
        public string Format { get => format; set => format = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PublicationYear { get => publicationYear; set => publicationYear = value; }
        public string Title { get => title; set => title = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Memory { get => memory; set => memory = value; }
        public string Study { get => study; set => study = value; }
        public string Keyword { get => keyword; set => keyword = value; }
        public List<SongClass> Canciones { get => canciones; set => canciones = value; }

        public SongClass(string gender, string publicationYear,
                     string title, int duration, int memory, string study, string keyword,
                     string composer, string singer, string album, string lyrics, string format)
        {
            this.Gender = gender; // listo
            this.PublicationYear = publicationYear;//listo

            this.Title = title;//Listo
            this.Duration = duration;//Predeterminada
            this.Memory = memory;//Cada cancion pesa un nuero random [1-50]
            this.Study = study;// Listo
            this.Keyword = keyword; //Listo
            this.Composer = composer; //Listo
            this.Singer = singer; // Listo
            this.Album = album; // Listo
            this.Lyrics = lyrics;//EN veremos.
            this.Format = format; // Listo

        }
        public SongClass()
        {

        }


        public override string ToString()
        {
            Console.WriteLine("Aca puede ver el titutlo de la cancion, el compositor, genero, año de publicacion, duracion, memoria de la misma, estudio donde se grabo, palabra clase, cantante, album y la letra que usted añadio.");
            return Title + ": " + Composer + " " + Gender + " " + PublicationYear + " " + Duration + " " + Memory + " " + Study + " " + Keyword + " " + Singer + " " + Album + "" + Lyrics;
        }

    }
}//rfddhh