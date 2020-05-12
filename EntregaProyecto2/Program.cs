using System;
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

            User user = new User();  //creamos el objeto de la nueva clase
            PrintAndReceive printAndReceive = new PrintAndReceive();

            SongClass cancion = new SongClass();
            Video video = new Video();




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
                        
                        

                        if (user.Plan == "1")
                        {
                            user.AddProfile();              // datos del usuario 


                        }//Perfil agregado

                        if (user.Plan == "2")

                        {
                            user.AddProfile();



                        }


                        if (user.Plan == "3")
                        {
                            user.AddProfiles();
                        }



                        break;



                    case "LogIn":
                        Console.Clear();
                        server.InicioSecion();
                     





                        if (user.Plan == "1") // ESTO SE TIENE QUE ARREGLAR
                        {
                            printAndReceive.MenuBasicPlan();
                            int ma;
                            ma = int.Parse(Console.ReadLine());

                            if (ma == 1)
                            {
                                printAndReceive.PrintMenu1BP();
                                
                            }


                            if (ma == 2)
                            {
                                printAndReceive.PrintMenu2BP();
                            }



                            if (ma == 3)
                            {
                                printAndReceive.PrintMenu61();
                                int me;

                                me = int.Parse(Console.ReadLine());
                                if (me == 1)
                                {


                                    server.ChangePlan();
                                    //aca si hay que veer si es familiar ,basico o premiu  para volver a crear perfiles
                                }
                                if (me == 2)
                                {
                                    server.ChangeTargetPay();
                                    break;
                                }
                                if (me == 3)
                                {
                                    server.ChangePassword();

                                    break;

                                }
                                if (me == 4)
                                {
                                    server.ChangeEmail();
                                    break;

                                }
                                if (me == 5)
                                {
                                    printAndReceive.PrintMenu7();
                                    break;
                                }

                            }



                            if (ma == 4)
                            {
                                printAndReceive.PrintMenu7();
                                break;
                            }

                        }

















                        int x = 2;//hacer que esto sea dependiento de su plan













                        if (x == 2)//plan Premiun
                        {
                            printAndReceive.PrintMenuPrincipal();
                            int ma;

                            ma = int.Parse(Console.ReadLine());



                            if (ma == 1)
                            {
                                printAndReceive.PrintMenu1();
                            }
                            if (ma == 2)
                            {
                                printAndReceive.PrintMenu2();
                                int me;
                                me = int.Parse(Console.ReadLine());

                                if (me == 1)
                                {
                                    //agregar metodo mostrar playlist
                                }
                                if (me == 2)
                                {
                                    //agregar metodo Crear Playlis
                                }
                                if (me == 3)
                                {
                                    //agregar metodo Eliminar playlist
                                }
                            }
                            if (ma == 3)
                            {
                                printAndReceive.PrintMenu3();

                                int me;
                                me = int.Parse(Console.ReadLine());

                                if (me == 1)
                                {
                                    //agregar metodo mostrar playlist
                                }
                                if (me == 2)
                                {
                                    //agregar metodo Crear Playlis
                                }
                                if (me == 3)
                                {
                                    //agregar metodo Eliminar playlist
                                }
                            }

                            //completar dependiento de metodos
                            if (ma == 4)
                            {
                                printAndReceive.PrintMenu4();
                            }
                            if (ma == 5)
                            {
                                printAndReceive.PrintMenu5();
                            }


                            if (ma == 6)
                            {
                                AddSong1(cancion);
                                break;


                            }
                            if (ma == 7)
                            {
                                AddVideo(video);
                                break;
                            }




                            if (ma == 8)
                            {
                                printAndReceive.PrintMenu61();
                                int me;

                                me = int.Parse(Console.ReadLine());
                                if (me == 1)
                                {


                                    server.ChangePlan();
                                    //aca si hay que veer si es familiar ,basico o premiu  para volver a crear perfiles
                                }
                                if (me == 2)
                                {
                                    server.ChangeTargetPay();
                                    break;
                                }
                                if (me == 3)
                                {
                                    server.ChangePassword();

                                    break;

                                }
                                if (me == 4)
                                {
                                    server.ChangeEmail();
                                    break;

                                }
                                if (me == 5)
                                {
                                    printAndReceive.PrintMenu7();
                                    
                                }
                            
                            
                            }
                         if (ma == 9)
                            {
                                break;

                            }
                            LoadSong();
                            LoadVideo();
                            LoadUser();
                            Console.WriteLine(cancion);
                            break;

                        }






                        if (x == 3)//plan familiar
                        {
                            //escoger usuario 1,2,3 o 4
                            printAndReceive.PrintMenuPrincipal();
                            int ma;

                            ma = int.Parse(Console.ReadLine());



                            if (ma == 1)
                            {
                                printAndReceive.PrintMenu1();
                            }
                            if (ma == 2)
                            {
                                printAndReceive.PrintMenu2();
                                int me;
                                me = int.Parse(Console.ReadLine());

                                if (me == 1)
                                {
                                    //agregar metodo mostrar playlist
                                }
                                if (me == 2)
                                {
                                    //agregar metodo Crear Playlis
                                }
                                if (me == 3)
                                {
                                    //agregar metodo Eliminar playlist
                                }
                            }
                            if (ma == 3)
                            {
                                printAndReceive.PrintMenu3();

                                int me;
                                me = int.Parse(Console.ReadLine());

                                if (me == 1)
                                {
                                    //agregar metodo mostrar playlist
                                }
                                if (me == 2)
                                {
                                    //agregar metodo Crear Playlis
                                }
                                if (me == 3)
                                {
                                    //agregar metodo Eliminar playlist
                                }
                            }

                            //completar dependiento de metodos
                            if (ma == 4)
                            {
                                printAndReceive.PrintMenu4();
                            }
                            if (ma == 5)
                            {
                                printAndReceive.PrintMenu5();
                            }

                            if (ma == 6)
                            {
                                AddSong1(cancion);
                                break;


                            }
                            if (ma == 7)
                            {
                                AddVideo(video);
                                break;
                            }

                            if (ma == 8)
                            {
                                printAndReceive.PrintMenu6();
                                int me;
                                me = int.Parse(Console.ReadLine());
                                if (me == 1)
                                {



                                }
                                if (me == 2) { }
                                if (me == 3) { }
                                if (me == 4)
                                { }
                                if (me == 5) { }
                                if (me == 6)
                                {
                                    server.ChangePassword();

                                    break;

                                }
                                if (me == 9)
                                {
                                    break;
                                }

                            }
                            //if (ma == 7)
                            // {
                            //printAndReceive.PrintMenu8();
                            //  break;
                            //}
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
        static public void AddSong1(SongClass cancion)
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
            rand.Next(1, 50);
            // Arreglar despues. por aohra sera 5
            cancion.AddSong(new SongClass(gender, publicationYear, title, 5, 100, study, keyword, composer, singer, album, lyrics, format));


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
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<SongClass> cancion = (List<SongClass>)formatter.Deserialize(stream);
            stream.Close();
            return cancion;
        }
        static public void ShowPeople(List<SongClass> cancion)
        {
            foreach (SongClass x in cancion)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine(" ");
        }
        //------------ IMPORTAR VIDEO ----------------------------------------
        static public void AddVideo( Video video)
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
            video.AddVideo(new Video(gender, año, title, 5, 100, study, keyword, description, mainActor, director, format));
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
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            List<Video> video = (List<Video>)formatter.Deserialize(stream);
            stream.Close();
            return video;
        }
    }
}