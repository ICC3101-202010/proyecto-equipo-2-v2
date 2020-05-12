﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.IO; //Agregadas Para la serializacion
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters; // Para cargar formato UML


namespace EntregaProyecto2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            // Creamos todos los objetos necesarios
            DataBase database = new DataBase();
            Server server = new Server(database);
            MailSender mailSender = new MailSender();
            SMSSender smsSender = new SMSSender();
            User user = new User();  
            PrintAndReceive printAndReceive = new PrintAndReceive();
            SongClass cancion = new SongClass();
            Video video = new Video();
            ProfileManagment profileManagment = new ProfileManagment();
            IDictionary<User, List<Profile>> diccUserProfiles = new Dictionary<User, List<Profile>>();

            //Suscribir los que escuchan los eventos

            //1- Suscribir OnRegistrado de mailSender para que escuche el evento Registrado enviado por servidor
            server.Registered += mailSender.OnRegistered;
            //2- Suscribir OnCambiadaContrasena de mailSender para que escuche el evento CambiadaContrasena enviado por servidor
            server.PasswordChanged += mailSender.OnPasswordChanged;
            //3- Suscribir OnCambiadaContrasena de smsSender para que escuche el evento CambiadaContrasena enviado por servidor
            server.PasswordChanged += smsSender.OnPasswordChanged;


            mailSender.EmailSented += user.OnEmailSent; //llamo a los nuevos metodos y eventos creados
            user.EmailVerified += user.EmailVerified;

            // Controla la ejecucion mientras el usuario no quiera salir
            bool exec = true;
            while (exec)
            {
                // Pedimos al usuario una de las opciones
                string chosen = ShowOptions(new List<string>() { "Registrarse", "LogIn", "Salir" });
                switch (chosen)
                {
                    case "Registrarse":
                        Console.Clear();
                        server.Register();
                        break;

                    case "LogIn":
                        Console.WriteLine("Ingresa tu nombre de usuario: ");
                        string usr = Console.ReadLine();
                        Console.WriteLine("Ingresa tu contraseña: ");
                        string pswd = Console.ReadLine();
                        User user1= new User();

                        Console.Clear();
                        if (server.InicioSecion(usr, pswd)==true)
                        {
                            foreach (User cc in server.UsersList)
                            {
                                if (cc.NameUser == usr)
                                {
                                    user1 = cc;
                                    break;
                                }
                                
                            }
                            //Menu usuario
                            
                                
                                while (true)
                                {
                                    Console.WriteLine("BIENVENIDO A SPOTFLIX");
                                    Console.WriteLine("1) Admistracion perfiles");
                                    Console.WriteLine("2) Entrar a un perfil");
                                    Console.WriteLine("3) Administrar usuario");
                                    Console.WriteLine("4) Salir");
                                    Console.WriteLine("escoja una numero de opcion: ");
                                    string es = Console.ReadLine();
                                    int escoger = Int32.Parse(es);
                                    if (escoger == 1)
                                    {
                                        
                                            
                                            while (true)
                                            {
                                                Console.WriteLine("Menu administracion de perfiles \n1)Agregar Perfil \n2)Ver perfiles \n3)Cambiar Perfil \n4)Eliminar perfil \n5)Salir");
                                                Console.WriteLine("ingrese el numero de la opcion que desea realizar: ");
                                                string ooo = Console.ReadLine();
                                                int opop = Int32.Parse(ooo);
                                                if (opop == 1)
                                                {
                                                    if(user1.Plan=="familiar")
                                                    {
                                                        Console.WriteLine("Agregar perfil\n");
                                                        if (diccUserProfiles.ContainsKey(user1) == true)
                                                        {
                                                            if (diccUserProfiles[user1].Count<= 5)
                                                            {
                                                                profileManagment.AddProfile();
                                                                if (diccUserProfiles.ContainsKey(user1) == true)
                                                                {
                                                                    diccUserProfiles.Remove(user1);
                                                                    diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Ya alcanzo su limite de perfiles");
                                                            }
                                                        }
                                                        else
                                                        {
                                                             profileManagment.AddProfile();
                                                             diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                        }
                                                    }
                                                    if(user1.Plan=="premium")
                                                    {
                                                        Console.WriteLine("Agregar perfil\n");
                                                        if (diccUserProfiles.ContainsKey(user1) == true)
                                                        {
                                                            if (diccUserProfiles[user1].Count== 0)
                                                            {
                                                                profileManagment.AddProfile();
                                                                if (diccUserProfiles.ContainsKey(user1) == true)
                                                                {
                                                                    diccUserProfiles.Remove(user1);
                                                                    diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Ya alcanzo su limite de perfiles");
                                                            }
                                                        }
                                                        else
                                                        {
                                                             profileManagment.AddProfile();
                                                             diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                        }
                                                    }
                                                }
                                                else if (opop == 2)
                                                {
                                                    Console.WriteLine("Ver perfiles\n");
                                                    profileManagment.SeeProfile();
                                                    
                                                }
                                                else if (opop == 3)
                                                {
                                                    Console.WriteLine("Cambiar Perfil\n");
                                                    profileManagment.ChangeProfile();
                                                    if (diccUserProfiles.ContainsKey(user1) == true)
                                                    {
                                                        diccUserProfiles.Remove(user1);
                                                        diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                    }
                                                    else
                                                    {
                                                        diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                    }

                                                    

                                                }
                                                else if (opop == 4)
                                                {
                                                    Console.WriteLine("Eliminar Perfil\n");
                                                    if (profileManagment.DeleteProfile() == true)
                                                    {
                                                        if (diccUserProfiles.ContainsKey(user1) == true)
                                                        {
                                                            diccUserProfiles.Remove(user1);
                                                            diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                        }
                                                        else
                                                        {
                                                            diccUserProfiles.Add(user1, profileManagment.Profiles);
                                                        }
                                                    }
                                                    
                                                }
                                                else if (opop == 5)
                                                {

                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Opcion no valida vuelva a ingresarla");
                                                }

                                            }

                                            
                                        
                                        
                                    }
                                    

                                    else if (escoger == 2)
                                    {

                                        List < Profile > listaperfiles = new List<Profile>();
                                        Profile perfilLog = new Profile();

                                        Console.WriteLine("Ingrese a su perfil");
                                        int hh = 1;
                                        foreach (KeyValuePair<User, List<Profile>> item in diccUserProfiles)
                                        {
                                            if (item.Key==user1)
                                            {
                                                listaperfiles = item.Value;
                                                break;
                                            }
                                        }
                                        if (listaperfiles.Count > 0)
                                        {
                                            foreach (Profile v in listaperfiles)
                                            {
                                                Console.WriteLine(hh + ") " + v.NameProfile);
                                                hh++;
                                            }
                                            while (true)
                                            {
                                                Console.WriteLine("Seleccione el numero de su perfil: ");
                                                string gh = Console.ReadLine();
                                                int numPerfil = Int32.Parse(gh);
                                                if (numPerfil <= listaperfiles.Count && numPerfil != 0)
                                                {
                                                    perfilLog=listaperfiles[numPerfil - 1];
                                                    Console.WriteLine("El perfil escogido es: "+perfilLog.NameProfile);
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("numero incorrecto, vuelva a ingresarlo");
                                                }
                                            }
                                            //Menu perfiles
                                            

                                            while (true)
                                            {
                                                Console.WriteLine("Bienvenido " + perfilLog.NameProfile);
                                                Console.WriteLine("1)Importar cancion");
                                                Console.WriteLine("2)Importar video");//
                                                Console.WriteLine("3)Ver informacion cancion: ");
                                                Console.WriteLine("4)Buscar");
                                                Console.WriteLine("5)Agregar imagenes");
                                                Console.WriteLine("6)Crear playlist de canciones: ");
                                                Console.WriteLine("7)Crear playlist de videos: ");
                                                Console.WriteLine("8)Descargar canciones");
                                                Console.WriteLine("9)salir");
                                                Console.WriteLine("Seleccione un numero del menu: ");
                                                string rt = Console.ReadLine();
                                                int menuPerfil = Int32.Parse(rt);

                                                if (menuPerfil == 1)
                                                {
                                                    if (user1.Plan=="premium" || user1.Plan=="familiar")
                                                    {
                                                        //aca va el desarollo de importar funcion
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No puede acceder a esta funcion con plan basico");
                                                    }
                                                }
                                                else if (menuPerfil == 2)
                                                {
                                                    if (user1.Plan == "premium" || user1.Plan == "familiar")
                                                    {
                                                        //aca va el desarollo de importar funcion
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No puede acceder a esta funcion con plan basico");
                                                    }

                                                }
                                                else if (menuPerfil == 3)
                                                {
                                                    //accesible para basico, hacer aca el desarrollo de la funcion
                                                }
                                                else if (menuPerfil == 4)
                                                {
                                                    //accesible para basico, hacer aca el desarrollo de la funcion
                                                }
                                                else if (menuPerfil == 5)
                                                {
                                                    if (user1.Plan == "premium" || user1.Plan == "familiar")
                                                    {
                                                        //aca va el desarollo de importar funcion
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No puede acceder a esta funcion con plan basico");
                                                    }
                                                }
                                                else if (menuPerfil == 6)
                                                {
                                                    //accesible para basico, hacer aca el desarrollo de la funcion
                                                }
                                                else if (menuPerfil == 7)
                                                {
                                                    //accesible para basico, hacer aca el desarrollo de la funcion
                                                }
                                                else if (menuPerfil == 8)
                                                {
                                                    if (user1.Plan == "premium" || user1.Plan == "familiar")
                                                    {
                                                        //aca va el desarollo de importar funcion
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No puede acceder a esta funcion con plan basico");
                                                    }

                                                }
                                                else if (menuPerfil == 9)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("El numero no es valido, vuelva a ingresarlo");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No hay perfiles para realizar esta operacion");
                                            
                                        }
                                        
                                       
                                    }
                                    else if (escoger == 3)
                                    {
                                        //YO AGREGO ESTO, ANTO
                                    }
                                    else if (escoger == 4)
                                    {
                                        break;
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Numero invalido, ingreselo nuevamente");

                                    }

                                
                                }

                                

                           
                        }
                        else
                        {
                            Console.WriteLine("Usuario no encontrado");
                            
                        }
                        break;
                        


                    case "Salir":
                        exec = false;
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        // Metodo para mostrar las opciones posibles
        private static string ShowOptions(List<string> options)
        {
            int i = 0;
            Console.WriteLine("\n\nSelecciona una opcion:");
            foreach (string option in options)
            {
                Console.WriteLine(Convert.ToString(i) + ". " + option);
                i += 1;
            }

            return options[Convert.ToInt16(Console.ReadLine())];
        }
        //------------ AGREGAR USUARIO --------------------------------------------------------
        //Metodo para agregar usuarios y quede guardados. 
        //Ver como se agrega, debido que esta registrado.
        //Ver con mati
        static public void AddUser(List<User> usuario)
        {
            Console.WriteLine("nada");
        }

        //Metodo para guardar el usuario registrado.
        //Se tiene que hacer cada vez que se registra un usuario. 
        //Subir usuario.
        static private void SaveUser(List<User> usuario)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, usuario);
            stream.Close();
        }

        //Metodo para subir las personas una vez cerrado el programa.
        //Se tiene que uniciar automaticamente una vez abierto el programa.
        static private List<User> LoadUser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<User> usuario = (List<User>)formatter.Deserialize(stream);
            stream.Close();
            return usuario;
        }

        //Metodo Para mostrar los perfiles.
        //Puede servir para buscar los distintos perfiles.
        static public void ShowProfileUser(List<ProfilelUser> perfil)
        {
            foreach (ProfilelUser persona in perfil)
            {
                Console.WriteLine(persona);
            }
            Console.WriteLine(" ");
        }
        //------------ IMPORTAR CANCION ----------------------------------------------
        static public void AddSong(List<SongClass> cancion)
        {
            Console.Write("Titulo de la cancion: ");
            string title = Console.ReadLine();
            Console.Write("Cantante: ");
            string singer = Console.ReadLine();
            Console.Write("Año publicacion: ");
            string publicationYear = Console.ReadLine();
            Console.Write("Genero de la cancion: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Estudio de grabacion: ");
            string study = Console.ReadLine();
            Console.Write("Palabra Clave. ( sirve para encontrar la cancion) ");
            string keyword = Console.ReadLine();
            Console.Write("Compositor: ");
            string composer = Console.ReadLine();
            Console.Write("Album al que pertenece: ");
            string album = Console.ReadLine();
            Console.WriteLine("Formato de la cancion: ");
            string format = Console.ReadLine();
            Console.WriteLine("Letra de la cancion: ");
            string lyrics = Console.ReadLine();
            var rand = new Random();
            //rand.Next(1, 50);
            // Arreglar despues. por aohra sera 5
            cancion.Add(new SongClass(gender, publicationYear, title, 5, 100, study, keyword, composer, singer, album, lyrics, format));


        }

        //Metodos para Serializar canciones
        static private void SaveSong(List<SongClass> cancion)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, cancion);
            stream.Close();
        }
        //Deserializacion de cancion.
        static private List<SongClass> LoadSong()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<SongClass> cancion = (List<SongClass>)formatter.Deserialize(stream);
            stream.Close();
            return cancion;
        }
        static public void ShowSong(List<SongClass> cancion)
        {
            foreach (SongClass x in cancion)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }
        //------------ IMPORTAR VIDEO ----------------------------------------
        static public void AddVideo( List<Video> video)
        {
            Console.Write("Titulo del video: ");
            string title = Console.ReadLine();
            Console.Write("Director: ");
            string director = Console.ReadLine();
            Console.Write("Actor principal: ");
            string mainActor = Console.ReadLine();
            Console.WriteLine("Descripcion del video: ");
            string description = Console.ReadLine();
            Console.WriteLine("Genero del video: ");
            string gender = Console.ReadLine();
            Console.WriteLine("Año de publicacion: ");
            string año = Console.ReadLine();
            Console.WriteLine("Estudio donde se grabo: ");
            string study = Console.ReadLine();
            Console.WriteLine("Palabra Clave: ");
            string keyword = Console.ReadLine();
            Console.WriteLine("Formato del video: ");
            string format = Console.ReadLine();
            //Duracion 5 memoria 100 por ahora
            //Arreglar despues.
            video.Add(new Video(gender, año, title, 5, 100, study, keyword, description, mainActor, director, format));
        }

        //Metodos para Serializar Videos
        static private void SaveVideo(List<Video> video)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, video);
            stream.Close();
        }
        //Deserializacion de Video.
        static private List<Video> LoadVideo()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Video> video = (List<Video>)formatter.Deserialize(stream);
            stream.Close();
            return video;
        }

        //Mostrar Los videos que tieene el perfil.
        static public void ShowVideo(List<Video> video)
        {
            foreach (Video x in video)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();
        }

    }
}