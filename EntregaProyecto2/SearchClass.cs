using System;
using System.Collections.Generic;

namespace EntregaProyecto2
{
    public class SearchClass
    {
        //Lo cambie a void (AS)
        public void SearchForComposer()
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
                }
            }
        }
        public void SearchKeyWord()
        {
            SongClass cancion = new SongClass();
            Video video = new Video();
            Console.WriteLine("Escriba la palabra clave que quiera buscar");
            string keyword = Console.ReadLine();
            Console.WriteLine("Estos son las canciones y videos que se pudieron encontrar con la palabra clave");
            foreach (SongClass x in cancion.Canciones)
            {
                if (x.Keyword == keyword)
                {
                    Console.WriteLine(cancion.Title, cancion.Keyword);
                }

            }
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


    }
}