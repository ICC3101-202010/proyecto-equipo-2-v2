using System;
using System.Collections.Generic;
using System.Threading;
namespace EntregaProyecto2 ///////Probando antonia vez 1500
{
    //hola gente
    //11 de mayo
    public class AbsMaster //PROBANDO NUEVAMENTE - ALVARO
    {
        private string gender;
        private string publicationYear;
        private int numReproduction;
        private string title;
        private int duration;
        private int memory;
        private string study;
        private string keyword;

        public AbsMaster()
        {

        }

        public string Gender { get => gender; set => gender = value; }
        public string PublicationYear { get => publicationYear; set => publicationYear = value; }
        public int NumReproduction { get => numReproduction; set => numReproduction = value; }
        public string Title { get => title; set => title = value; }
        public int Duration { get => duration; set => duration = value; }
        public int Memory { get => memory; set => memory = value; }
        public string Study { get => study; set => study = value; }
        public string Keyword { get => keyword; set => keyword = value; }

        public bool addImage(string imagen)
        {
            return true;
        }
        public bool AddLike()
        {
            return true;
        }
        public bool AddCalification()
        {
            return true;
        }
        public bool AddReprodution()
        {
            return true;
        }
        public bool AddListReprodution()
        {
            return true;
        }
    }
}
