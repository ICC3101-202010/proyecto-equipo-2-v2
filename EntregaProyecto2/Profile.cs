using System;
using System.Collections.Generic;

namespace EntregaProyecto2
{
    public class Profile
    {
        private string nameProfile;
        private string profileType;
        private List<string> pleasuresMusic;
        private List<string> pleasuresMovies;

        public Profile(string nameProfile, string profileType, List<string> pleasuresMusic, List<string> pleasuresMovies)
        {
            this.NameProfile = nameProfile;
            this.ProfileType = profileType;
            this.PleasuresMusic = pleasuresMusic;
            this.PleasuresMovies = pleasuresMovies;
        }

        public string NameProfile { get => nameProfile; set => nameProfile = value; }
        public string ProfileType { get => profileType; set => profileType = value; }
        public List<string> PleasuresMusic { get => pleasuresMusic; set => pleasuresMusic = value; }
        public List<string> PleasuresMovies { get => pleasuresMovies; set => pleasuresMovies = value; }
    }
}