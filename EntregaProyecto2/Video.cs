using System;
using System.Collections.Generic;
using System.Threading;
namespace EntregaProyecto2
{
    [Serializable]
    public class Video 
    {
        //private List<Actor> actors;
        private string description;
        private string mainActor;//PONERLOS EN SUS CLASES
        private string director; //
        private string format;
        private List<Video> videos;

        private string gender;
        private string publicationYear;
        private string title;
        private int duration;
        private int memory;
        private string study;
        private string keyword;

        public Video(string gender, string publicationYear,
                     string title, int duration, int memory, string study, string keyword,
                     string description, string mainActor, string director, string format)
        {
            this.Gender = gender; // Listo
            this.PublicationYear = publicationYear; // Listo
            this.Title = title; //Listo
            this.Duration = duration;
            this.Memory = memory;
            this.Study = study; // Listo
            this.Keyword = keyword; // Listo
            this.Description = description; // Listo
            this.MainActor = mainActor; // Listo
            //this.Actors = actors; No se como poner aun
            this.Director = director;  //Listo
            this.format = format;
        }
        public Video()
        {

        }
        public string Director { get => director; set => director = value; }
        public string Format { get => format; set => format = value; }
        //public List<Actor> Actors { get => actors; set => actors = value; }
        public string Description { get => description; set => description = value; }
        public string MainActor { get => mainActor; set => mainActor = value; }
        public List<Video> Videos1 { get => videos; set => videos = value; }
        public string Gender { get => gender; set => gender = value; }
        public string PublicationYear { get => publicationYear; set => publicationYear = value; }
        public string Title { get => title; set => title = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Memory { get => memory; set => memory = value; }
        public string Study { get => study; set => study = value; }
        public string Keyword { get => keyword; set => keyword = value; }

        public void AddData() //Cambiar UML  void
        {

        }
        public override string ToString()
        {
            Console.WriteLine("ACa puede ver el titulo del video, el director, el genero al que pertenece, año de publicacion, duracion, meoria, estudio de grabacion y su palabra clave. ");
            return Title + " " + Director + ": " + Gender + ": " + PublicationYear + ": " + Duration + ": " + Memory + ": " + Study + ": " + Keyword;
        }

    }
}
//gghh