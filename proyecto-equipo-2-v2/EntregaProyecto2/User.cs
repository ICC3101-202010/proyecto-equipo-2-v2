using System;
using System.Collections.Generic;
using System.Threading;
namespace EntregaProyecto2

{
    [Serializable]//Serializar usuarios.
    public class User : Person
    {
        private string mail;
        private string paymentInfo;
        private string plan;
        private DateTime registrationDate;
        private string nameUser;
        private string password;
        private string numPhone;
        private List<User> usuarios;

        public User(string nameUser,string numPhone,string password, string name, int age, string lastname, string gender, string nationality, string occupation, string mail, string paymentInfo, string plan, DateTime registrationDate)
        {
            this.NumPhone = numPhone;
            this.Password = password;
            this.NameUser = nameUser;
            this.Name = name;
            this.Age = age;
            this.Lastname = lastname;
            this.Gender = gender;
            this.Nationality = nationality;
            this.Occupation = occupation;
            this.Mail = mail;
            this.PaymentInfo = paymentInfo;
            this.Plan = plan;
            this.RegistrationDate = registrationDate;

        }

        public User()
        {
        }
     

        // Atributo BaseDatos

        
        public int EmailVerified { get; internal set; }
        public string Mail { get => mail; set => mail = value; }
        public string PaymentInfo { get => paymentInfo; set => paymentInfo = value; }
        public string Plan { get => plan; set => plan = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public string NameUser { get => nameUser; set => nameUser = value; }
        public string Password { get => password; set => password = value; }
        public string NumPhone { get => numPhone; set => numPhone = value; }
        public List<User> Usuarios { get => usuarios; set => usuarios = value; }

        public delegate void EmailVerifiEventHandler(object source, EventArgs args);

        public event EmailVerifiEventHandler EmailVerifi;

        protected virtual void OnEmailVerified(User user, EventArgs args)
        {
            OnEmailVerified(this, new EventArgs());

        }

        public void OnEmailSent(object source, EventArgs args)
        {

            Console.WriteLine("¿Desea verificar el correo ?\n\n");
            Console.WriteLine("1)SI");
            Console.WriteLine("2)NO");
            string a = Console.ReadLine();
            int num = Convert.ToInt32(a);
            if (num == 1)
            {

                OnEmailVerified(this, new EventArgs());

            }

            else if (num == 2 )
            {
                Console.WriteLine("Email no verificado ");
            }
            else
            {
                Thread.Sleep(2000);
                Console.WriteLine("opcion ingresada invalida, se volvera al menu principal");
                Thread.Sleep(2000);
            }

        }

 
        public bool CambiarPlan()
        {
            return true;
        }


        public bool CambiarInfoPago()
        {
            return true;
        }
        public bool CambiarTipoPerfil()
        {
            return true;
        }
        public bool CambiarIngoPerfil()
        {
            return true;
        }



        //probando

       
        






















    }
}