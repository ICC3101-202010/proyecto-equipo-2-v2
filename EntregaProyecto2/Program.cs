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
            User user = new User();
            DateTime hora = new DateTime();
            User user2 = new User("Alvaro", "123123", "123", "Alvaro", 22, "Cespedes", "maculino", "Chilena", "Estudiante", "aeces", "123123", "premium", hora);
            PrintAndReceive printAndReceive = new PrintAndReceive();

            //SongClass cancion = new SongClass(); Ya instancie este objeto.
            //Video video = new Video(); // YA instancie
            ProfileManagment profileManagment = new ProfileManagment();
            IDictionary<User, List<Profile>> diccUserProfiles = new Dictionary<User, List<Profile>>();

            List<SongClass> cancion = new List<SongClass>();
            List<Video> video = new List<Video>();
            List<User> usuarios = new List<User>(); //Serializacion

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
            usuarios = server.UsersList;
            usuarios.Add(user2); //Sirve para empezar el programa con un usuario
                                 //Serializar EsTOOOOOOO


            bool exec = true;
            while (exec)
            {

                // Pedimos al usuario una de las opciones
                string chosen = ShowOptions(new List<string>() { "Registrarse", "LogIn", "Salir" });
                switch (chosen)
                {
                    case "Registrarse":
                        Console.Clear();

                        Console.Write("Bienvenido! Ingrese sus datos de registro \nUsuario: ");
                        string usr = Console.ReadLine();


                        Console.Write("Correo: ");
                        string email = Console.ReadLine();

                        Console.Write("Contraseña: ");
                        string psswd = Console.ReadLine();

                        Console.Write("Numero de telefono: ");
                        string number = Console.ReadLine();

                        Console.Write("Nombre: ");
                        string name = Console.ReadLine();

                        Console.Write("Apellido: ");
                        string lastname = Console.ReadLine();

                        Console.Write("Edad: ");
                        string e = Console.ReadLine();
                        int edad = Int32.Parse(e);

                        Console.Write("Genero: ");
                        string gender = Console.ReadLine();

                        Console.Write("Nacionalidad: ");
                        string nationality = Console.ReadLine();

                        Console.Write("Ocupacion: ");
                        string ocuppation = Console.ReadLine();

                        Console.WriteLine("ingrese su numero de tarjeta"); // hafe
                        string infopago = Console.ReadLine();

                        string planSeleccionado;

                        while (true)
                        {
                            Console.WriteLine("Planes: \n");
                            Console.WriteLine("1)plan Basico \n");
                            Console.WriteLine("2)plan premiun (personal) $3,990\n");
                            Console.WriteLine("3)plan familiar (4 usuarios) $7,990\n");
                            Console.WriteLine("Ingrese el numero de plan que desea: ");
                            string op = Console.ReadLine();
                            int plan = Int32.Parse(op);


                            if (plan == 1)
                            {
                                Console.WriteLine("Plan basico seleccionado, no se realizaran cargos en su tarjeta ");
                                planSeleccionado = "basico";
                                break;
                            }
                            else if (plan == 2)
                            {
                                Console.WriteLine("Plan premium seleccionado, se realizara un cargo de $3,990 en su tarjeta ");
                                planSeleccionado = "premium";
                                break;
                            }
                            else if (plan == 3)
                            {
                                Console.WriteLine("Plan familiar seleccionado, se realizara un cargo de $7,990 en su tarjeta ");
                                planSeleccionado = "familiar";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("numero invalido, ingreselo nuevamente");
                            }


                        }
                        DateTime dateRegister = new DateTime();

                        //Agregar el usario a una lista de usuarios
                        User usuario = new User(usr, number, psswd, name, edad, lastname, gender, nationality, ocuppation, email, infopago, planSeleccionado, dateRegister);
                        usuarios.Add(usuario);
                        server.Register(usr, email, psswd, number, planSeleccionado, infopago);
                        Console.WriteLine("usuario creado");

                        SaveUser(usuarios);
                        usuarios = LoadUser();

                        break;

                    case "LogIn":
                        usuarios = LoadUser();
                        Console.WriteLine("Ingresa tu nombre de usuario: ");
                        string usr1 = Console.ReadLine();
                        Console.WriteLine("Ingresa tu contraseña: ");
                        string pswd = Console.ReadLine();
                        User user1 = new User();

                        bool ver = true;


                        Console.Clear();
                        foreach (User u in usuarios)
                        {
                            if (u.NameUser == usr1 && u.Password == pswd)
                            {
                                user1 = u;
                                Console.WriteLine("se encontro el usuario");
                                ver = true;
                                break;

                            }
                            else
                            {
                                ver = false;

                            }
                        }

                        if (ver == true)
                        {

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
                                            if (user1.Plan == "familiar")
                                            {
                                                Console.WriteLine("Agregar perfil\n");
                                                if (diccUserProfiles.ContainsKey(user1) == true)
                                                {
                                                    if (diccUserProfiles[user1].Count <= 5)
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
                                            if (user1.Plan == "premium")
                                            {
                                                Console.WriteLine("Agregar perfil\n");
                                                if (diccUserProfiles.ContainsKey(user1) == true)
                                                {
                                                    if (diccUserProfiles[user1].Count == 0)
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

                                    List<Profile> listaperfiles = new List<Profile>();
                                    Profile perfilLog = new Profile();

                                    Console.WriteLine("Ingrese a su perfil");
                                    int hh = 1;
                                    foreach (KeyValuePair<User, List<Profile>> item in diccUserProfiles)
                                    {
                                        if (item.Key == user1)
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
                                                perfilLog = listaperfiles[numPerfil - 1];
                                                Console.WriteLine("El perfil escogido es: " + perfilLog.NameProfile);
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
                                            cancion = LoadSong(); //Al momento de iniciar la app, se tienen que cargar las cancoines previamente guardadas.
                                            video = LoadVideo();
                                            Console.WriteLine("Bienvenido " + perfilLog.NameProfile);
                                            Console.WriteLine("1)Importar cancion"); //Listo
                                            Console.WriteLine("2)Importar video");// Listo
                                            Console.WriteLine("3)Buscar canciones");
                                            Console.WriteLine("4)Buscar videos");
                                            Console.WriteLine("5)Agregar imagenes");
                                            Console.WriteLine("6)Crear playlist de canciones: ");
                                            Console.WriteLine("7)Crear playlist de videos: ");

                                            Console.WriteLine("8)salir");
                                            Console.WriteLine("Seleccione un numero del menu: ");
                                            string rt = Console.ReadLine();
                                            int menuPerfil = Int32.Parse(rt);

                                            if (menuPerfil == 1)
                                            {
                                                if (user1.Plan == "premium" || user1.Plan == "familiar")
                                                {
                                                    AddSong(cancion);
                                                    SaveSong(cancion);
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
                                                    AddVideo(video);
                                                    SaveVideo(video); // Al momento de añadirlo se guarda automaticamente.
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No puede acceder a esta funcion con plan basico");
                                                }

                                            }
                                            else if (menuPerfil == 3)
                                            {
                                                Console.WriteLine("");
                                                ShowSong(cancion);
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


                                            }
                                            else if (menuPerfil == 7)
                                            {
                                                //accesible para basico, hacer aca el desarrollo de la funcion
                                            }
                                            else if (menuPerfil == 8)
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


                            break;


                        }
                        else
                        {
                            Console.WriteLine("Usuario no encontrado");
                            break;

                        }





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
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
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
        static public void AddVideo(List<Video> video)
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
        //--------------------------------------------- SERIALIZAR PLAYLIST -------------------------------------
        static public void SavePlaylistSong(Dictionary<Profile, List<SongClass>> playlist)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, playlist);
            stream.Close();
        }
        static private Dictionary<Profile, List<SongClass>> LoadDictionarySong()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Dictionary<Profile, List<SongClass>> playlist = (Dictionary<Profile, List<SongClass>>)formatter.Deserialize(stream);
            stream.Close();
            return playlist;
        }
        // -------------------------------------------- Diccionario User y perfil ------------------------------
        static public void SaveDic(IDictionary<User, List<Profile>> diccUserProfiles)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, diccUserProfiles);
            stream.Close();
        }
        static private IDictionary<User, List<Profile>> LoadDictionary()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            IDictionary<User, List<Profile>> diccUserProfiles = (IDictionary<User, List<Profile>>)formatter.Deserialize(stream);
            stream.Close();
            return diccUserProfiles;
        }

    }
}
