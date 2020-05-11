using System;
using System.Collections.Generic;
using System.Threading;
namespace EntregaProyecto2
{

    public class ProfileManagment
    {
        private List<ProfilelUser> profiles;

        public ProfileManagment()
        {

        }

        public List<ProfilelUser> Profiles { get => profiles; set => profiles = value; }

        public bool DeleteProfile()
        {
            return true;
        }
        public bool ChangeProfile()
        {
            return true;
        }
        public bool AddProfile()
        {
            Console.WriteLine("Complete la siguiente información: \nI)Nombre del perfil: ");
            string nombre = Console.ReadLine();
            string tipoperfil;

            while (true)
            {
                Console.WriteLine("II)Tipo perfil(escriba 1 o 2):\n  1)Perfil publico\n  2)Perfil privado ");
                string op = Console.ReadLine();
                int perfil = Int32.Parse(op);

                if (perfil == 1)
                {
                    tipoperfil = "publico";
                    break;
                }
                else if (perfil == 2)
                {
                    tipoperfil = "privado";
                    break;
                }
                else
                {
                    Console.WriteLine("opcion no valida, vuelva a ingresarla");
                }
            }
            string[] categorias = { "pop", "romantica", "rock", "metal", "clasica", "country", "latino", "reggae", "disco", "hip-hop", "indie", "chill", "folk", "arabe", "infantil", "cristiana", "soul", "jazz", "punk", "funk", "k-pop" };
            Console.WriteLine("III) Ingrese el nuemro de sus 5 generos de musica favoritos: ");
            Console.WriteLine("1)Pop \n2)Romantica \n3)Rock \n4)Metal \n5)Clasica \n 6)Country \n7)Latino \n8)Reggae \n9)Disco \n10)Hip-Hop \n11)Indie");
            Console.WriteLine("12)Chill \n13)Folk \n14)Arabe \n15)Infantil \n16)Cristiana \n 17)Soul \n18)Jazz \n19)Punk \n20)Funk \n21)K-pop");
            List<string> gustosMusica = new List<string>();

            int i = 0;
            while (i < 5)
            {
                string num = Console.ReadLine();
                int seleccion = Int32.Parse(num) - 1;
                if (seleccion < 22 && seleccion > 0)
                {
                    gustosMusica.Add(categorias[seleccion]);
                    Console.WriteLine("Gusto añadido: " + categorias[seleccion]);
                    i++;
                }
                else
                {
                    Console.WriteLine("Numero invalido, vuelva a ingresarlo");
                }

            }

            string[] categoriaspelis = { "terror", "ciencia-ficcion", "romantica", "comedia", "drama", "infantil", "suspenso", "musicales", "accion", "aventuras", "indie", "chill", "folk", "arabe", "infantil", "cristiana", "soul", "jazz", "punk", "funk", "k-pop" };
            Console.WriteLine("IV) Ingrese el numero de sus 5 categorias de pelicula favoritos: ");
            Console.WriteLine("1)Pop \n2)Romantica \n3)Rock \n4)Metal \n5)Clasica \n 6)Country \n7)Latino \n8)Reggae \n9)Disco \n10)Hip-Hop \n11)Indie");
            List<string> gustosPeliculas = new List<string>();




            //Profile profile = new Profile();
            return true;
        }
        public bool SeeProfile()
        {
            return true;
        }

    }


}
