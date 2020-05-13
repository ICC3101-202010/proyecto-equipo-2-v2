using System;
using System.Collections.Generic;

namespace EntregaProyecto2
{
    public class SearchClass
    {
        //Lo cambie a void (AS)
        public SongClass SearchForComposer()
        {
            SongClass cancion = new SongClass();
            Console.WriteLine("Que compositor quieres buscar? ");
            string composer = Console.ReadLine();
            Console.WriteLine("Estos son las canciones que se pudieron encontrar con su respectivo compositor");
            foreach (SongClass objeto in cancion.Canciones)
            {
                if (objeto.Composer == composer)
                {
                    Console.WriteLine(cancion.Title, cancion.Composer);
                    
                    break;
                }
                
                
            }
            return cancion;
            
        }
        public SongClass SearchKeyWordSong()
        {
            SongClass cancion = new SongClass();
            Console.WriteLine("Escriba la palabra clave que quiera buscar");
            string keyword = Console.ReadLine();
            Console.WriteLine("Estos son las canciones que se pudieron encontrar con la palabra clave");
            foreach (SongClass x in cancion.Canciones)
            {
                if (x.Keyword == keyword)
                {
                    Console.WriteLine(cancion.Title, cancion.Keyword);
                    break;
                }

            }
            return cancion;
        }
        public void SearchKeyWordVideo() 
        {
            Console.WriteLine("Escriba la palabra clave que quiera buscar");
            Video video = new Video();
            string keyword = Console.ReadLine();
            Console.WriteLine("Estos son los videos que se pudieron encontrar con la palabra clave");
            foreach (Video x in video.Videos1)
            {
                if (x.Keyword == keyword)
                {
                    Console.WriteLine(video.Title, video.Keyword);
                }
            }
        }
        public bool SearchForMember()
        {
            return true;
        }
        public bool SearchForCharacteristic()
        {
            return true;
        }
        public bool SearchResVideo()
        {
            return true;
        }
        public bool SearchForEvaluation()
        {
            return true;
        }
        public bool SearchProfile()//BUSCAR PERFIL
        {
            return true;
        }
        public SongClass SearchSinger()
        {
            SongClass cancion = new SongClass();
            Console.WriteLine("Que cantante quieres buscar? ");
            string singer = Console.ReadLine();
            Console.WriteLine("Estos son las canciones que se pudieron encontrar con su respectivo cantante");
            foreach (SongClass objeto in cancion.Canciones)
            {
                if (objeto.Singer == singer)
                {
                    Console.WriteLine(cancion.Title, cancion.Singer);
                    break;
                }
            }
            return cancion;
        }
        public void SearchDirector()
        {
            Video video = new Video();
            Console.WriteLine("Que director quieres buscar? ");
            string director = Console.ReadLine();
            Console.WriteLine("Estos son los videos que se pudieron encontrar con su respectivo director");
            foreach (Video objeto in video.Videos1)
            {
                if (objeto.Director == director)
                {
                    Console.WriteLine(video.Title, video.Director);
                }
            }

        }


    }
}