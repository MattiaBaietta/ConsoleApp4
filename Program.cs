using System.Diagnostics.Tracing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    static void Main(string[] args)
    {
        bool esci = false;
        string utente;
        string passw;
        string scelta;
        
        do
        {
            Console.Clear();
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Loginutente.Login();
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                     break;
                case "2":
                    Loginutente.Logout();
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    break;
                case "3":
                    Loginutente.Verifica();
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    break;
                case "4":
                    Loginutente.Listaaccessi();
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    break;  
                case "5":
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    esci = true;
                    break;
                default:
                    Console.WriteLine("Devi inserire un'opzione valida");
                    Console.WriteLine("Premere un tasto per continuare");
                    Console.ReadLine();
                    break;

            }
        } while (esci == false);
    }
}

public class Loginutente
{
    private static string username;
    private static string password;
    private static bool isLogout=true;
    private static bool isLogin=false;
    private static List<DateTime> list=new List<DateTime>();
    private static string utente;
    private static string passw;

    public static void Login()
    {

        if (isLogout==false&&isLogin==true)
        {
            Console.WriteLine("Utente già loggato.");
        }
        else
        {
            Console.WriteLine("Inserire il nome utente");
            utente = Console.ReadLine();
            Console.WriteLine("Inserire la password");
            passw = Console.ReadLine();
            if (isLogin == false)
            {
                username = utente;
                password = passw;
                Console.WriteLine("Conferma la password");
                Checkpsw(Console.ReadLine());
                isLogout = false;
                isLogin = true;

            }
            else
            {
                if (utente == username && passw == password)
                {
                    Console.WriteLine("Conferma la password");
                    Checkpsw(Console.ReadLine());

                }
                else
                {
                    Console.WriteLine("Dati inseriti non corretti");
                }
            }
        }

    }
    public static void Checkpsw(string pw)
    {
        if (pw == password)
        {
            Console.WriteLine("Utente autenticato");
            list.Add(DateTime.Now);
              
        }
        else
        {
            Console.WriteLine("Le due password non corrispondono");
        }
    }
    public static void Logout()
    {
        if(isLogout==true)
        {
            Console.WriteLine("Utente già sloggato"); 
        }
        else
        {
            Console.WriteLine("Logout effettuato corretamente, reinserire le credenziali per effettuaro nuovamente il login");
            isLogout = true;
        }
    }
    public static void Verifica()
    {
        if (isLogin == true)
        {
            Console.WriteLine("L'ultimo accesso risale a:");
            Console.WriteLine(list.Last().ToString());
        }
        else
        {
            Console.WriteLine("Non è stato effettuato nessun accesso");
        }



       
    }
    public static void Listaaccessi()
    {
        if (isLogin == true)
        {
            foreach (DateTime dt in list)
            {
                Console.WriteLine($"Accesso:{dt.ToString()}");
            }
        }
        else
        {
            Console.WriteLine("Non è stato effettuato nessun accesso");
        }
            
    }
    
}