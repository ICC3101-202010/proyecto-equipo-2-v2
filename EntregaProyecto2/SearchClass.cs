using System;
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
            foreach (SongClass x in cancion)
            {
                if (x.Composer == composer)
                {
                    Console.WriteLine(cancion.Title, cancion.Composer);
                }
            }
        }
        public bool SearchKeyWord()
        {
            SongClass cancion = new SongClass();
            Video video = new Video();
            Console.WriteLine("Escriba la palabra clave que quiera buscar");
            string keyword = Console.ReadLine();
            Console.WriteLine("Estos son las canciones y videos que se pudieron encontrar con la palabra clave");
            foreach (SongClass x in cancion.Composer)
            {
                Console.WriteLine("Aqui puede encontrar a las canciones con el compositor que busca");
                Console.WriteLine(cancion.Title, cancion.Composer);
            }
            foreach (Video x in cancion.Composer)
            {
                Console.WriteLine("Aqui puede encontrar a las canciones con el compositor que busca");
                Console.WriteLine(cancion.Title, cancion.Composer);
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