using System;
using System.Collections.Generic;
using System.Threading;
namespace EntregaProyecto2
{

    public class ProfileManagment
    {
        private List<Profile> profiles;

        public ProfileManagment()
        {

        }

        public List<Profile> Profiles { get => profiles; set => profiles = value; }

        public bool DeleteProfile()
        {
            Console.WriteLine("Lista de perfiles: ");
            int x = 0;
            foreach (Profile c in profiles)
            {
                Console.WriteLine(x + ")\nNombre: " + c.NameProfile);
            }
            while (true)
            {
                if (profiles.Count == 0)
                {
                    Console.WriteLine("No hay perfiles para eliminar");
                    break;
                }
                else
                {
                    Console.WriteLine("Seleccione el numero del perfil que desea eliminar: ");
                    string l = Console.ReadLine();
                    int numperfil = Int32.Parse(l) - 1;
                    if (numperfil > profiles.Count || numperfil ==0)
                    {
                        Console.WriteLine("El numero no es valido, vuelva a ingresarlo");
                        
                    }
                    else
                    {
                        Console.WriteLine("El perfil a eliminar es: "+profiles[numperfil].NameProfile);
                        Console.WriteLine("Esta seguro de eliminar? \n1)si\n2)no\nopcion: ");
                        string vv = Console.ReadLine();
                        int seguro= Int32.Parse(vv);

                        while (true)
                        {
                            if (seguro == 1)
                            {
                                Console.WriteLine("Eliminando...");
                                Thread.Sleep(2000);
                                profiles.Remove(profiles[numperfil]);
                                Console.WriteLine("Perfil eliminado");
                                return true;
                            }
                            else if (seguro == 2)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opcion no valida, por favor escribala denuevo");
                            }
                        }

                        break;
                    }
                }
                
            }




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
            int k = 0;

            foreach(string a in categorias)
            {
                Console.WriteLine(k+") "+a);
                k++;
            }
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

            string[] categoriaspelis = { "terror", "ciencia-ficcion", "romantica", "comedia", "drama", "belicas", "anime", "", "psicologicas", "crimen", "fantasia", "clasicos", "policiacas", "documentales", "historicas", "biograficas", "catastrofes", "eroticas", "independientes", "mockbuster","religiosas","thriller" };
            Console.WriteLine("IV) Ingrese el numero de sus 5 categorias de pelicula favoritos: ");
            int j = 0;

            foreach (string b in categoriaspelis)
            {
                Console.WriteLine(j + ") " + b);
                j++;
            }

            List<string> gustosPeliculas = new List<string>();
            int h = 0;
            while (h < 5)
            {
                string n = Console.ReadLine();
                int seleccionpelis = Int32.Parse(n) - 1;
                if (seleccionpelis < 22 && seleccionpelis > 0)
                {
                    gustosPeliculas.Add(categoriaspelis[seleccionpelis]);
                    Console.WriteLine("Gusto añadido: " + categoriaspelis[seleccionpelis]);
                    h++;
                }
                else
                {
                    Console.WriteLine("Numero invalido, vuelva a ingresarlo");
                }

            }

            Profile profile = new Profile(nombre,tipoperfil,gustosMusica,gustosPeliculas);
            profiles.Add(profile);
            Console.WriteLine("Agregando perfil...");

            Thread.Sleep(2000);
            Console.WriteLine("Perfil agregado");
            return true;
        }

        public bool SeeProfile()
        {
            int y = 0;
            foreach (Profile c in profiles)
            {
                Console.WriteLine(y+")\nNombre: "+c.NameProfile);
                Console.WriteLine("Tipo perfil: "+c.ProfileType);
                Console.WriteLine("Gustos musicales: ");
                int m = 0;
                foreach (string a in c.PleasuresMusic)
                {
                    Console.WriteLine(m+") "+a);
                    m++;
                }
                y++;
                Console.WriteLine("Gustos peliculas: ");
                int t = 0;
                foreach (string g in c.PleasuresMovies)
                {
                    Console.WriteLine(t + ") " + g);
                    t++;
                }
                y++;
            }
            return true;
        }

    }


}
