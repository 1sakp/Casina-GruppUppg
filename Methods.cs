using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Methods
{
    public static void Start()
    {
        string[] users = File.ReadAllLines(FullPath());

        //Se vilken användare som är inloggad
        foreach (string user in users)
        {
            string[] splittemp = user.Split('!');
            string Username = splittemp[0];
            string Password = splittemp[1];
            string Balance = splittemp[2];
            string Logged = splittemp[3];

            //om infon är korrekt så loggas man in
            if (Logged == "in")
            {
                //https://stackoverflow.com/questions/10753160/how-exactly-to-use-array-where
                //hittar var allt i array som inte är nuvarande användare och gör dem till en ny array, på så sätt
                //tar dem bort nuvarande användaren.
                users = users.Where(i => i != user).ToArray();
                File.WriteAllLines(FullPath(), users); //Owerwrite hela filen utan den inloggade

                //lägger tillbaka den nuvarande användaren fast i slutet i stället
                string apend = Username + "!" + Password + "!" + Balance + "!out";
                string[] lines = { apend }; //gör om infon till en sträng array
                File.AppendAllLines(FullPath(), lines); //lägger till den inloggade

                LoginClass.Login();
            }
        }
        LoginClass.Login();
    }

    public static string FullPath()
    {
        string fullPath = (System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString() + "\\Info.txt");
        return fullPath;
    }

    public static int GetBal()
    {
        /*ÄNDRA DETTA SEN TILL 0*/
        int bal = 0;

        //Gör en string array av alla rader d.v.s personer i txt documentet
        string[] users = File.ReadAllLines(FullPath());

        //Se vilken användare som är inloggad
        foreach (string user in users)
        {
            string[] splittemp = user.Split('!');
            string Logged = splittemp[3];
            string balance = splittemp[2];

            //om infon är korrekt så loggas man in
            if (Logged == "in")
            {
                bal = Int32.Parse(balance);
            }
        }
        return bal;
    }
    public static void NoCash()
    {
        string[] users = File.ReadAllLines(FullPath());

        //Se vilken användare som är inloggad
        foreach (string user in users)
        {

            string[] splittemp = user.Split('!');
            string Logged = splittemp[3];
            string bal = splittemp[2];

            //den inloggade användaren
            if (Logged == "in")
            {
                //ka ha problem med overflow av int men borde fungera
                Console.WriteLine("You are out of cash... deposit: ");
                string Balance = Console.ReadLine();

                int NewBalance = 0;
                bool IsInt = int.TryParse(Balance, out NewBalance);

                if (IsInt == true)
                {

                    Deposit(NewBalance);

                    LoginClass.Redirect();

                }
                else
                {
                    NoCash();
                }
            

                
            }
        }
        LoginClass.Login();
    }
    public static void Deposit(int NewBalance)
    {
        string[] users = File.ReadAllLines(FullPath());

        //Se vilken användare som är inloggad
        foreach (string user in users)
        {
            string[] splittemp = user.Split('!');
            string Username = splittemp[0];
            string Password = splittemp[1];
            string Logged = splittemp[3];

            //om infon är korrekt så loggas man in
            if (Logged == "in")
            {
                if (NewBalance > 2147483647)
                {
                    NewBalance = 2147483647;
                }

                //https://stackoverflow.com/questions/10753160/how-exactly-to-use-array-where
                //hittar var allt i array som inte är nuvarande användare och gör dem till en ny array, på så sätt
                //tar dem bort nuvarande användaren.
                users = users.Where(i => i != user).ToArray();
                File.WriteAllLines(FullPath(), users); //Owerwrite hela filen utan den inloggade

                //lägger tillbaka den nuvarande användaren fast i slutet i stället
                string apend = Username + "!" + Password + "!" + NewBalance + "!in";
                string[] lines = { apend }; //gör om infon till en sträng array
                File.AppendAllLines(FullPath(), lines); //lägger till den inloggade
                break;
            }
        }
    }
}

